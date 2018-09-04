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
		transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition)

		transform.position = (transform.localPosition - Camera.main.ScreenToWorldPoint(Input.mousePosition)).normalized;

		

	}
	
	
	
}
