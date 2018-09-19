using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.PostProcessing;

public class PostProccesingManager : MonoBehaviour
{
	[Header("VignetterSettings")]
	[SerializeField]
	private VignetteModel.Settings vignetteSettings;
	[SerializeField]
	private float maxVignetteIntensity = 1;

	[SerializeField] 
	private float vignetteIncreaseAmount = 5;
	
	[Space]
	
	[Header("BloomSettings")]
	[SerializeField]
	private BloomModel.Settings bloomSettings;
	[SerializeField]
	private float maxBloomIntensity = 1;

	[SerializeField] 
	private float bloomIncreaseAmount = 5;

	private PostProcessingProfile currentCC;
	
	//Vignette private fields
	private VignetteModel.Settings initVignetteSetting;
	private bool increaseVignetteIntensity;
	private bool stopIncreasingVignette;
	
	//bloom private fields
	private BloomModel.Settings initBloomSetting;
	private bool increaseBloomIntensity;
	private bool stopIncreasingBloom;
	
	
	// Use this for initialization
	void Start ()
	{
		currentCC = GetComponent<PostProcessingBehaviour>().profile;
		
		currentCC.vignette.settings = vignetteSettings;
		currentCC.bloom.settings = bloomSettings;
		
		initVignetteSetting = currentCC.vignette.settings;
		initBloomSetting = currentCC.bloom.settings;
		
		vignetteIncreaseAmount /= 1000;
		bloomIncreaseAmount /= 1000;
		
		PlayerSlowMotionState.OnDeflectionStateEntered += StartIncreasingVignetteIntensity;
		
		PlayerSlowMotionState.OnDeflectionStateExit += StopIncreasingVignetteIntensity;

	}
	
	// Update is called once per frame
	void Update ()
	{
		VignetteBehaviour();
		BloomBehaviour();
	}

	private void VignetteBehaviour()
	{
		if (increaseVignetteIntensity && currentCC.vignette.settings.intensity <= maxVignetteIntensity && !stopIncreasingVignette)
		{

			vignetteSettings.intensity += vignetteIncreaseAmount;
			currentCC.vignette.settings = vignetteSettings;
			
			if (currentCC.vignette.settings.intensity >= maxVignetteIntensity)
			{
				stopIncreasingVignette = true;
			}
			
		}
		
		if(currentCC.vignette.settings.intensity > initVignetteSetting.intensity && !increaseVignetteIntensity)
		{
			vignetteSettings.intensity -= vignetteIncreaseAmount;
			currentCC.vignette.settings = vignetteSettings;
			stopIncreasingVignette = false;
		}

	}
	
	private void BloomBehaviour()
	{
		if (increaseBloomIntensity && currentCC.bloom.settings.bloom.intensity <= maxBloomIntensity && !stopIncreasingBloom)
		{

			bloomSettings.bloom.intensity += bloomIncreaseAmount;
			currentCC.bloom.settings = bloomSettings;
			
			if (currentCC.bloom.settings.bloom.intensity >= maxBloomIntensity)
			{
				stopIncreasingBloom = true;
			}
			
		}
		
		if(currentCC.bloom.settings.bloom.intensity > initBloomSetting.bloom.intensity && !increaseBloomIntensity)
		{
			bloomSettings.bloom.intensity -= bloomIncreaseAmount;
			currentCC.bloom.settings = bloomSettings;
			stopIncreasingBloom = false;
		}

	}

	private void StartIncreasingVignetteIntensity(PlayerSlowMotionState sender)
	{
		increaseVignetteIntensity = true;
		increaseBloomIntensity = true;
	}
	
	private void StopIncreasingVignetteIntensity(PlayerSlowMotionState sender)
	{
		increaseVignetteIntensity = false;
		increaseBloomIntensity = false;
	}

	private void OnDestroy()
	{
		PlayerSlowMotionState.OnDeflectionStateEntered -= StopIncreasingVignetteIntensity;
		PlayerSlowMotionState.OnDeflectionStateExit -= StartIncreasingVignetteIntensity;
	}
	
	
}
