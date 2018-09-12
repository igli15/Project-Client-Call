using System.Collections;
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
        Debug.Log("rangedAttackState"+ attackState);
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
}
