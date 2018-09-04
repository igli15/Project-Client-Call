using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithMouse : MonoBehaviour
{
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		

		

		Vector2 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);


		transform.position = dir.normalized;

	}
	
	
	
}
