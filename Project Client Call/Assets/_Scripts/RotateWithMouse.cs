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
		
		/*Vector2 distanceFromMouse = Input.mousePosition - Camera.main.WorldToScreenPoint(target.position);
		
		Vector2 dir = distanceFromMouse.normalized * radiusOfRotation;
	
		transform.position = target.position + new Vector3(dir.x,dir.y,0);

		
		transform.right = dir.normalized;*/
		 /*Vector2FromAngle(45).normalized * radiusOfRotation;*/

		CheckForJoyStickInput();

		dir *= radiusOfRotation;
		transform.position = target.position + new Vector3(dir.x,dir.y,0);
		transform.right = dir.normalized;

		
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
	
	
}
