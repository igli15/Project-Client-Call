using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Selectable : MonoBehaviour,ISelectable {

	[SerializeField] 
	private int indexToBePlaced = 0;

	[SerializeField]
	private SelectableManager selectableManager;

	private bool isSelected = false;

	private Image image;
	

	private void Start()
	{
		selectableManager.AddSelectable(indexToBePlaced,this);
		image = GetComponent<Image>();
	}

	private void Update()
	{
		if (selectableManager.GetCurrentSelected().Equals(this) && !isSelected)
		{
			BeSelected();
		}
		else if (!selectableManager.GetCurrentSelected().Equals(this))
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


	public int IndexToBePlaced
	{
		get { return indexToBePlaced; }
	}

	public bool IsSelected
	{
		get { return isSelected; }
		
	}
}
