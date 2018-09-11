using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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
				mainCam.GetComponent<CameraFollowPlayerState>().EnterNormalMode(other.transform);
				other.isTrigger = false;
			}
			
		}
		if (other.CompareTag("ArenaEnterTrigger"))
		{
			if (transform.position.x > other.transform.position.x + .2f)
			{
				mainCam.GetComponent<CameraFollowPlayerState>().EnterArenaMode(other.transform);
				
				other.isTrigger = false;
			}
		}
	}

}
