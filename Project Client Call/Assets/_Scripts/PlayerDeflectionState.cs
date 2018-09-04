using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerDeflectionState : AbstractState<PlayerFsmController>
{


	private RotateWithMouse rotateWithMouse;

	[SerializeField] private float timeDownScaleSpeed = 1.5f;
	[SerializeField] private float timeUpScalespeed = 1;
	
	// Use this for initialization
	void Start ()
	{
		rotateWithMouse = GetComponentInChildren<RotateWithMouse>();
	}


	public override void Enter(IAgent pAgent)
	{
		base.Enter(pAgent);
		rotateWithMouse.enabled = true;
		
		DOTween.To(x => Time.timeScale  = x, Time.timeScale , 0.3f, timeDownScaleSpeed);

	}

	public override void Exit(IAgent pAgent)
	{

		base.Exit(pAgent);
		rotateWithMouse.gameObject.transform.position = rotateWithMouse.initialDistanceFromPlayer + transform.position;
		rotateWithMouse.gameObject.transform.rotation = Quaternion.identity;

		DOTween.KillAll();
		Time.timeScale = 1;
		
	}

}
