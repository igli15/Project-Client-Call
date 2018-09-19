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
			HighScoreManager.instance.IncreaseExplorerScore();
			isVisited = true;
		}
	}
}
