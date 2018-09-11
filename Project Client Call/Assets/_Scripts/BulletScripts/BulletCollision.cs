using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    [SerializeField]
    float damage = 1;

    //TODO: ADD this 
    //isReflectable  <== Cannoneerr's projectiles dont get reflected

	private Rigidbody2D rb;
    [HideInInspector]
    public bool isReflected;
	private EnemyRangedAttack enemyRangedAttack;
	
	private void Start()
	{
        isReflected = false;
		rb = GetComponent<Rigidbody2D>();
		enemyRangedAttack = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyRangedAttack>();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Sword Collider"))
		{
			if(rb != null)
			rb.velocity = other.transform.parent.right * enemyRangedAttack.GetBulletSpeed() * TimeManager.timeSlowScale ;
            isReflected = true;
		}

		if (other.transform.CompareTag("Player"))
		{
			ObjectPooler.instance.DestroyFromPool("SmallProjectile",gameObject);
		}
        if (isReflected && other.transform.CompareTag("Enemy"))
        {
            other.GetComponent<Health>().InflictDamage(damage);
            ObjectPooler.instance.DestroyFromPool("SmallProjectile", gameObject);
        }
        
	}

	private void OnCollisionEnter(Collision other)
	{
		
	}
}
