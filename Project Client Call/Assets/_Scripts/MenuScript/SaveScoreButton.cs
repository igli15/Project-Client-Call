using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveScoreButton : MonoBehaviour
{
	[SerializeField] 
	private menuScript menuScript;

	[SerializeField] 
	private WordScrollManager wordScrollManager;
		
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Joystick1Button1))
		{
			if (menuScript.selectedButton == 0)
			{
				HighScoreManager.instance.SubmitHighscore(wordScrollManager.GenerateUserName());
				SceneManager.LoadScene("MainMenu");
			}
		}
	}
}
