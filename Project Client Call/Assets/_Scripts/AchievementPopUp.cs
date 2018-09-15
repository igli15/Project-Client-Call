using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class AchievementPopUp : MonoBehaviour
{	
	[Serializable]
	public class AchievementData
	{
		public string title;
		public string description;
		public string japaneseText;
		//public Sprite icon;
		public Sprite background;
	}

	[SerializeField] private List<AchievementData> achievementData;

	private Dictionary<string, AchievementData> achievementDictionary;
	private RectTransform rectTransform;
		
	// Use this for initialization
	void Start ()
	{
		
		achievementDictionary = new Dictionary<string, AchievementData>();
		rectTransform = GetComponent<RectTransform>();
		rectTransform.anchoredPosition = new Vector2(0 + rectTransform.sizeDelta.x, 450);
		
		foreach (AchievementData data in achievementData)
		{
			//achievementDictionary.Add(data.title,);
		}
	}


	public void Show(AchievementData pData = null)
	{
		rectTransform.DOAnchorPos(new Vector2(0,450), 0.8f);
	}

	public void Reset(AchievementData pData = null)
	{

		rectTransform.DOAnchorPos(new Vector2(0 + rectTransform.sizeDelta.x, 450), 0.8f);
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
