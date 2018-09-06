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

	private Vector3 offset;

	private bool followPlayer = false;

	private bool movingToTarget = false;

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

	private void SetMovingToTargetFalse()
	{
		movingToTarget = false;
	}

	public override void Exit(IAgent pAgent)
	{
		base.Exit(pAgent);
		followPlayer = false;
		movingToTarget = false;
	}

	public void FindRightPosBehindTarget()
	{
		if (targetToFollow.transform.position.x >= transform.position.x && !movingToTarget)
		{

			Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));  //get stage dimensions
			
			transform.DOLocalMoveX((transform.position.x + 
			                        (targetToFollow.transform.position.x - transform.position.x)) 
			                       + (targetToFollow.position.x -stageDimensions.x - 1.5f),0.2f);	 // move behind target		

			movingToTarget = true; //So we don't overlap tweens
			
			Invoke("SetMovingToTargetFalse",1.5f);    //We want to check again but only after the tweener has finished 
													 //So that animations/Tweens do not overlap.
		}
	}

	public void StartFollowingPlayer()
	{
		float desiredPos = targetToFollow.position.x + offset.x;

		Vector3 smoothedPos = Vector3.Lerp(transform.position,
			new Vector3(desiredPos, transform.position.y, transform.position.z),
			smoothedSpeed * Time.deltaTime);

		transform.position = smoothedPos;
	}
}
