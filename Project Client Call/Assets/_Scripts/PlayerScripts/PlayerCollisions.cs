using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollisions : MonoBehaviour
{

	[SerializeField] 
	private GameObject resolutionScreen;
	
	private Camera mainCam;

	private Health health;
	
	private void Start()
	{
		mainCam = Camera.main;
		health = GetComponentInParent<Health>();
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.transform.CompareTag("Spikes"))
		{
			health.InflictDamage(100);
		}
		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.transform.CompareTag("DeathFall"))
		{
			health.InflictDamage(100);
		}
		
		if (other.CompareTag("ExplorerRoom"))
		{
			other.GetComponent<ExplorerRooms>().ExploreRoom();
		}

		if (other.CompareTag("EndTrigger"))
		{
			GetComponentInParent<PlayerMovement>().enabled = false;
			GetComponentInParent<Rigidbody2D>().velocity = Vector2.zero;
			resolutionScreen.SetActive(true);
			
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("ArenaExitTrigger"))
		{
			if (transform.position.x > other.transform.position.x + .2f)
			{
				mainCam.GetComponent<CameraFollowPlayer>().EnterNormalMode(other.transform);
				other.isTrigger = false;
			}
			
		}
		if (other.CompareTag("ArenaEnterTrigger"))
		{
			if (transform.position.x > other.transform.position.x + .2f)
			{
				mainCam.GetComponent<CameraFollowPlayer>().EnterArenaMode(other.transform);
				other.isTrigger = false;
			}
		}

	}

}
