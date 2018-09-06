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
	
	// Use this for initialization
	void Start ()
	{
		offset = transform.position - target.position;
	}

	private void LateUpdate()
	{
		/*Vector3 desiredPos = target.position + offset;

		Vector3 smoothedPos  = Vector3.Lerp(transform.position, desiredPos, smoothedSpeed * Time.deltaTime);*/
		
		float desiredPos = target.position.x + offset.x;

		Vector3 smoothedPos  = Vector3.Lerp(transform.position, new Vector3(desiredPos,transform.position.y,transform.position.z), 
			smoothedSpeed * Time.deltaTime);

		transform.position = smoothedPos;
		
	}
}
