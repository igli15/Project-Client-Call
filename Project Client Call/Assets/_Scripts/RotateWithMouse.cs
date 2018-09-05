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

	[HideInInspector]
	public Vector3 initialDistanceFromPlayer;

	private Vector2 dir;

	// Use this for initialization
	void Start ()
	{
		initialDistanceFromPlayer = transform.position - transform.parent.position;
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

		if (Input.GetKeyDown(KeyCode.D))
		{
			dir = Vector2FromAngle(0).normalized;
		}
		else if (Input.GetKeyDown(KeyCode.E))
		{
			dir = Vector2FromAngle(45).normalized;
		}
		else if (Input.GetKeyDown(KeyCode.W))
		{
			dir = Vector2FromAngle(90).normalized;
		}
		else if (Input.GetKeyDown(KeyCode.Q))
		{
			dir = Vector2FromAngle(135).normalized;
		}
		else if (Input.GetKeyDown(KeyCode.A))
		{
			dir = Vector2FromAngle(180).normalized;
		}
		else if (Input.GetKeyDown(KeyCode.Z))
		{
			dir = Vector2FromAngle(225).normalized;
		}

		else if (Input.GetKeyDown(KeyCode.X))
		{
			dir = Vector2FromAngle(270).normalized;
		}
		else if (Input.GetKeyDown(KeyCode.C))
		{
			dir = Vector2FromAngle(315).normalized;
		}

		dir *= radiusOfRotation;
		transform.position = target.position + new Vector3(dir.x,dir.y,0);
		transform.right = dir.normalized;

		
	}
	
	
	
	public Vector2 Vector2FromAngle(float a)
	{
		a *= Mathf.Deg2Rad;
		return new Vector2(Mathf.Cos(a), Mathf.Sin(a));
	}
	
	
}
