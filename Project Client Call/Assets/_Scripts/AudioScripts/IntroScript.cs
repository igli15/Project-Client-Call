using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class IntroScript : MonoBehaviour {

	// Use this for initialization
	public VideoPlayer introPlayer;
	void Start () {
		introPlayer.loopPointReached += hasEnded;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			Camera.main.enabled = true;
			this.gameObject.SetActive(false);
		}
	}

	void hasEnded(VideoPlayer pIntroPlayer)
	{
		Camera.main.enabled = true;
		this.gameObject.SetActive(false);
	}
}
