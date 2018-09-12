using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager : MonoBehaviour {

	Dictionary<string,int> highscore = new Dictionary<string,int>();
	private int killerScore;
	private int achieverScore;
	private int explorerScore;
	private int socialScore;
	private int totalScore;
	private int totalEnemyNumber;
	private int totalRoomNumbers;
	
	private float killerScoreAdd;

	private int collectableNumber;

	private int collectableScoreAdd;
	void Start () 
	{
		totalEnemyNumber = GameObject.FindGameObjectsWithTag("Enemy").Length;
		killerScoreAdd = 2500000/totalEnemyNumber;
		totalScore = 250000;
		totalRoomNumbers = GameObject.FindGameObjectsWithTag("Room").Length;
		collectableNumber = GameObject.FindGameObjectsWithTag("Collectable").Length;
		collectableScoreAdd = 250000/collectableNumber;

	}
	
	// Update is called once per frame
	void Update () 
	{
		
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

}
