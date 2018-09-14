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

	private float targetGravity;

	private Vector2 smoothedVec;
	
	private PlayerAnimations playerAnimations;
	
	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		playerData = GetComponent<PlayerData>();
		playerAnimations = GetComponent<PlayerAnimations>();
		
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
		RepeatSecondJumpAnim();  // Checks if needed to repeat second jump anim  
		Jump();  //Jump is in update, just trust me works better :P
	}

	private void Jump()
	{
		isGrounded = Physics2D.OverlapCircle(feetPos.position,checkGroundRadius,whatIsGround);  //Check if we touched the ground
		
		if(isGrounded) playerAnimations.SetJumpingToFalse();
		else
		{
			playerAnimations.SetJumpingToTrue();
		}
		
		if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button5)) && jumpCount > 1)  //jump
		{
			
			jumpCount -= 1;  		//decrease the count so  we can't jump forever
			
			//rb.velocity = Vector2.up * playerData.JumpSpeed;
			
			CalculateJump(playerData.FirstJumpValues.jumpHeight,playerData.FirstJumpValues.jumpCompletionTime);
			rb.velocity = Vector2.up * playerData.JumpSpeed;

		}
		
		if (isGrounded && jumpCount != 2)   //If we grounded then set jump count back to 0
		{
			//CalculateJump(playerData.FirstJumpValues.jumpHeight,playerData.FirstJumpValues.jumpCompletionTime);  //NOTE : Check to remove or not
			jumpCount = 2;
			rb.gravityScale = 1;
			
		}

		if (jumpCount == 1 && isGrounded == false)  //Check if we are in second jump and decrease speed
		{
			if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button5))
			{
				CalculateJump(playerData.SecondJumpValues.jumpHeight + playerData.FirstJumpValues.jumpHeight, playerData.SecondJumpValues.jumpCompletionTime +  playerData.FirstJumpValues.jumpCompletionTime);
				rb.velocity = Vector2.up * playerData.JumpSpeed;
				jumpCount -= 1;
			}
			/*playerData.JumpSpeed = playerData.SecondJumpSpeed;*/
		} 
		else playerData.JumpSpeed = initialJumpSpeed;   //else set it back

		//Apply the multipliers for a better jump
		if (rb.velocity.y < 0)                       //Check if we are falling
		{
			rb.velocity += Vector2.up * (fallMultiplier - 1) * Physics2D.gravity * Time.deltaTime;  //apply fall multiplier
																									//make it negative if you want a slower fall
		}
		else if (rb.velocity.y > 0 && !(Input.GetKey(KeyCode.Space)||Input.GetKeyDown(KeyCode.Joystick1Button5)))  //check if we jumping but button is pressed easily
		{
			rb.velocity += Vector2.up * (lowJumpMultiplier - 1) * Physics2D.gravity * Time.deltaTime;   //apply low jump multiplier
		}
	}
	

	public void ResetMovementSpeed()
	{
		playerData.MovementSpeed = inititalMovementSpeed;
	}

	private void MoveHorizontally()
	{
		float horizontal = Input.GetAxis("Horizontal");
		playerAnimations.SetWalkingSpeedAnim(Mathf.Abs(horizontal));
		//rb.velocity = new Vector2(horizontal * playerData.MovementSpeed * Time.fixedDeltaTime, rb.velocity.y);  //Move horizontally

		float targetVelocity =
			horizontal * playerData.MovementSpeed * Time.fixedDeltaTime;
		
		//apply smoothing
		rb.velocity = Vector2.Lerp(rb.velocity,new Vector2(targetVelocity,rb.velocity.y), ((isGrounded)? playerData.GroundedSmoothedVelocity:playerData.AirborneSmoothedVelocity) * Time.fixedDeltaTime);
		
		CheckFlipHorizontally();  //basic flip
	}

	public void CalculateJump(float pJumpHeight,float pJumpTime)   //Calculates gravity scale and the speed automatically just by giving the time and height of the jump
	{
		targetGravity = -((2 * pJumpHeight)) / Mathf.Pow(pJumpTime, 2);   //calculate the right gravity for our jump
		
		rb.gravityScale = targetGravity / Physics2D.gravity.y;   // set the gravity scale depending on our target gravity
			
		playerData.JumpSpeed = (Mathf.Abs(targetGravity) * pJumpTime);  // find our final speed based on the time and gravity of the jump
			
	}

	public void CheckFlipHorizontally()
	{
		if (rb.velocity.x < 0 && transform.right.Equals(initForwardVec))  //flip only if we haven't already flipped :P
		{
			transform.right = -transform.right;
		}
		else if(rb.velocity.x > 0 && !transform.right.Equals(initForwardVec))
		{
			transform.right = -transform.right;
		}
	}

	private void RepeatSecondJumpAnim()
	{
		if (isGrounded == false && jumpCount ==2  && (Input.GetKeyDown(KeyCode.Space) ||  (Input.GetKeyDown(KeyCode.Joystick1Button5))))
		{
			playerAnimations.PlayJumpAgain();
		}
	}
}
