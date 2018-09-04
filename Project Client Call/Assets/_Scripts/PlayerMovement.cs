﻿using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

//Needs to use playerdata values....
[RequireComponent(typeof(PlayerData))]


public class PlayerMovement : MonoBehaviour
{

	[SerializeField]
	private float fallMultiplier = 2.5f;

	[SerializeField] 
	private float lowJumpMultiplier = 2f;
	
	[SerializeField] 
	private Transform feetPos;

	[SerializeField] 
	private LayerMask whatIsGround;
	
	[SerializeField] 
	private float checkGroundRadius;
	
	private PlayerData playerData;
	private Rigidbody2D rb;
	private bool isGrounded;


	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		playerData = GetComponent<PlayerData>();
	}
	
	

	private void FixedUpdate()
	{
		float _horizontal = Input.GetAxis("Horizontal");
		rb.velocity = new Vector2(_horizontal * playerData.MovementSpeed() * Time.fixedDeltaTime, rb.velocity.y); 
		
		
		if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
		{
			rb.velocity = Vector2.up * playerData.JumpSpeed();
		}
	
		

	}

	private void Update()
	{
		isGrounded = Physics2D.OverlapCircle(feetPos.position,checkGroundRadius,whatIsGround);
	}
}
