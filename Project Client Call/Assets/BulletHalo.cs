using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BulletHalo : MonoBehaviour
{
	[SerializeField] 
	private float timeTillMaxIntensity = 0.2f;

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
		decreaseTween.Kill();
		if (increaseTween == null)
		{
			increaseTween = light.DOIntensity(1, timeTillMaxIntensity);
		}
	}
	
	private void DecreaseIntensity(PlayerSlowMotionState sender)
	{
		increaseTween.Kill();
		if (decreaseTween == null)
		{
			decreaseTween = light.DOIntensity(0, timeTillMaxIntensity);
		}
	}

	private void OnDestroy()
	{
		PlayerSlowMotionState.OnDeflectionStateExit -= DecreaseIntensity;
		PlayerSlowMotionState.OnDeflectionStateEntered -= IncreaseIntensity;
		PlayerSlowMotionState.OnSlowMoState -= IncreaseIntensity;
	}
}
