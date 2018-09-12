using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSwosh : MonoBehaviour
{
	[SerializeField]
	private Transform initParent;

	[SerializeField] private Transform swordCollider;

	[SerializeField] private Transform swoshPoint;


	private void Start()
	{
		gameObject.SetActive(false);
	}

	public void Disable()
	{
		transform.parent = initParent;
		transform.position = swoshPoint.position;
		transform.rotation = swordCollider.rotation;
		gameObject.SetActive(false);

	}
}
