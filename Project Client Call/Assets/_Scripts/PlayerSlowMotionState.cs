using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSlowMotionState : AbstractState<PlayerFsmController>
{

	
	private PlayerMovement playerMovement;

	private bool spendslowMoEnergy = false;

	public static Action<PlayerSlowMotionState> OnDeflectionStateEntered;
	public static Action<PlayerSlowMotionState> OnDeflectionStateExit;

	
	// Use this for initialization
	void Start ()
	{
		playerMovement = GetComponent<PlayerMovement>();

	}


	public override void Enter(IAgent pAgent)
	{
		base.Enter(pAgent);

		if (OnDeflectionStateEntered != null) OnDeflectionStateEntered(this);
		
		playerMovement.SlowDownMovementSpeed(1f);
		
	}

	private void Update()
	{

	}

	public override void Exit(IAgent pAgent)
	{

		base.Exit(pAgent);

		
		if (OnDeflectionStateExit != null) OnDeflectionStateExit(this);
		
		DOTween.Kill("SlowMovementSpeedTween");
	
		playerMovement.ResetMovementSpeed();
	
	}

}
