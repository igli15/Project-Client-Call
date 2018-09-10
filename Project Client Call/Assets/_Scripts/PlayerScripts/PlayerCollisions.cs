using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollisions : MonoBehaviour
{

	private Camera mainCam;
	
	private void Start()
	{
		mainCam = Camera.main;
	}

	/*private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("ArenaExitTrigger"))
		{
			mainCam.GetComponent<CameraFsmController>().fsm.ChangeState<CameraFollowPlayerState>();
		
		}
		if (other.CompareTag("ArenaEnterTrigger"))
		{
			mainCam.GetComponent<CameraFsmController>().fsm.ChangeState<CameraArenaState>();
		}
	}*/
	
	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("ArenaExitTrigger"))
		{
			if (transform.position.x > other.transform.position.x + .2f)
			{
				mainCam.GetComponent<CameraFsmController>().fsm.ChangeState<CameraFollowPlayerState>();
				other.isTrigger = false;
			}
			
		}
		if (other.CompareTag("ArenaEnterTrigger"))
		{
			if (transform.position.x > other.transform.position.x + .2f)
			{
				mainCam.GetComponent<CameraFsmController>().fsm.ChangeState<CameraArenaState>();
				other.isTrigger = false;
			}
		}
	}

}
