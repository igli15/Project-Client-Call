using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
	[HideInInspector]
	public static float timeSlowScale = 1;  //remove this later
	
	[SerializeField] 
	private float timeDownScaleSpeed = 0.8f;
	
	
	// Use this for initialization
	void Start ()
	{
		PlayerDeflectionState.OnDeflectionStateEntered += StartSlowMo;
		PlayerDeflectionState.OnDeflectionStateExit += StopSlowMo;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void StartSlowMo(PlayerDeflectionState sender)
	{
		DOTween.To(x => Time.timeScale  = x, Time.timeScale , 0.3f, timeDownScaleSpeed).SetId("SlowTimeSpeedTween"); 
		Time.fixedDeltaTime = 0.02f * Time.timeScale;
	}

	public void StopSlowMo(PlayerDeflectionState sender)
	{
		DOTween.Kill("SlowTimeSpeedTween");
		Time.timeScale = 1;
		Time.fixedDeltaTime = 0.02f;
	}

	private void OnDestroy()
	{
		PlayerDeflectionState.OnDeflectionStateEntered -= StartSlowMo;
		PlayerDeflectionState.OnDeflectionStateExit -= StopSlowMo;
	}
}
