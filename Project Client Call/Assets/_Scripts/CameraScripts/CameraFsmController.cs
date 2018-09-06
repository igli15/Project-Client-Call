using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFsmController : MonoBehaviour,IAgent
{

	[HideInInspector] 
	public Fsm<CameraFsmController> fsm;
	
	// Use this for initialization
	void Start () 
	{
		fsm = new Fsm<CameraFsmController>(this);
	}

	public void GoToArenaMode()
	{
		
	}

	public void GoToFollowPlayerMode()
	{
		
	}
}
