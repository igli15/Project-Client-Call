﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour {

    [SerializeField]
    private Animator animator;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetSpeedOfEnemy(float speedOfEnemy)
    {
        animator.SetFloat("speedOfEnemy", speedOfEnemy);
    }

    public void SetAttackState(bool attackState)
    {
        animator.SetBool("AttackState", attackState);
    }

    public void TrigerShootingAnimation()
    {
        animator.SetTrigger("Shoot");
    }

    public void TrigerDeathAnimation()
    {
        animator.SetTrigger("Death");
    }

    public void TrigerOnKneeAnimation()
    {
        animator.SetTrigger("OnKnee");
    }

    public void SetDeathState(bool deathState)
    {
        animator.SetBool("DeathState", deathState);
    }
    public void SetCharge(bool charging)
    {
        Debug.Log("SET CHARGE ANIM: "+ charging);
        animator.SetBool("Charging", charging);
    }

    public void SetIdle(bool idle)
    {
        Debug.Log("SET ANIM: "+idle);
        animator.SetBool("Idle", idle);
    }
}
