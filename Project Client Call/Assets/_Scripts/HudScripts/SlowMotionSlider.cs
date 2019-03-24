using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SlowMotionSlider : MonoBehaviour
{
	[SerializeField] 
	private Sprite filledIcon;
	
	[SerializeField] 
	private Sprite emptyIcon;

	[SerializeField] 
	private Image pressL1;

	[SerializeField] 
	private Image icon;
	
	[SerializeField] 
	private float slowMoConsumeRate = 3f;
	
	
	[SerializeField] 
	private float slowMoChargeRate = 2f;

	[SerializeField] 
	private PlayerFsmController playerFsmController;


	private Slider slowMoSlider;
	private bool refillSlider = false;
	private bool consumeSlider = false;

	
	// Use this for initialization
	void Start ()
	{
		slowMoSlider = GetComponent<Slider>();

		slowMoSlider.value = 0;
		StartRefilling(null);
		
		slowMoSlider.onValueChanged.AddListener(CheckIfSloMoFinished);

		slowMoChargeRate /= 10;
		slowMoConsumeRate /= 10;

		PlayerNormalState.OnNormalStateEntered += StartRefilling;
		PlayerNormalState.OnNormalStateExit += StopRefilling;

		PlayerSlowMotionState.OnDeflectionStateEntered += StartConsuming;
		PlayerSlowMotionState.OnDeflectionStateExit += StopConsuming;

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
	
	public void StartConsuming(PlayerSlowMotionState playerSlowMotionState)
	{
		consumeSlider = true;
	}
	
	public void StopConsuming(PlayerSlowMotionState playerSlowMotionState)
	{
		consumeSlider = false;
	}

	private void OnDestroy()
	{
		PlayerNormalState.OnNormalStateEntered -= StartRefilling;
		PlayerNormalState.OnNormalStateExit -= StopRefilling;

		PlayerSlowMotionState.OnDeflectionStateEntered -= StartConsuming;
		PlayerSlowMotionState.OnDeflectionStateExit -= StopConsuming;
	}
	
	public void CheckIfSloMoFinished(float value)
	{
		if (value <= 0)
		{
			playerFsmController.fsm.ChangeState<PlayerNormalState>();
		}	
		
		if (slowMoSlider.value >= 0.95f)
		{
			icon.sprite = filledIcon;
			pressL1.enabled = true;
		}
		else if (slowMoSlider.value< 0.95f)
		{
			icon.sprite = emptyIcon;
			pressL1.enabled = false;
		}
	}
}
