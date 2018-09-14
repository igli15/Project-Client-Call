﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0168 
#pragma warning disable 0219
#pragma warning disable 0414


public class WordScroll : MonoBehaviour
{

	[SerializeField] 
	private string charactersToScorll;
	
	private WordScrollManager wordScrollManager;
	private Selectable selectable;
	
	private string currentLetter = "";

	private char[] letters;

	[HideInInspector]
	public int scrollIndex;

	private Text text;
	
	// Use this for initialization
	void Start ()
	{
		selectable = GetComponent<Selectable>();
		
		wordScrollManager = transform.parent.GetComponent<WordScrollManager>();

		wordScrollManager.OnBeforeUsernameGenerated += AddCharacter;
		

		letters = charactersToScorll.ToCharArray();

		text = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if (selectable.IsSelected)
		{
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				ScrollUp();
			}
			else if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				ScrollDown();
			}
		}

		if(letters.Length > 0)
		text.text = letters[scrollIndex].ToString();

	}

	private void AddCharacter(WordScrollManager sender)
	{
		sender.AddCharacter(selectable.IndexToBePlaced,text.text);
	}

	public void ScrollUp()
	{
		if (scrollIndex <= 0)
		{
			scrollIndex = letters.Length - 1;
			return;
		}
		scrollIndex -= 1;

	}
	
	public void ScrollDown()
	{
		if (scrollIndex >= letters.Length - 1)
		{
			scrollIndex = 0;
			return;
		}

		scrollIndex += 1;

	}

	private void OnDestroy()
	{
		wordScrollManager.OnBeforeUsernameGenerated += AddCharacter;
	}
}
