﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordRotation : MonoBehaviour
{	
	[SerializeField]
	private float radiusOfRotation = 1;

	[SerializeField] 
	[Range(0.02f,0.1f)]
	private float smoothedRotationValue = .08f;

	[SerializeField] 
	private Transform target;

	[SerializeField] 
	private GameObject swordCollider;

	[HideInInspector]
	public Vector3 initialDistanceFromPlayer;

	[SerializeField]
	private bool useController = true;

	[SerializeField] 
	private Rigidbody2D playerRb;

	private SpriteRenderer spriteRenderer;
	
	private Vector2 dir;

	private bool joystickUsed = false;

	private Vector3 initialPlayerForward;

	private bool canRotate = true;

	private Vector3 smoothedPos;  //just as ref....

	private SpriteRenderer aimHudSpriteRenderer;
	

	// Use this for initialization
	void Start ()
	{
		initialPlayerForward = playerRb.transform.right;
		
		spriteRenderer = GetComponentInChildren<SpriteRenderer>();

		aimHudSpriteRenderer = GetComponent<SpriteRenderer>();
		
		dir = Utils.Vector2FromAngle(0);  //just default value.

	}
	
	// Update is called once per frame
	void Update () 
	{

		
		//CheckForJoyStickInput();
		if (useController)
		{
			CheckForControllerInput();
		}
		else
		{
			MouseInput();
		}

		if (canRotate)
		{
			dir *= radiusOfRotation;
			Vector3 targetPos = target.position + new Vector3(dir.x, dir.y, 0);
			transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref smoothedPos, smoothedRotationValue); //Added some smoothing
			transform.right = dir.normalized;
		}


	}

	public void CheckForControllerInput()
	{
		float verticalPos = Input.GetAxis("VerticalJoy");
		float horizontalPos = Input.GetAxis("HorizontalJoy");
		
		Vector2 joyPos = new Vector2(horizontalPos,verticalPos);

		float angle = Mathf.Atan2(verticalPos, horizontalPos) * Mathf.Rad2Deg;


		if (joyPos.magnitude > 0.2f)
		{
			float angleBetweenSwordAndPlayer =
				Vector3.Angle(new Vector3(joyPos.x, joyPos.y, 0), playerRb.transform.right);
			
			float angleBetweenSwordAndPlayerDown = Vector3.Angle(new Vector3(joyPos.x, joyPos.y, 0), -playerRb.transform.up);

			//if (angleBetweenSwordAndPlayer > 90) canRotate = false;   // This makes it rotate in the direction facing.
			
			if (Input.GetKeyDown(KeyCode.C))  //Just for debugging
			{
				Debug.Log(playerRb.transform.right);
				Debug.Log("Angle between player and sword collider is : " + Utils.Find360Angle(playerRb.transform.right,transform.right));
			}
			
			if (angleBetweenSwordAndPlayerDown < 60) canRotate = false;
			else canRotate = true;
			
			dir = Utils.Vector2FromAngle(angle);


			if (canRotate)							// Only compute if we can rotate
			{
				if (angle > 90 || angle < -90)    // Check if should flip Y Dir or not
				{

					if (spriteRenderer!= null)

						spriteRenderer.flipY = true;
				}
				else
				{
					if (spriteRenderer != null)
						spriteRenderer.flipY = false;
				}

				if (angleBetweenSwordAndPlayer == 0)   // If the angle is exactly 0 then we don't need to flip again, removes some artifacts 
				{
					spriteRenderer.flipY = false;
				}
			}

			if (swordCollider.activeSelf == false)
			{
				swordCollider.SetActive(true);
				aimHudSpriteRenderer.enabled = true;
			}
		}
		else
		{
			swordCollider.SetActive(false);
			aimHudSpriteRenderer.enabled = false;
		}
		
		
	}
	

	public void ArcadeMachineInputs()
	{
		if (Input.GetKey(KeyCode.D))
		{
			dir = Utils.Vector2FromAngle(0).normalized;
			joystickUsed = true;
			if(swordCollider.activeSelf == false) swordCollider.SetActive(true);
		}
		else if (Input.GetKey(KeyCode.E))
		{
			dir = Utils.Vector2FromAngle(45).normalized;
			joystickUsed = true;
			if(swordCollider.activeSelf == false) swordCollider.SetActive(true);
		}
		else if (Input.GetKey(KeyCode.W))
		{
			dir = Utils.Vector2FromAngle(90).normalized;
			joystickUsed = true;
			if(swordCollider.activeSelf == false) swordCollider.SetActive(true);
		}
		else if (Input.GetKey(KeyCode.Q))
		{
			dir = Utils.Vector2FromAngle(135).normalized;
			joystickUsed = true;
			if(swordCollider.activeSelf == false) swordCollider.SetActive(true);
		}
		else if (Input.GetKey(KeyCode.A))
		{
			dir = Utils.Vector2FromAngle(180).normalized;
			joystickUsed = true;
			if(swordCollider.activeSelf == false) swordCollider.SetActive(true);
		}
		else if (Input.GetKey(KeyCode.Z))
		{
			dir = Utils.Vector2FromAngle(225).normalized;
			joystickUsed = true;
			if(swordCollider.activeSelf == false) swordCollider.SetActive(true);
		}

		else if (Input.GetKey(KeyCode.X))
		{
			dir = Utils.Vector2FromAngle(270).normalized;
			joystickUsed = true;
			if(swordCollider.activeSelf == false) swordCollider.SetActive(true);
		}
		else if (Input.GetKey(KeyCode.C))
		{
			dir = Utils.Vector2FromAngle(315).normalized;
			joystickUsed = true;
			if(swordCollider.activeSelf == false) swordCollider.SetActive(true);
		}
		else if (joystickUsed == false)
		{
			dir = Utils.Vector2FromAngle(0).normalized;
			swordCollider.SetActive(false);
		}

		joystickUsed = false;
	}

	public void MouseInput()
	{
		Vector2 distanceFromMouse = Input.mousePosition - Camera.main.WorldToScreenPoint(target.position);
		
		 dir = distanceFromMouse.normalized * radiusOfRotation;
		
	}

}
