using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class WorldMusic : MonoBehaviour {

	public AudioMixer levelMusicMixer;
	public AudioMixerSnapshot introMusicSS;
	public AudioMixerSnapshot sideScrollMusicSS;
	public AudioMixerSnapshot arenaIntroSS;
	public AudioMixerSnapshot arenaLoopSS;
	public AudioMixerSnapshot resolutionScreenMusicSS;



	void Start () {
	}
	
	void Update () {
		
	}

	public void MusicTransitionFadeOutSudden(AudioMixerSnapshot snapshot, float fadingTime)
	{
		snapshot.TransitionTo(fadingTime);
	}
}
