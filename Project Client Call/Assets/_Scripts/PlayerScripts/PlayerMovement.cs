using System.Collections;
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

	[SerializeField]
	private int jumpCount = 2;

	[SerializeField] 
	private float swordSprite;
	
	private PlayerData playerData;
	private Rigidbody2D rb;
	private bool isGrounded;

	private float inititalMovementSpeed;

	private Vector3 initForwardVec;

	private float initialJumpSpeed;


	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		playerData = GetComponent<PlayerData>();
		
		inititalMovementSpeed = playerData.MovementSpeed;

		initForwardVec = transform.right;

		initialJumpSpeed = playerData.JumpSpeed;
	}
	
	

	private void FixedUpdate()
	{
		MoveHorizontally();
	}

	private void Update()
	{
		Jump();
	}

	private void Jump()
	{
		isGrounded = Physics2D.OverlapCircle(feetPos.position,checkGroundRadius,whatIsGround);
		
		if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button5)) && jumpCount > 1)
		{
			jumpCount -= 1;
			rb.velocity = Vector2.up * playerData.JumpSpeed;
		}
		
		if (isGrounded && jumpCount != 2)
		{
			jumpCount = 2;
		}

		if (jumpCount == 2 && isGrounded == false) playerData.JumpSpeed = playerData.SecondJumpSpeed;  //Check if we are in second jump and decrease speed
		else playerData.JumpSpeed = initialJumpSpeed;   //else set it back

		if (rb.velocity.y < 0)
		{
			rb.velocity += Vector2.up * (fallMultiplier - 1) * Physics2D.gravity * Time.deltaTime;
		}
		else if (rb.velocity.y > 0 && !(Input.GetKey(KeyCode.Space)||Input.GetKeyDown(KeyCode.Joystick1Button5)))
		{
			rb.velocity += Vector2.up * (lowJumpMultiplier - 1) * Physics2D.gravity * Time.deltaTime;
		}
	}
	

	public void ResetMovementSpeed()
	{
		playerData.MovementSpeed = inititalMovementSpeed;
	}

	private void MoveHorizontally()
	{
		float _horizontal = Input.GetAxis("Horizontal");
		rb.velocity = new Vector2(_horizontal * playerData.MovementSpeed * Time.fixedDeltaTime, rb.velocity.y);
		
		CheckFlipHorizontally();
	}

	public void CheckFlipHorizontally()
	{
		if (rb.velocity.x < 0 && transform.right.Equals(initForwardVec))
		{
			transform.right = -transform.right;
		
		}
		else if(rb.velocity.x > 0 && !transform.right.Equals(initForwardVec))
		{
			transform.right = -transform.right;
		}
	}

}
