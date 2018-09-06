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

	private bool init = false;
	// Use this for initialization
	void Start ()
	{
	
		
	}

	public override void Enter(IAgent pAgent)
	{
		base.Enter(pAgent);
		init = false;
		
		if (targetToFollow.transform.position.x >= transform.position.x && !init)
		{

			Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
			transform.DOLocalMoveX((transform.position.x + (targetToFollow.transform.position.x - transform.position.x)) + (targetToFollow.position.x -stageDimensions.x - 0.5f),0.2f);			

			init = true;
			Invoke("InvokeFollowPlayer",1.5f);
		}
	}

	private void LateUpdate()
	{
		if (targetToFollow.transform.position.x >= transform.position.x && !init)
		{
			offset = transform.position - targetToFollow.position;
			followPlayer = true;
			init = true;

		}

		if (followPlayer)
		{
			float desiredPos = targetToFollow.position.x + offset.x;

			Vector3 smoothedPos = Vector3.Lerp(transform.position,
				new Vector3(desiredPos, transform.position.y, transform.position.z),
				smoothedSpeed * Time.deltaTime);

			transform.position = smoothedPos;
		}
		
		
	}

	private void InvokeFollowPlayer()
	{
		offset = Vector3.zero;
		offset = transform.position - targetToFollow.position;
		followPlayer = true;
	}

	public override void Exit(IAgent pAgent)
	{
		base.Exit(pAgent);
		followPlayer = false;
		init = false;
	}
}
