using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{

	private Camera mainCam;
	
	private void Start()
	{
		mainCam = Camera.main;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("ArenaExitTrigger"))
		{
			mainCam.GetComponent<CameraFsmController>().fsm.ChangeState<CameraFollowPlayerState>();
		}
		if (other.CompareTag("ArenaEnterTrigger"))
		{
			mainCam.GetComponent<CameraFsmController>().fsm.ChangeState<CameraArenaState>();
		}
	}
}
