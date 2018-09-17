using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class AchievementPopUp : MonoBehaviour
{
	[Header("PopupTransitionValues")] 
	[SerializeField]
	private float transitionTime = 0.8f;
	
	[SerializeField]
	private float timeTillGone = 2f;
	
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

	private static Dictionary<string, AchievementData> achievementDictionary;
	private RectTransform rectTransform;
	
	private static Queue<AchievementData> achievementQueue = new Queue<AchievementData>();

	private bool isDisplaying = false;

	private HighScoreManager highScoreManager;
		
	// Use this for initialization
	void Start ()
	{
		
		achievementDictionary = new Dictionary<string, AchievementData>();
		rectTransform = GetComponent<RectTransform>();
		rectTransform.anchoredPosition = new Vector2(0 + rectTransform.sizeDelta.x, 450);

		highScoreManager = GameObject.FindGameObjectWithTag("HighscoreManager").GetComponent<HighScoreManager>();

		foreach (AchievementData data in achievementData)
		{
			achievementDictionary.Add(data.title,data);
		}
	}


	private void Show(AchievementData pData)
	{
		backgroundImage.sprite = pData.background;
		japaneseText.text = pData.japaneseText;
		description.text = pData.description;
		titleText.text = pData.title;
		
		
		rectTransform.DOAnchorPos(new Vector2(0, 450),transitionTime);

		isDisplaying = true;
		highScoreManager.IncreaseAchieverScore();
		StartCoroutine(Reset(pData));
	}

	IEnumerator Reset(AchievementData pData)
	{
		yield return  new WaitForSeconds(timeTillGone);
		
		rectTransform.DOAnchorPos(new Vector2(0 + rectTransform.sizeDelta.x, 450), transitionTime);
		DOVirtual.DelayedCall(transitionTime,() => isDisplaying =false);
	}

	private void Update()
	{
		if (achievementQueue.Count > 0)
		{
			if (!isDisplaying)
			{
				Show(achievementQueue.Dequeue());
			}
		}
	}

	public static void QueueAchievement(string achievementName)
	{
		if (!achievementDictionary[achievementName].isCompleted)
		{
			achievementDictionary[achievementName].isCompleted = true;
			achievementQueue.Enqueue(achievementDictionary[achievementName]);
		}
	}

}
