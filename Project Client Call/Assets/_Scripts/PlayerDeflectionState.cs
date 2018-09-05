using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeflectionState : AbstractState<PlayerFsmController>
{
	

	[SerializeField] 
	private float timeDownScaleSpeed = 1.5f;

	[SerializeField] 
	private float slowMoConsumeRate = 3f;

	[SerializeField] 
	private Slider slowMoSlider;
	
	private PlayerData playerData;

	private bool spendslowMoEnergy = false;

	
	// Use this for initialization
	void Start ()
	{
		slowMoSlider.onValueChanged.AddListener(CheckIfSloMoFinished);
		playerData = GetComponent<PlayerData>();

		slowMoConsumeRate /= 10;

	}


	public override void Enter(IAgent pAgent)
	{
		base.Enter(pAgent);
				
		DOTween.To(x => Time.timeScale  = x, Time.timeScale , 0.3f, timeDownScaleSpeed).SetId("SlowTimeSpeedTween");
		spendslowMoEnergy = true;
		playerData.SlowDownMovementSpeed(1f);
		
		Time.fixedDeltaTime = 0.02f * Time.timeScale;
		
		
	}

	private void Update()
	{
		if (spendslowMoEnergy)
		{
			slowMoSlider.value -= slowMoConsumeRate * Time.deltaTime;
		}
	}

	public override void Exit(IAgent pAgent)
	{

		base.Exit(pAgent);

		spendslowMoEnergy = false;
		
		
		DOTween.Kill("SlowTimeSpeedTween");
		DOTween.Kill("SlowMovementSpeedTween");
	
		playerData.ResetMovementSpeed();
		
		Time.timeScale = 1;
		Time.fixedDeltaTime = 0.02f;
	}

	public void CheckIfSloMoFinished(float value)
	{
		if (value <= 0)
		{
			target.fsm.ChangeState<PlayerNormalState>();
		}
			
	}
}
