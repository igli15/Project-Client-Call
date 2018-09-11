using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{

	
	[SerializeField]
	private Animator animator;
	
	// Use this for initialization
	void Start ()
	{
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
