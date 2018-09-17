using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class sideScrollMusicTrigger : MonoBehaviour {

	// Use this for initialization
	[SerializeField] private WorldMusic worldMusic;
	[SerializeField] private AudioSource audioSource;
	[SerializeField] private float fadingTime;
	[SerializeField] private AudioMixerSnapshot audioSnapShot;
	[SerializeField] private bool arenaException = false;
	[SerializeField] private AudioSource arenaSource;
	[SerializeField] private AudioClip arenaLoopClip;
	private float startPlaying;
	private bool startFadeOut;
	private float bpm = 143.93f;
	private int numBeatsPerSegment = 4;
	[SerializeField]private float arenaLoopTiming;
	private double nextEventTime;
	bool idk = false;
	bool arenaLoopPlaying = false;
	void Start () {
		startFadeOut = false;
		startPlaying = fadingTime;
		audioSource.GetComponent<AudioSource>().clip.LoadAudioData();
		nextEventTime =AudioSettings.dspTime + 2.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(startFadeOut == true&&!arenaException)
		{
			fadingTime-=Time.deltaTime;
			audioSource.Play();
			this.enabled = false;
		}
		if(arenaException == true && startFadeOut == true)
		{
			if(idk == false)
			{
			audioSource.Play();
			idk = true;
			}
			arenaLoopTiming -= Time.deltaTime;
			if(arenaLoopTiming<0 && arenaLoopPlaying == false)
			{
				arenaLoopPlaying = true;
				arenaSource.Play();
				worldMusic.MusicTransitionFadeOutSudden(worldMusic.arenaLoopSS, 0);
			}
			/*double time = AudioSettings.dspTime;
			if (time + 1.0f > nextEventTime)
			{
				arenaSource.clip = arenaLoopClip;
				arenaSource.PlayScheduled(nextEventTime);
				nextEventTime += 60.0f / bpm * numBeatsPerSegment;
				this.enabled = false;
			}*/
			
		}
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.transform.CompareTag("Player"))
		{
			startFadeOut = true;
			worldMusic.MusicTransitionFadeOutSudden(audioSnapShot, fadingTime);
		}
	}
}
