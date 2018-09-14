using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorerRooms : MonoBehaviour
{

	[SerializeField] 
	private HighScoreManager highScoreManager;
	
	private bool isVisited = false;

	

	public void ExploreRoom()
	{
		if (!isVisited)
		{
			isVisited = true;
		}
	}
}
