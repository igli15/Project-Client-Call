using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour {

	// Use this for initialization
	[SerializeField] private GameObject startGame;
	[SerializeField] private GameObject scoreBoard;
	[SerializeField] private GameObject controls;
	[SerializeField] private GameObject credits;
	menuScript _menuScript;
	private int selection;
	void Start () {
		_menuScript = GetComponent<menuScript>();
		selection = _menuScript.selectedButton;
	}
	
	// Update is called once per frame
	void Update () {
		selection = _menuScript.selectedButton;
			Debug.Log(selection);
		if(Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log("doing it again");
			switch (selection)
			{
				case 0:
				startGame.SetActive(true);
				this.gameObject.SetActive(false);
				break;
				case 1:
				scoreBoard.SetActive(true);
				this.gameObject.SetActive(false);
				break;
				case 2:
				controls.SetActive(true);
				this.gameObject.SetActive(false);
				break;
				default:
				credits.SetActive(true);
				this.gameObject.SetActive(false);
				break;
			}
		}
	}
}
