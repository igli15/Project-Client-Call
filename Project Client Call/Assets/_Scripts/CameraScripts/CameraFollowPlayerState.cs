using UnityEngine;
using System.Collections;
using System.Collections.Generic;


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
	}

	private void LateUpdate()
	{
		if (targetToFollow.transform.position.x >= transform.position.x && !init)
		{
			followPlayer = true;
			offset = transform.position - targetToFollow.position;
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

	public override void Exit(IAgent pAgent)
	{
		base.Exit(pAgent);
	}
}
