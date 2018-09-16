using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSwosh : MonoBehaviour
{
	[SerializeField]
	private Transform initParent;

	[SerializeField] private Transform swordCollider;

	[SerializeField] private Transform swoshPoint;

	private SwordCollisions swordCollisions;

	private Animator animator;

	private int prevIndex = 1;

	private void Start()
	{
		
		swordCollisions = swordCollider.GetComponent<SwordCollisions>();
		gameObject.SetActive(false);
		
	}

	public void Disable()
	{
		transform.parent = initParent;
		transform.position = swoshPoint.position;
		transform.rotation = swordCollider.rotation;
		swordCollisions.EnableSwordHud();
		gameObject.SetActive(false);

	}

	private void OnEnable()
	{
		animator = GetComponent<Animator>();
		
		if (prevIndex == 1)
		{
			animator.SetInteger("Index",0);
			prevIndex = 0;
		}
		else
		{
			animator.SetInteger("Index",1);
			prevIndex = 1;
		}
	}
}
