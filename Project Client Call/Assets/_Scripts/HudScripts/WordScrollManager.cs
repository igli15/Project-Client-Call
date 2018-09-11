using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordScrollManager : MonoBehaviour
{

	[SerializeField] 
	private int maxNrOfLetters = 5;
	
	[HideInInspector]
	public string[] letters;
	
	
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
		string result = "";

		foreach (var letter in letters)
		{
			result += letter;
		}

		return result;
	}
}
