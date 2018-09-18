using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    [SerializeField]
    float damage = 1;
    [SerializeField]
    float damageMultiplier = 1.5f;
    [SerializeField]
    bool isReflectable=false;
    [SerializeField]
    float reflectedSpeed = 10;

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
		if (other.CompareTag("Sword Collider")&& isReflectable)
		{
			if(rb != null)
			rb.velocity = other.transform.parent.right *reflectedSpeed * damageMultiplier*TimeManager.timeSlowScale ;
            isReflected = true;
		}

        if (other.transform.CompareTag("Ground"))
        {
            if (isReflectable) ObjectPooler.instance.DestroyFromPool("SmallProjectile", gameObject);
            else ObjectPooler.instance.DestroyFromPool("BigProjectile", gameObject);
        }

		if (other.transform.CompareTag("Player"))
		{
            other.transform.parent.GetComponent<Health>().InflictDamage(damage);
			if(isReflectable) ObjectPooler.instance.DestroyFromPool("SmallProjectile",gameObject);
            else ObjectPooler.instance.DestroyFromPool("BigProjectile", gameObject);
        }
        if (isReflected && other.transform.CompareTag("Enemy"))
        {
            if (other.GetComponent<EnemyOnKneeState>().enabled) return;

	        EnemyFsmController enemyFsmController = other.GetComponent<EnemyFsmController>();
			enemyFsmController.health.InflictDamage(damage);
	        enemyFsmController.PlayBloodParticleSystem(transform);

	       
            if (isReflectable) ObjectPooler.instance.DestroyFromPool("SmallProjectile", gameObject);
            else ObjectPooler.instance.DestroyFromPool("BigProjectile", gameObject);
        }
        
	}
}
