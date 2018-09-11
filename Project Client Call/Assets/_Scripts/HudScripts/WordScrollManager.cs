using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class WordScrollManager : MonoBehaviour
{

	[SerializeField] 
	private int maxNrOfLetters = 5;
	
	[HideInInspector]
	public string[] letters;

	public Action<WordScrollManager> OnBeforeUsernameGenerated;
	
	// Use this for initialization
	void Start ()
	{
		letters = new string[maxNrOfLetters];
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			Debug.Log(GenerateUserName());
		}
	}

	public void AddCharacter(int index,string letter)
	{
		letters[index] = letter;
	}

	public string GenerateUserName()
	{
		StringBuilder stringBuilder = new StringBuilder();
		
		if( OnBeforeUsernameGenerated != null)  OnBeforeUsernameGenerated(this);

		foreach (var letter in letters)
		{
			stringBuilder.Append(letter);
		}

		return stringBuilder.ToString();
	}
}
