using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class LoadLevelAfterVideo : MonoBehaviour {

	// Use this for initialization
	 private VideoPlayer intro;
	[SerializeField] private LevelLoader levelLoader;
	void Start () {
		intro = GetComponent<VideoPlayer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(intro.frame >= 1680)
		{
			levelLoader.StartLevel();
		}
	}
}
