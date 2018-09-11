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
	private float cameraYOffset = 2.5f;

	[SerializeField] 
	private float cameraYBound = 6;
	
	[SerializeField] 
	private float cameraBorderOffset = 1.8f;

	private Vector3 offset;

	private bool followPlayer = false;

	private bool movingToTarget = false;

	private bool startCheckingForPlayer = false;

	private float initialYPos;
	

	private Camera cam;

	private void Start()
	{
		initialYPos = transform.position.y;
		cam = Camera.main;
	}

	public override void Enter(IAgent pAgent)
	{
		base.Enter(pAgent);
		movingToTarget = false;
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
		

		/*if (followPlayer)
		{
			StartFollowingPlayer();
		}*/
		
		StartFollowingPlayer();
	}

	private void Update()
	{
		RaycastBorders();
	}

	public void StartFollowingPlayer()
	{
		float desiredPos = transform.position.x;
		float desiredPosY = initialYPos;
		if (followPlayer)
		{
			desiredPos = targetToFollow.position.x + offset.x;
			
		}

		if (targetToFollow.transform.position.y > cameraYBound)
		{
			desiredPosY = targetToFollow.position.y + cameraYOffset;
		} 

		Vector3 smoothedPos = Vector3.Lerp(transform.position,
			new Vector3(desiredPos, desiredPosY, transform.position.z),
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


	public void EnterArenaMode(Transform triggerPos)
	{
		followPlayer = false;
		Sequence sequence = DOTween.Sequence();
		sequence.Append(
			cam.transform.DOMoveX(transform.position.x + Mathf.Abs(triggerPos.transform.position.x - cam.transform.position.x) + 5,0.4f));
			
		sequence.Append(cam.transform.DOMoveZ(cam.transform.position.z - 4, 0.2f));
		
		sequence.Append(DOVirtual.DelayedCall(1f, () => movingToTarget = false));
	}

	public void EnterNormalMode(Transform triggerPos)
	{
		followPlayer = false;
		Sequence sequence = DOTween.Sequence();
		sequence.Append(
			cam.transform.DOMoveX(transform.position.x + Mathf.Abs(triggerPos.transform.position.x - cam.transform.position.x) + 5,0.4f));
		
		sequence.Append(cam.transform.DOMoveZ(cam.transform.position.z + 4, 0.2f));
		
		sequence.Append(DOVirtual.DelayedCall(1f, () => movingToTarget = false));

	}
	
	public override void Exit(IAgent pAgent)
	{
		base.Exit(pAgent);
		followPlayer = false;
		movingToTarget = false;
	}
}
