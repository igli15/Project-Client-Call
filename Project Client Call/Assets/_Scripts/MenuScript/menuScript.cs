using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class menuScript : MonoBehaviour {

	
	[SerializeField] private Image _stroke;
	[SerializeField] private Button[] button = new Button[4];
	[SerializeField] private float scrollSpeed;
	[SerializeField] private AudioSource clipSource;
	[SerializeField] private AudioClip _strokeSound;
	private float scrollAmount;
	public int selectedButton;
	void Start () {
		scrollAmount = 1;
		selectedButton = 0;
		button[selectedButton].GetComponentInChildren<Text>().color = Color.white;
	}
	
	void Update () {
		
		if(scrollAmount < 0)
		{
			if(Input.GetAxisRaw("VerticalMenu") > 0 | Input.GetAxisRaw("Vertical") > 0)
			{
				clipSource.PlayOneShot(_strokeSound);
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
				clipSource.PlayOneShot(_strokeSound);
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
