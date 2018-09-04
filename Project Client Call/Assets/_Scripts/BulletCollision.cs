using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
	private Rigidbody2D rb;


	private EnemyRangedAttack enemyRangedAttack;
	
	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		enemyRangedAttack = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyRangedAttack>();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Sword Collider"))
		{
			rb.velocity = other.transform.right * enemyRangedAttack.GetBulletSpeed() * TimeManager.timeSlowScale ;
		}

		if (other.transform.CompareTag("Player"))
		{
			Destroy(gameObject);
		}
	}

	private void OnCollisionEnter(Collision other)
	{
		
	}
}
