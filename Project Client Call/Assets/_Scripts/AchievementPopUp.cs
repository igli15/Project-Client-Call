using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class AchievementPopUp : MonoBehaviour
{

	[Serializable]
	public class AchievementArt
	{
		public Sprite icon;
		public Sprite background;
		public string title;
		public string description;
	}
		
	// Use this for initialization
	void Start ()
	{
		
	}


	public void Show()
	{
		transform.DOScaleX(2, 0.8f);
	}

	public void Reset()
	{
		transform.DOScaleX(0, 0.8f);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			Show();
		}

		if (Input.GetKeyDown(KeyCode.S))
		{
			Reset();
		}
	}
}
