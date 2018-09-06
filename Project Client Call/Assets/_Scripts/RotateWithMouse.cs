using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithMouse : MonoBehaviour
{
	private Rigidbody2D rb;

	[SerializeField]
	private float radiusOfRotation = 1;

	[SerializeField] 
	private Transform target;

	[SerializeField] 
	private GameObject swordCollider;

	[HideInInspector]
	public Vector3 initialDistanceFromPlayer;

	private Vector2 dir;

	private bool joystickUsed = false;

	[SerializeField]
	private bool useController = true;

	// Use this for initialization
	void Start ()
	{
		//initialDistanceFromPlayer = transform.position - target.transform.position;
		rb = GetComponent<Rigidbody2D>();

		dir = Vector2FromAngle(0);
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

		dir *= radiusOfRotation;
		transform.position = target.position + new Vector3(dir.x,dir.y,0);
		transform.right = dir.normalized;

		
	}

	public void CheckForControllerInput()
	{
		float verticalPos = Input.GetAxis("VerticalJoy");
		float horizontalPos = Input.GetAxis("HorizontalJoy");
		
		Vector2 joyPos = new Vector2(horizontalPos,verticalPos);

		float angle = Mathf.Atan2(verticalPos, horizontalPos) * Mathf.Rad2Deg;


		if (joyPos.magnitude > 0.2f)
		{
			//joystickUsed = true;
			dir = Vector2FromAngle(angle);
			if(swordCollider.activeSelf == false) swordCollider.SetActive(true);
		}
		else
		{
			swordCollider.SetActive(false);
		}
		
		
	}
	
	
	
	public Vector2 Vector2FromAngle(float a)
	{
		a *= Mathf.Deg2Rad;
		return new Vector2(Mathf.Cos(a), Mathf.Sin(a));
	}

	public void CheckForJoyStickInput()
	{
		if (Input.GetKey(KeyCode.D))
		{
			dir = Vector2FromAngle(0).normalized;
			joystickUsed = true;
			if(swordCollider.activeSelf == false) swordCollider.SetActive(true);
		}
		else if (Input.GetKey(KeyCode.E))
		{
			dir = Vector2FromAngle(45).normalized;
			joystickUsed = true;
			if(swordCollider.activeSelf == false) swordCollider.SetActive(true);
		}
		else if (Input.GetKey(KeyCode.W))
		{
			dir = Vector2FromAngle(90).normalized;
			joystickUsed = true;
			if(swordCollider.activeSelf == false) swordCollider.SetActive(true);
		}
		else if (Input.GetKey(KeyCode.Q))
		{
			dir = Vector2FromAngle(135).normalized;
			joystickUsed = true;
			if(swordCollider.activeSelf == false) swordCollider.SetActive(true);
		}
		else if (Input.GetKey(KeyCode.A))
		{
			dir = Vector2FromAngle(180).normalized;
			joystickUsed = true;
			if(swordCollider.activeSelf == false) swordCollider.SetActive(true);
		}
		else if (Input.GetKey(KeyCode.Z))
		{
			dir = Vector2FromAngle(225).normalized;
			joystickUsed = true;
			if(swordCollider.activeSelf == false) swordCollider.SetActive(true);
		}

		else if (Input.GetKey(KeyCode.X))
		{
			dir = Vector2FromAngle(270).normalized;
			joystickUsed = true;
			if(swordCollider.activeSelf == false) swordCollider.SetActive(true);
		}
		else if (Input.GetKey(KeyCode.C))
		{
			dir = Vector2FromAngle(315).normalized;
			joystickUsed = true;
			if(swordCollider.activeSelf == false) swordCollider.SetActive(true);
		}
		else if (joystickUsed == false)
		{
			dir = Vector2FromAngle(0).normalized;
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
