using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class Selectable : MonoBehaviour,ISelectable {

	[SerializeField] 
	private int indexToBePlaced = 0;

	[SerializeField]
	private SelectableManager selectableManager;

	private bool isSelected = false;

	private Image image;
	
	[SerializeField]
	private UnityEvent OnSelected;

	[SerializeField]
	private UnityEvent OnReset;

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
		//image.color = Color.black;
		OnSelected.Invoke();
		isSelected = true;
	}

	public void Reset()
	{
		//image.color = Color.white;
		OnReset.Invoke();
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
