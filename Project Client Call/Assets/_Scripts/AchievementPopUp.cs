using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class AchievementPopUp : MonoBehaviour
{
	[Header("PopUpElements")] 
	[SerializeField]
	private Text titleText;

	[SerializeField]
	private Text description;

	[SerializeField] 
	private Text japaneseText;
	
	[SerializeField] 
	private Image backgroundImage;
	
	[Serializable]
	public class AchievementData
	{
		public string title;
		public string description;
		public string japaneseText;
		//public Sprite icon;
		public Sprite background;

		[HideInInspector] 
		public bool isCompleted;
	}

	[Space]
	[Header("PopUpDatas")]
	[SerializeField] private List<AchievementData> achievementData;

	private Dictionary<string, AchievementData> achievementDictionary;
	private RectTransform rectTransform;
	
	private Queue<AchievementData> achievementQueue = new Queue<AchievementData>();

	private bool isDisplaying = false;
		
	// Use this for initialization
	void Start ()
	{
		
		achievementDictionary = new Dictionary<string, AchievementData>();
		rectTransform = GetComponent<RectTransform>();
		rectTransform.anchoredPosition = new Vector2(0 + rectTransform.sizeDelta.x, 450);
		
		foreach (AchievementData data in achievementData)
		{
			achievementDictionary.Add(data.title,data);
		}
	}


	public void Show(AchievementData pData)
	{
		backgroundImage.sprite = pData.background;
		japaneseText.text = pData.japaneseText;
		description.text = pData.description;
		titleText.text = pData.title;
		
		
		rectTransform.DOAnchorPos(new Vector2(0,450), 0.8f);

		isDisplaying = true;
		pData.isCompleted = true;
		StartCoroutine(Reset(pData));
	}

	IEnumerator Reset(AchievementData pData)
	{
		yield return  new WaitForSeconds(2f);
		
		rectTransform.DOAnchorPos(new Vector2(0 + rectTransform.sizeDelta.x, 450), 0.8f);
		DOVirtual.DelayedCall(0.8f,() => isDisplaying =false);
	}

	private void Update()
	{
		if (achievementQueue.Count() > 0)
		{
			if (!isDisplaying)
			{
				Show(achievementQueue.Dequeue());
			}
		}
		if (Input.GetKeyDown(KeyCode.A))
		{
			QueueAchievement("The Beginning");
		}
		if (Input.GetKeyDown(KeyCode.B))
		{
			QueueAchievement("Jump");
		}

	}

	public void QueueAchievement(string achievementName)
	{
		if (!achievementDictionary[achievementName].isCompleted)
		{
			achievementQueue.Enqueue(achievementDictionary[achievementName]);
		}
	}
}
