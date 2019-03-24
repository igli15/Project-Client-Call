using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightIntensityManager : MonoBehaviour
{
	[SerializeField] 
	private float timeTillMaxIntensity = 0.2f;

	[SerializeField] 
	[Range(0,1)]
	private float maxItensity = 1;

	[SerializeField] 
	[Range(0,1)]
	private float minIntensity = 0;

	private Light light;

	private Tweener increaseTween;
	private Tweener decreaseTween;
	
	
	// Use this for initialization
	void Start ()
	{
		light = GetComponent<Light>();

		PlayerSlowMotionState.OnDeflectionStateExit += DecreaseIntensity;
		PlayerSlowMotionState.OnDeflectionStateEntered += IncreaseIntensity;
		PlayerSlowMotionState.OnSlowMoState += IncreaseIntensity;
	}

	private void IncreaseIntensity(PlayerSlowMotionState sender)
	{
		increaseTween = null;
		if (increaseTween == null)
		{
			increaseTween = light.DOIntensity(maxItensity, timeTillMaxIntensity);
		}
	}
	
	private void DecreaseIntensity(PlayerSlowMotionState sender)
	{
		decreaseTween = null;
		if (decreaseTween == null)
		{
			decreaseTween = light.DOIntensity(minIntensity, timeTillMaxIntensity);
		}
	}

	private void OnDestroy()
	{
		PlayerSlowMotionState.OnDeflectionStateExit -= DecreaseIntensity;
		PlayerSlowMotionState.OnDeflectionStateEntered -= IncreaseIntensity;
		PlayerSlowMotionState.OnSlowMoState -= IncreaseIntensity;
	}
}
