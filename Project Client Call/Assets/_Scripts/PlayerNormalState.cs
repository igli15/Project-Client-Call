using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNormalState : AbstractState<PlayerFsmController>
{

	public static Action<PlayerNormalState> OnNormalStateEntered;
	public static Action<PlayerNormalState> OnNormalStateExit;
	
	// Use this for initialization
	void Start ()
	{

	}

	public override void Enter(IAgent pAgent)
	{
		base.Enter(pAgent);

		if (OnNormalStateEntered != null) OnNormalStateEntered(this);

	}


	public override void Exit(IAgent pAgent)
	{
		base.Exit(pAgent);

		if (OnNormalStateExit != null) OnNormalStateExit(this);
	}
}
