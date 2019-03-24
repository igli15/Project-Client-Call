using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class preLoadMusic : MonoBehaviour {

	// Use this for initialization
	[SerializeField] private AudioClip introMusic;
	[SerializeField] private AudioClip sideScrollMusic;
	[SerializeField] private AudioClip arenaIntro;
	[SerializeField] private AudioClip arenaLoop;
	[SerializeField] private AudioClip resolutionScreenMusic;
	void Start () {
		introMusic.LoadAudioData();
		sideScrollMusic.LoadAudioData();
		arenaIntro.LoadAudioData();
		arenaLoop.LoadAudioData();
		resolutionScreenMusic.LoadAudioData();
	}
}
