using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordScroll : SelectableManager,ISelectable
{

	[SerializeField] 
	private int indexToBePlaced = 0;
	
	private bool isSelected = false;

	private Image image;
	
	// Use this for initialization
	void Start ()
	{
		AddSelectable(indexToBePlaced,this);

		image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (GetCurrentSelected().Equals(this) && !isSelected)
		{
			BeSelected();
			Debug.Log(currentIndex);
		}
		else if (!GetCurrentSelected().Equals(this))
		{
			Reset();
		}

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
}
