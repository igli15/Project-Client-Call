using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Object = System.Object;

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
        if (HighScoreManager.instance.highscoreArray != null)
        {
            HighScoreManager.instance.highscoreArray = HighScoreManager.instance.highscoreArray.OrderByDescending(x => x.score).ToArray();
            HighScoreManager.instance.highscoreArray = CutArray(HighScoreManager.instance.highscoreArray, 6);
            for (int i = 0; i < HighScoreManager.instance.highscoreArray.Length; i++)
            {
                if (HighScoreManager.instance.highscoreArray[i] != null)
                {
                    nameTextField.text += HighScoreManager.instance.highscoreArray[i].name + "\n";
                    highscoreTextField.text += HighScoreManager.instance.highscoreArray[i].score + "\n";
                }

            }
        }
	}

	private HighScoreManager.HighscoreData[] CutArray(HighScoreManager.HighscoreData[] arrayToCut,int MaxSize)
	{
		HighScoreManager.HighscoreData[] returnArray = new HighScoreManager.HighscoreData[MaxSize];
		
		for (int i = 0; i < arrayToCut.Length; i++)
		{
			if (i <= MaxSize -1)
			{
				returnArray[i] = arrayToCut[i];
			}
		}

		return returnArray;
	}
}
