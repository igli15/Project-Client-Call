using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorerRooms : MonoBehaviour
{
	
	private bool isVisited = false;


	public void ExploreRoom()
	{
		if (!isVisited)
		{
			Debug.Log("HI");
			HighScoreManager.instance.IncreaseExplorerScore();
			isVisited = true;
		}
	}
}
