using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using DG.Tweening;

public class masterGoesBoomScript : MonoBehaviour {

	// Use this for initialization
	[SerializeField] private AudioMixerGroup boomMaster;
	[SerializeField] private float duration;
	[SerializeField] private float lpIntensity;
	void Start () 
	{
		PlayerSlowMotionState.OnDeflectionStateEntered += ActivateLowpass;
		PlayerSlowMotionState.OnDeflectionStateExit += DisableLowpass;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void ActivateLowpass(PlayerSlowMotionState sender)
	{
		boomMaster.audioMixer.DOSetFloat("lowpass",lpIntensity, duration);
	}

	void DisableLowpass(PlayerSlowMotionState sender)
	{
		boomMaster.audioMixer.DOSetFloat("lowpass",22000f, duration);
		
	}

	void OnDestroy()
    {
      PlayerSlowMotionState.OnDeflectionStateEntered -= ActivateLowpass;
		PlayerSlowMotionState.OnDeflectionStateExit -= DisableLowpass;

    }
}
