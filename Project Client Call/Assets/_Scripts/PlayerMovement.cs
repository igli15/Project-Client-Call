using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Needs to use playerdata values....
[RequireComponent(typeof(PlayerData))]


public class PlayerMovement : MonoBehaviour
{

	private PlayerData playerData;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		playerData = GetComponent<PlayerData>();
	}
	
	

	private void FixedUpdate()
	{
		float _horizontal = Input.GetAxis("Horizontal");
		
		Vector2 _movementVec = new Vector2(_horizontal,0); // Y is 0 for now..

		rb.velocity = _movementVec * playerData.MovementSpeed() * Time.fixedDeltaTime;
	
	}
}
