using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WordScroll : MonoBehaviour,ISelectable
{

	[SerializeField] 
	private string charactersToScorll;
	
	[SerializeField] 
	private int indexToBePlaced = 0;

	private SelectableManager selectableManager;
	private WordScrollManager wordScrollManager;
	
	private bool isSelected = false;

	private Image image;

	private string currentLetter = "";

	private char[] letters;

	[HideInInspector]
	public int scrollIndex;

	private Text text;
	
	// Use this for initialization
	void Start ()
	{
		selectableManager = transform.parent.GetComponent<SelectableManager>();
		wordScrollManager = transform.parent.GetComponent<WordScrollManager>();

		wordScrollManager.OnBeforeUsernameGenerated += AddCharacter;
		
		selectableManager.AddSelectable(indexToBePlaced,this);

		image = GetComponent<Image>();

		letters = charactersToScorll.ToCharArray();

		text = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (selectableManager.GetCurrentSelected().Equals(this) && !isSelected)
		{
			BeSelected();
		}
		else if (!selectableManager.GetCurrentSelected().Equals(this))
		{
			Reset();
		}

		if (isSelected)
		{
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				ScrollUp();
			}
			else if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				ScrollDown();
			}
		}

		if(letters.Length > 0)
		text.text = letters[scrollIndex].ToString();

	}

	private void AddCharacter(WordScrollManager sender)
	{
		sender.AddCharacter(indexToBePlaced,text.text);
	}

	public void BeSelected()
	{
		image.color = Color.black;
		isSelected = true;
	}

	public void Reset()
	{
		image.color = Color.white;
		isSelected = false;
	}

	public void ScrollUp()
	{
		if (scrollIndex <= 0)
		{
			scrollIndex = letters.Length - 1;
			return;
		}
		scrollIndex -= 1;

	}
	
	public void ScrollDown()
	{
		if (scrollIndex >= letters.Length - 1)
		{
			scrollIndex = 0;
			return;
		}

		scrollIndex += 1;

	}

	private void OnDestroy()
	{
		wordScrollManager.OnBeforeUsernameGenerated += AddCharacter;
	}
}
