using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoardManager : MonoBehaviour
{
	[SerializeField] 
	private Text highscoreTextField;
	
	// Use this for initialization
	private void OnEnable()
	{
		highscoreTextField.text = GenerateHighscore();
	}

	private string GenerateHighscore()
	{
		string generatedString = " ";
		
		HighScoreManager.instance.highscoreArray = HighScoreManager.instance.highscoreArray.OrderByDescending(x => x.score).ToArray();
		
		for (int i = 0; i < HighScoreManager.instance.highscoreArray.Length; i++)
		{
			generatedString += i+1 + "-  " + HighScoreManager.instance.highscoreArray[i].name + ":  " +
			                   HighScoreManager.instance.highscoreArray[i].score + "\n";
		}
		return generatedString;
	}
}
