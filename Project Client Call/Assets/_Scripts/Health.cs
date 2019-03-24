using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{			
	public  Action<Health> OnDeath;
	public  Action<Health> OnHealthIncreased;
	public  Action<Health> OnHealthDecreased;

	[SerializeField] 
	private float health = 100;

	[SerializeField] 
	private float maxHealth = 100;

	private float initialHealth;
	
	[SerializeField] 
	private bool shouldBeDestroyed;
	
	void Start ()
	{
		initialHealth = health;
	}

	public void InflictDamage(float damageAmount)
	{
		if(OnHealthDecreased != null) OnHealthDecreased(this);
		health -= damageAmount;
	}
	
	public void HealUp(float healAmount)
	{
		if(OnHealthIncreased != null) OnHealthIncreased(this);
		health += healAmount;
	}

	public void ResetHealth()
	{
		health = initialHealth;
	}
	
	void Update () 
	{
		if (health <= 0)
		{
			if(OnDeath != null)	OnDeath(this);
			
			if (shouldBeDestroyed)
			{
				Destroy(gameObject);
			}
		
		}

		if (health > maxHealth)
		{
			health = maxHealth;
		}
	}
}
