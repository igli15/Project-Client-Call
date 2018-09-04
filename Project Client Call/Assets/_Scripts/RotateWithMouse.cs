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

	// Use this for initialization
	void Start ()
	{
		initialDistanceFromPlayer = transform.position - transform.parent.position;
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		Vector2 distanceFromMouse = Input.mousePosition - Camera.main.WorldToScreenPoint(target.position);
		
		Vector2 dir = distanceFromMouse.normalized * radiusOfRotation;
	
		transform.position = target.position + new Vector3(dir.x,dir.y,0);

		//LookAt2D(transform,dir,transform.right); //Quaternion.FromToRotation(Vector3.right, distanceFromMouse);
		transform.right = dir.normalized;


	}
	
	
	
	public void LookAt2D(Transform transform,Vector2 dir,Vector3 axis)
	{
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		
		transform.rotation = Quaternion.AngleAxis(angle, axis);
	}
	
	
}
