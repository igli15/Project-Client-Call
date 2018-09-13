using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

public static class SaveLoadScript 
{
	
	[Serializable]
	public class HighscoreData
	{
		public string name;
		public int score;
	}

	[Serializable]
	public class HighScoreArray
	{
		public HighscoreData[] highscoreArray;
	}
	
	
	public static void Save(object objToSave,string saveFileName)
	{
		var data = JsonUtility.ToJson(objToSave, true);
		File.WriteAllText(Application.persistentDataPath + "/"+ saveFileName + ".json", Encryption.Encrypt(data));
		Debug.Log(Encryption.Encrypt(data));
		
	}
    
	public static void Load(object objToLoad,string fileNameToLoadFrom)
	{
		if (File.Exists(Application.persistentDataPath + "/"+ fileNameToLoadFrom + ".json"))
		{
			var loadedData = Encryption.Decrypt(File.ReadAllText(Application.persistentDataPath + "/"+ fileNameToLoadFrom + ".json"));

			JsonUtility.FromJsonOverwrite(loadedData, objToLoad);
			
			Debug.Log(loadedData);
		}
	}

	public static HighScoreArray HighScoreDictionaryToArray(Dictionary<string,int> dictionaryToSerialize)
	{
		List<HighscoreData> highscoreDataList = new List<HighscoreData>();

		foreach (KeyValuePair<string,int> pairs in dictionaryToSerialize)
		{
			HighscoreData highscoreData = new HighscoreData();
			highscoreData.name = pairs.Key;
			highscoreData.score = pairs.Value;
			highscoreDataList.Add(highscoreData);
		}
		
		HighScoreArray highScoreArray = new HighScoreArray();
		highScoreArray.highscoreArray = highscoreDataList.ToArray();
		return highScoreArray;
	}

	public static Dictionary<string, int> HighScoreDictionaryFromArray(HighScoreArray highScoreArray)
	{
		Dictionary<string, int> dictionaryToReturn = new Dictionary<string, int>();
		
		for (int i = 0; i < highScoreArray.highscoreArray.Length ; i++)
		{
				dictionaryToReturn.Add(highScoreArray.highscoreArray[i].name,highScoreArray.highscoreArray[i].score);
		}
		return dictionaryToReturn;
	}
}
