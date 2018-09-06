using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
	[SerializeField] 
	private Transform target;

	[SerializeField] 
	private float smoothedSpeed = 10f;

	private Vector3 offset;

	private Camera camera;

	private bool followPlayer = false;

	private bool init = false;
	// Use this for initialization
	void Start ()
	{
	
		camera = GetComponent<Camera>();
		init = false;
	}

	private void LateUpdate()
	{

		if (target.transform.position.x >= transform.position.x && !init)
		{
			followPlayer = true;
			offset = transform.position - target.position;
			init = true;

		}

		if (followPlayer)
		{
			float desiredPos = target.position.x + offset.x;

			Vector3 smoothedPos = Vector3.Lerp(transform.position,
			new Vector3(desiredPos, transform.position.y, transform.position.z),
			smoothedSpeed * Time.deltaTime);

			transform.position = smoothedPos;
		}
		
		
	}
}
