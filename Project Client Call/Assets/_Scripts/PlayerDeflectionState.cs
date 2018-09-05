using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerDeflectionState : AbstractState<PlayerFsmController>
{
	
	[Header("Slow Mo Time Values")]
	[SerializeField] private float timeDownScaleSpeed = 1.5f;

	
	private PlayerData playerData;

	
	// Use this for initialization
	void Start ()
	{
		playerData = GetComponent<PlayerData>();
	}


	public override void Enter(IAgent pAgent)
	{
		base.Enter(pAgent);
				
		DOTween.To(x => Time.timeScale  = x, Time.timeScale , 0.3f, timeDownScaleSpeed).SetId("SlowTime");
		
		
		Time.fixedDeltaTime = 0.02f * Time.timeScale;
		
		
	}

	public override void Exit(IAgent pAgent)
	{

		base.Exit(pAgent);

		int i = DOTween.Kill("SlowTime");
		Debug.Log(i);
		/*DOTween.KillAll();*/
		
		Time.timeScale = 1;
		Time.fixedDeltaTime = 0.02f;
	}

}
