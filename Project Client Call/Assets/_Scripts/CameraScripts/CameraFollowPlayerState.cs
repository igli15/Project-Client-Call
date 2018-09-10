using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;


public class CameraFollowPlayerState : AbstractState<CameraFsmController>
{

	[SerializeField] 
	private Transform targetToFollow;

	[SerializeField] 
	private float smoothedSpeed = 10f;

	[SerializeField] 
	private float cameraBorderOffset = 1.8f;

	[SerializeField] 
	private float cameraMovementOffset = 1.5f;

	private Vector3 offset;

	private bool followPlayer = false;

	private bool movingToTarget = false;

	private Camera cam;

	private void Start()
	{
		cam = Camera.main;
	}

	public override void Enter(IAgent pAgent)
	{
		base.Enter(pAgent);
		movingToTarget = false;
		FindRightPosBehindTarget();
	}

	private void LateUpdate()
	{
		if (targetToFollow.transform.position.x >= transform.position.x && !movingToTarget)  //check if in the middle or more to the right..
		{
			offset = transform.position - targetToFollow.position;  //Get the right offset from the target to the camera
			
			followPlayer = true;
			movingToTarget = true; //just so we do this once
		}

		if (followPlayer)
		{
			StartFollowingPlayer();
		}
		
	}

	private void Update()
	{
		RaycastBorders();
	}

	private void SetMovingToTargetFalse()
	{
		movingToTarget = false;
	}

	public void FindRightPosBehindTarget()
	{
		if (targetToFollow.transform.position.x >= transform.position.x && !movingToTarget)
		{

			Vector3 stageDimensions = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));  //get stage dimensions
			
			transform.DOLocalMoveX((transform.position.x + 
			                        (targetToFollow.transform.position.x - transform.position.x)) 
			                       + (targetToFollow.position.x -stageDimensions.x - cameraBorderOffset),0.2f);	 // move behind target	
																												//offset helps to put the camera a but further then the player

			movingToTarget = true; //So we don't overlap tweens
			
			Invoke("SetMovingToTargetFalse",1.5f);    //We want to check again but only after the tweener has finished 
													 //So that animations/Tweens do not overlap.
		}
	}

	public void StartFollowingPlayer()
	{
		float desiredPos = targetToFollow.position.x + offset.x;
	//	float desiredPosY = targetToFollow.position.y + 0.5f;  // TODO : Add it for Y Axis

		Vector3 smoothedPos = Vector3.Lerp(transform.position,
			new Vector3(desiredPos, transform.position.y, transform.position.z),
			smoothedSpeed * Time.deltaTime);

		transform.position = smoothedPos;
	}
 
	public void RaycastBorders()   //Ray casts from the left border of the camera to a point in screen to check weather there is a "Trigger"
	{							   //If there is a trigger then it stops following player.
		
		Ray ray = cam.ScreenPointToRay(new Vector3(0,0.2f,0));

		RaycastHit2D hit = Physics2D.Raycast(ray.origin - new Vector3(cameraBorderOffset,0,0),ray.direction);

		if (hit)
		{
			if ((hit.transform.CompareTag("ArenaExitTrigger") || hit.transform.CompareTag("ArenaEnterTrigger")) && !transform.right.Equals(targetToFollow.transform.right))
			{
				followPlayer = false;
				movingToTarget = false;
			}
		}
	}

	public void MoveBackCamera(float amount,float time)
	{
		transform.DOMoveZ(transform.position.z - amount, time);
	}

	public void ResetCamera(float amount,float time)
	{
		transform.DOMoveZ(transform.position.z + amount, time);
	}
	
	public override void Exit(IAgent pAgent)
	{
		base.Exit(pAgent);
		followPlayer = false;
		movingToTarget = false;
	}
}
