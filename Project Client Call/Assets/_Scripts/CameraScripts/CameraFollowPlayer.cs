using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;


public class CameraFollowPlayer : MonoBehaviour
{

	[SerializeField] 
	private Transform targetToFollow;

	[SerializeField] 
	private float smoothedSpeed = 10f;

	[SerializeField] 
	private float cameraYOffset = 2.5f;

	private Vector3 offset;

	private bool followPlayer = false;

	private bool movingToTarget = false;

	private bool startCheckingForPlayer = false;


	private float desiredPosY;

	private Camera cam;

	private float screenWidth;

	private void Start()
	{
		movingToTarget = false;
		cam = Camera.main;
		screenWidth =
			Utils.GetPerspectiveCameraDimensions(Vector3.Distance(transform.position, targetToFollow.position), cam).x;

	}

	private void LateUpdate()
	{
		if (targetToFollow.transform.position.x >= transform.position.x && !movingToTarget)  //check if in the middle or more to the right..
		{
			offset = transform.position - targetToFollow.position;  //Get the right offset from the target to the camera
			
			followPlayer = true;
			startCheckingForPlayer = true;  //Start checking for 
			movingToTarget = true; //just so we do this once
		}

		if (startCheckingForPlayer && targetToFollow.transform.position.x > transform.position.x)
		{
			followPlayer = true;
			startCheckingForPlayer = false;
		}
		

		desiredPosY  = targetToFollow.position.y + cameraYOffset;
		
		
		StartFollowingPlayer();
		
		
	}

	private void Update()
	{
		RaycastBorders();
	}

	public void StartFollowingPlayer()
	{
		float desiredPos = transform.position.x;
		if (followPlayer)
		{
			 desiredPos = targetToFollow.position.x + offset.x;
		}


		Vector3 smoothedPos = Vector3.Lerp(transform.position,
			new Vector3(desiredPos, desiredPosY, transform.position.z),
			smoothedSpeed * Time.deltaTime);
		
		transform.position = smoothedPos;
		
	}
 
	public void RaycastBorders()   //Ray casts from the left border of the camera to a point in screen to check weather there is a "Trigger"
	{							   //If there is a trigger then it stops following player.
		
		//Ray ray = cam.ScreenPointToRay(new Vector3(0,0.2f,0));

		//RaycastHit2D hit = Physics2D.Raycast(ray.origin - new Vector3(cameraBorderOffset,0,0),ray.direction);

		RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x - screenWidth/2,transform.position.y),transform.forward * 10000 );

		if (hit)
		{
			if ((hit.transform.CompareTag("ArenaExitTrigger") || hit.transform.CompareTag("ArenaEnterTrigger")) && !transform.right.Equals(targetToFollow.transform.right))
			{
				Debug.Log("Hit");
				followPlayer = false;
				movingToTarget = false;
			}
		}

	}


	public void EnterArenaMode(Transform triggerPos)
	{
		followPlayer = false;
		Sequence sequence = DOTween.Sequence();
		sequence.Append(
			cam.transform.DOMoveX(transform.position.x + Mathf.Abs(triggerPos.transform.position.x - cam.transform.position.x) + screenWidth/2,0.4f));
			
		sequence.Append(cam.transform.DOMoveZ(cam.transform.position.z - 4, 0.2f));
		
		sequence.Append(DOVirtual.DelayedCall(1f, () => movingToTarget = false));
	}

	public void EnterNormalMode(Transform triggerPos)
	{
		followPlayer = false;
		Sequence sequence = DOTween.Sequence();
		sequence.Append(
			cam.transform.DOMoveX(transform.position.x + Mathf.Abs(triggerPos.transform.position.x - cam.transform.position.x) + screenWidth/2,0.4f));
		
		sequence.Append(cam.transform.DOMoveZ(cam.transform.position.z + 4, 0.2f));
		
		sequence.Append(DOVirtual.DelayedCall(1f, () => movingToTarget = false));

	}
}
