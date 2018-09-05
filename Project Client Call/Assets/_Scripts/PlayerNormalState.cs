using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNormalState : AbstractState<PlayerFsmController>
{

	[SerializeField] 
	private Slider slowMoSlider;

	[SerializeField] 
	private float slowMoChargeRate = 2f;

	private bool refillSlider = false;
	
	// Use this for initialization
	void Start ()
	{
		slowMoChargeRate /= 10;
	}

	public override void Enter(IAgent pAgent)
	{
		base.Enter(pAgent);
		
		refillSlider = true;

	}

	private void Update()
	{
		if (refillSlider)
		{
			slowMoSlider.value += slowMoChargeRate * Time.deltaTime;
		}
	}

	public override void Exit(IAgent pAgent)
	{
		base.Exit(pAgent);

		refillSlider = false;
	}
}
