using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class HighScoreManager : MonoBehaviour
{
	[Serializable]
	public class HighscoreData      //Making a dictionary manually
	{
		public string name;
		public int score;
	}


	[HideInInspector]
	public HighscoreData[] highscoreArray;   //an array of datas ;D

	[SerializeField] 
	private float achievementNumber = 0;

	Dictionary<string,int> highscoreDictionary = new Dictionary<string,int>();
	
	private float killerScore;
	private float achieverScore;
	private float explorerScore;
	private float socialScore;
	private int totalScore;
	private int totalEnemyNumber;
	private int totalRoomNumbers;
	private float highscore;
	private float killerScoreAdd;
	private float explorerScoreAdd;
	private float achieverScoreAdd;


	public static HighScoreManager instance;

	private void Awake()
	{
		#region SINGELTON          
		
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
		
		#endregion  
		
		DontDestroyOnLoad(gameObject);
		
		SceneManager.sceneLoaded += OnSceneLoaded;
		
		SaveLoadScript.Load(this,"Test");
		if (highscoreArray != null)
		{
			highscoreDictionary = HighScoreDictionaryFromArray(highscoreArray);   //Load array if there is one
		}
	}

	
	void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		try
		{
			totalEnemyNumber = GameObject.FindGameObjectsWithTag("Enemy").Length;
			killerScoreAdd = 500000 / totalEnemyNumber;
			totalRoomNumbers = GameObject.FindGameObjectsWithTag("ExplorerRoom").Length;
			explorerScoreAdd = 250000 / totalRoomNumbers;
			achieverScoreAdd = 250000 / achievementNumber;
		}
		catch (Exception e)
		{

		}
	
	}
	

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.K))
		{
			foreach (KeyValuePair<string,int> pair in highscoreDictionary)
			{
				Debug.Log(pair.Key + " " + pair.Value);
			}
		}
		if (Input.GetKeyDown(KeyCode.D))
		{
			CalcTotalScore();
			Debug.Log(totalScore);
		}
	}

	public void IncreaseSocializerScore()
	{
		socialScore += killerScoreAdd;   //killer score add is just the ratio of the enemies don't mind the name :P
	}

	public void DecreaseSocializerScore()
	{
		socialScore -= killerScoreAdd;   //killer score add is just the ratio of the enemies don't mind the name :P
	}
	
	public void InreaseKillScore()
	{
		killerScore +=killerScoreAdd;
	}
	public void IncreaseAchieverScore()
	{
		achieverScore += achieverScoreAdd;
	}

	public void IncreaseExplorerScore()
	{
		explorerScore += explorerScoreAdd;
	}

	public int CalcTotalScore()
	{
		totalScore = (int)(killerScore + socialScore + achieverScore + explorerScore);
		return totalScore;
	}
	public void SubmitHighscore(string userName)         //Check if there is a username or not and apply score properly then save locally
	{
		if(!highscoreDictionary.ContainsKey(userName))
		{
			highscore = totalScore;
			highscoreDictionary.Add(userName,(int)highscore);
			SaveHighscore();
			return;
		}
		if(totalScore > highscore)
		{
			highscore = totalScore;
			highscoreDictionary[userName] = (int)highscore;
			SaveHighscore();
		}
	}

	private void SaveHighscore()
	{
		highscoreArray = HighScoreDictionaryToArray(highscoreDictionary);
		SaveLoadScript.Save(this,"test");
	}
	
	public HighscoreData[] HighScoreDictionaryToArray(Dictionary<string,int> dictionaryToSerialize)   //Returns An array from dictionary
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

	public Dictionary<string, int> HighScoreDictionaryFromArray(HighscoreData[] arrayOfData)    //Returns a dictionary from the array
	{
		Dictionary<string, int> dictionaryToReturn = new Dictionary<string, int>();
		
		for (int i = 0; i < arrayOfData.Length ; i++)
		{
			dictionaryToReturn.Add(arrayOfData[i].name,arrayOfData[i].score);
		}
		return dictionaryToReturn;
	}

	public float KillerScore
	{
		get { return killerScore; }
		set { killerScore = value; }
	}

	public float AchieverScore
	{
		get { return achieverScore; }
		set { achieverScore = value; }
	}

	public float ExplorerScore
	{
		get { return explorerScore; }
		set { explorerScore = value; }
	}

	public float SocialScore
	{
		get { return socialScore; }
		set { socialScore = value; }
	}
}
