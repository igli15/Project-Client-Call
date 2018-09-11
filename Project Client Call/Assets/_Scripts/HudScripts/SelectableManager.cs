using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SelectableManager : MonoBehaviour
{
	[SerializeField] 
	protected int MaxNumberOfSelectables;
	
	public static ISelectable[] Selectables;

	[HideInInspector] 
	public static int currentIndex;
	
	// Use this for initialization

	private void Awake()
	{
		Selectables = new ISelectable[MaxNumberOfSelectables];
	}

	void Start ()
	{
		currentIndex = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.LeftArrow)) ShiftSelect(false);
		else if(Input.GetKeyDown(KeyCode.RightArrow)) ShiftSelect(true);
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

	protected void AddSelectable(int index,ISelectable selectable)
	{
		Selectables[index] = selectable;
	}
}
