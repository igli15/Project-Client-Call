using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSlowMotionState : AbstractState<PlayerFsmController>
{

	public static Action<PlayerSlowMotionState> OnDeflectionStateEntered;
	public static Action<PlayerSlowMotionState> OnDeflectionStateExit;

	
	// Use this for initialization
	void Start ()
	{
	}


	public override void Enter(IAgent pAgent)
	{
		base.Enter(pAgent);

		if (OnDeflectionStateEntered != null) OnDeflectionStateEntered(this);
		
	}

	private void Update()
	{

	}

	public override void Exit(IAgent pAgent)
	{

		base.Exit(pAgent);

		if (OnDeflectionStateExit != null) OnDeflectionStateExit(this);

	
	}

}
