using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{

	private PlayerMovement playerMovement;
	private PlayerData playerData;
	private Rigidbody2D rb;
	
	[SerializeField]
	private Animator animator;
	
	// Use this for initialization
	void Start ()
	{
		playerMovement = GetComponent<PlayerMovement>();
		playerData = GetComponent<PlayerData>();
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	public void SetWalkingSpeedAnim(float speed)
	{
		animator.SetFloat("Speed", speed);
	}

	public void SetJumpingToTrue()
	{
		animator.SetBool("IsJumping",true);
	}
	
	public void SetJumpingToFalse()
	{
		animator.SetBool("IsJumping",false);
	}

	public void PlayJumpAgain()
	{
		animator.Play("PlayerJumpAnim",-1,0);
	}
}
