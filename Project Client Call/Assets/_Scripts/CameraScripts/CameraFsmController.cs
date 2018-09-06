using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFsmController : MonoBehaviour,IAgent
{

	[HideInInspector] 
	public Fsm<CameraFsmController> fsm;
	
	// Use this for initialization
	private void Awake()
	{
		if (fsm == null)
		{
			fsm = new Fsm<CameraFsmController>(this);
		}
	
	}


	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.G))
		{
			GoToArenaMode();
		}
		if (Input.GetKeyDown(KeyCode.H))
		{
			GoToFollowPlayerMode();
		}
	}

	void Start () 
	{
		GoToFollowPlayerMode();
	}

	public void GoToArenaMode()
	{
		fsm.ChangeState<CameraArenaState>();
	}

	public void GoToFollowPlayerMode()
	{
		fsm.ChangeState<CameraFollowPlayerState>();
		
	}
}
