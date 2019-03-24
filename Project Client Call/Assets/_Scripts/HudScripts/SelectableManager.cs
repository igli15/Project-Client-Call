using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SelectableManager : MonoBehaviour
{
	[SerializeField] 
	private int MaxNumberOfSelectables;
	
	private ISelectable[] Selectables;

	private int currentIndex;

	[SerializeField] private KeyCode KeyToMoveNext;
	[SerializeField] private KeyCode KeyToMoveBack;

	private float scrollAmount;

	private float scrollSpeed = 0.05f;
	// Use this for initialization

	private void Awake()
	{
		scrollAmount = 1;
		Selectables = new ISelectable[MaxNumberOfSelectables];
	}

	void Start ()
	{
		currentIndex = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if(Input.GetKeyDown(KeyToMoveBack)) ShiftSelect(false);
		else if(Input.GetKeyDown(KeyToMoveNext)) ShiftSelect(true);

		if (scrollAmount < 0)
		{
			if (Input.GetAxisRaw("Horizontal") > 0f)
			{
				ShiftSelect(true);
				scrollAmount = 1;
			}
			else if (Input.GetAxisRaw("Horizontal") < 0f)
			{
				ShiftSelect(false);
				scrollAmount = 1;
			}
		}
		scrollAmount -= scrollSpeed;
	}

	public void ShiftSelect(bool right)
	{
		if (right)
		{
			if (currentIndex >= Selectables.Length - 1)
			{
				Debug.Log("reached the end(right)");
				currentIndex = 0;
				return;
			}

			currentIndex += 1;

		}
		else
		{
			if (currentIndex <= 0)
			{
				Debug.Log("reached the end(left)");
				currentIndex = Selectables.Length - 1;
				return;
			}

			currentIndex -= 1;
		}
		
	}

	public ISelectable GetCurrentSelected()
	{
		return Selectables[currentIndex];
	}

	public void AddSelectable(int index,ISelectable selectable)
	{
		Selectables[index] = selectable;
	}
}
