using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.PostProcessing;

public class PostProccesingManager : MonoBehaviour
{

	private PostProcessingProfile currentCC;

	[SerializeField]
	private VignetteModel.Settings vignetteSettings;
	[SerializeField]
	private float maxVignetteIntensity = 1;
	

	private VignetteModel.Settings initVignetteSetting;

	private bool increaseVignetteIntensity;

	private bool stop;
	
	// Use this for initialization
	void Start ()
	{
		currentCC = GetComponent<PostProcessingBehaviour>().profile;
		initVignetteSetting = currentCC.vignette.settings;

		PlayerSlowMotionState.OnDeflectionStateEntered += StartIncreasingVignetteIntensity;
		
		PlayerSlowMotionState.OnDeflectionStateExit += StopIncreasingVignetteIntensity;

	}
	
	// Update is called once per frame
	void Update ()
	{
		VignetteBehaviour();
	}

	private void VignetteBehaviour()
	{
		if (increaseVignetteIntensity && currentCC.vignette.settings.intensity <= maxVignetteIntensity && !stop)
		{

			vignetteSettings.intensity += 0.005f;
			currentCC.vignette.settings = vignetteSettings;
			
			if (currentCC.vignette.settings.intensity >= maxVignetteIntensity)
			{
				stop = true;
			}
			
		}
		
		if(currentCC.vignette.settings.intensity > initVignetteSetting.intensity && !increaseVignetteIntensity)
		{
			vignetteSettings.intensity -= 0.005f;
			currentCC.vignette.settings = vignetteSettings;
			stop = false;
		}

	}

	private void StartIncreasingVignetteIntensity(PlayerSlowMotionState sender)
	{
		increaseVignetteIntensity = true;
	}
	
	private void StopIncreasingVignetteIntensity(PlayerSlowMotionState sender)
	{
		increaseVignetteIntensity = false;
	}

	private void OnDestroy()
	{
		PlayerSlowMotionState.OnDeflectionStateEntered -= StopIncreasingVignetteIntensity;
		PlayerSlowMotionState.OnDeflectionStateExit -= StartIncreasingVignetteIntensity;
	}
	
	
}
