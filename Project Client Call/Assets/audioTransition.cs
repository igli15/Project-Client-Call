using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.Audio;

public class audioTransition : MonoBehaviour {

	[SerializeField] private AudioMixerSnapshot menuMusicOff;
	[SerializeField] private float fadeSpeed;
	[SerializeField] private GameObject introVideo;
	[SerializeField] private GameObject menuVideo;
	private float waitingTime;
	void Start () { 
		waitingTime = fadeSpeed;
		menuMusicOff.TransitionTo(fadeSpeed);
		introVideo.GetComponent<VideoPlayer>().Prepare();
	}
	
	// Update is called once per frame
	void Update () {
		waitingTime -= Time.deltaTime;
		if(waitingTime <= 0 & introVideo.GetComponent<VideoPlayer>().isPrepared == true)
		{
			introVideo.GetComponent<VideoPlayer>().Play();
			
		}
		if(waitingTime <= -0.1f)
		{
			menuVideo.SetActive(false);
			this.gameObject.SetActive(false);
		}
	}
}
