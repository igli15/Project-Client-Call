using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoardManager : MonoBehaviour
{
	[SerializeField] 
	private Text highscoreTextField;

	[SerializeField] 
	private Text nameTextField;
	
	// Use this for initialization
	private void OnEnable()
	{
		highscoreTextField.text = "";
		nameTextField.text = "";
		GenerateHighscore();
	}

	private void GenerateHighscore()
	{
		
		HighScoreManager.instance.highscoreArray = HighScoreManager.instance.highscoreArray.OrderByDescending(x => x.score).ToArray();
		
		for (int i = 0; i < HighScoreManager.instance.highscoreArray.Length; i++)
		{
			nameTextField.text += HighScoreManager.instance.highscoreArray[i].name + "\n";
			highscoreTextField.text += HighScoreManager.instance.highscoreArray[i].score + "\n";
		}
		
	}
}
