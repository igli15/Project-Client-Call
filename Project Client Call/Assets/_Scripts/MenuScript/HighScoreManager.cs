using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class HighScoreManager : MonoBehaviour
{
	[Serializable]
	public class HighscoreData
	{
		public string name;
		public int score;
	}


	public HighscoreData[] highscoreArray;
	

	Dictionary<string,int> highscoreDictionary = new Dictionary<string,int>();
	
	private int killerScore;
	private int achieverScore;
	private int explorerScore;
	private int socialScore;
	private int totalScore;
	private int totalEnemyNumber;
	private int totalRoomNumbers;
	private float highscore;
	private float killerScoreAdd;

	private int collectableNumber;

	private int collectableScoreAdd;
	void Start () 
	{
		//totalEnemyNumber = GameObject.FindGameObjectsWithTag("Enemy").Length;
		//killerScoreAdd = 2500000/totalEnemyNumber;
		totalScore = 3000000;
		//totalRoomNumbers = GameObject.FindGameObjectsWithTag("Room").Length;
		//collectableNumber = GameObject.FindGameObjectsWithTag("Collectable").Length;
		//collectableScoreAdd = 250000/collectableNumber;

		SaveLoadScript.Load(this,"Test");
		if (highscoreArray != null)
		{
			highscoreDictionary = HighScoreDictionaryFromArray(highscoreArray);
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			SubmitHighscore("igli");
			SaveHighscore();
		}

		if (Input.GetKeyDown(KeyCode.K))
		{
			foreach (KeyValuePair<string,int> pair in highscoreDictionary)
			{
				Debug.Log(pair.Key + " " + pair.Value);
			}
		}
	}


	public void InreaseKillScore()
	{
		killerScore +=(int)killerScoreAdd;
		totalScore -=(int) killerScoreAdd;
	}
	public void IncreaseAchieverScore()
	{
		achieverScore += collectableScoreAdd;
	}

	public void IncreaseExplorerScore()
	{
		//bool visited becomes true if collided with it and score added;
	}

	public void CalcTotalScore()
	{
		totalScore = killerScore + socialScore + achieverScore + explorerScore;
	}
	public void SubmitHighscore(string userName)
	{
		if(!highscoreDictionary.ContainsKey(userName))
		{
			highscore = totalScore;
			highscoreDictionary.Add(userName,(int)highscore);
			return;
		}
		if(totalScore > highscore)
		{
			highscore = totalScore;
			highscoreDictionary[userName] = (int)highscore;
		}
	}

	private void SaveHighscore()
	{
		highscoreArray = HighScoreDictionaryToArray(highscoreDictionary);
		SaveLoadScript.Save(this,"test");
	}
	
	public HighscoreData[] HighScoreDictionaryToArray(Dictionary<string,int> dictionaryToSerialize)
	{
		List<HighscoreData> highscoreDataList = new List<HighscoreData>();

		foreach (KeyValuePair<string,int> pairs in dictionaryToSerialize)
		{
			HighscoreData highscoreData = new HighscoreData();
			highscoreData.name = pairs.Key;
			highscoreData.score = pairs.Value;
			highscoreDataList.Add(highscoreData);
		}
		

		HighscoreData[] arrayToReturn = highscoreDataList.ToArray();
		return arrayToReturn;
	}

	public Dictionary<string, int> HighScoreDictionaryFromArray(HighscoreData[] arrayOfData)
	{
		Dictionary<string, int> dictionaryToReturn = new Dictionary<string, int>();
		
		for (int i = 0; i < arrayOfData.Length ; i++)
		{
			dictionaryToReturn.Add(arrayOfData[i].name,arrayOfData[i].score);
		}
		return dictionaryToReturn;
	}
}
