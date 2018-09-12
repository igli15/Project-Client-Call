using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class menuScript : MonoBehaviour {

	
	[SerializeField] private Image _stroke;
	[SerializeField] private Button[] button = new Button[4];
	[SerializeField] private float scrollSpeed;
	private float scrollAmount;
	private int selectedButton;
	void Start () {
		scrollAmount = 1;
		selectedButton = 0;
		button[selectedButton].GetComponentInChildren<Text>().color = Color.white;
		Debug.Log(_stroke.transform.position);
		Debug.Log(button[0].transform.position);
	}
	
	void Update () {
		
		if(scrollAmount < 0)
		{
			if(Input.GetAxisRaw("VerticalJoy") > 0 | Input.GetAxisRaw("Vertical") > 0)
			{
				Debug.Log(button.Length);
				if(selectedButton > 0)
				{
					button[selectedButton].GetComponentInChildren<Text>().color = Color.black;
					selectedButton -= 1;
					_stroke.transform.position = button[selectedButton].transform.position;
					button[selectedButton].GetComponentInChildren<Text>().color = Color.white;
					scrollAmount = 1;
				}
				else 
				{
					button[selectedButton].GetComponentInChildren<Text>().color = Color.black;
					selectedButton = button.Length -1;
					_stroke.transform.position = button[selectedButton].transform.position;
					button[selectedButton].GetComponentInChildren<Text>().color = Color.white;
					scrollAmount = 1;
				}
			}

			if(Input.GetAxisRaw("VerticalJoy") < 0 | Input.GetAxis("Vertical") < 0)
			{
				Debug.Log("hey2!!!");
					if(selectedButton < button.Length - 1)
					{
						button[selectedButton].GetComponentInChildren<Text>().color = Color.black;
						selectedButton += 1;
						_stroke.transform.position = button[selectedButton].transform.position;
						button[selectedButton].GetComponentInChildren<Text>().color = Color.white;
						scrollAmount = 1;
					}
					else 
					{
						button[selectedButton].GetComponentInChildren<Text>().color = Color.black;
						selectedButton = 0;
						_stroke.transform.position = button[selectedButton].transform.position;
						button[selectedButton].GetComponentInChildren<Text>().color = Color.white;
						scrollAmount = 1;
					}
			}
		}
		scrollAmount -= scrollSpeed;
	}
}
