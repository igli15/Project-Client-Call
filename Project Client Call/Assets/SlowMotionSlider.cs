﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowMotionSlider : MonoBehaviour
{
	
	[SerializeField] 
	private float slowMoConsumeRate = 3f;
	
	
	[SerializeField] 
	private float slowMoChargeRate = 2f;

	private Slider slowMoSlider;
	private bool refillSlider = false;
	private bool consumeSlider = false;
	
	// Use this for initialization
	void Start ()
	{
		slowMoSlider = GetComponent<Slider>();

		slowMoChargeRate /= 10;
		slowMoConsumeRate /= 10;

		PlayerNormalState.OnNormalStateEntered += StartRefilling;
		PlayerNormalState.OnNormalStateExit += StopRefilling;

		PlayerDeflectionState.OnDeflectionStateEntered += StartConsuming;
		PlayerDeflectionState.OnDeflectionStateExit += StopConsuming;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (consumeSlider)
		{
			slowMoSlider.value -= slowMoConsumeRate * Time.deltaTime;
		}
		if (refillSlider)
		{
			slowMoSlider.value += slowMoChargeRate * Time.deltaTime;
		}
	}

	public void StartRefilling(PlayerNormalState playerNormalState)
	{
		refillSlider = true;
	}

	public void StopRefilling(PlayerNormalState playerNormalState)
	{
		refillSlider = false;
	}
	
	public void StartConsuming(PlayerDeflectionState playerDeflectionState)
	{
		consumeSlider = true;
	}
	
	public void StopConsuming(PlayerDeflectionState playerDeflectionState)
	{
		consumeSlider = false;
	}

	private void OnDestroy()
	{
		PlayerNormalState.OnNormalStateEntered -= StartRefilling;
		PlayerNormalState.OnNormalStateExit -= StopRefilling;

		PlayerDeflectionState.OnDeflectionStateEntered -= StartConsuming;
		PlayerDeflectionState.OnDeflectionStateExit -= StopConsuming;
	}
}
