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
		PlayerAnimationHandler.PlayerAnimHandler += EndSwoshing;
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

	public void EndSwoshing(PlayerAnimationHandler sender)
	{
		animator.SetBool("SwoshTest",false);
	}

    public void SetIsDead()
    {
        animator.SetTrigger("isDead");
    }
    public void SetAttack()
    {
        animator.SetTrigger("MeleeAttack");
    }

    private void OnDestroy()
	{
		PlayerAnimationHandler.PlayerAnimHandler -= EndSwoshing;
	}

	public void Swoosh()
	{
		animator.SetBool("SwoshTest",true);
	}
}
