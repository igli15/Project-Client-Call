using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class difficultyScript : MonoBehaviour {
	
	private menuScript _menuScript;
	private audioTransition _audioScript;
	[SerializeField] private GameObject _menu;
	[SerializeField] private LevelLoader levelLoader;
	private int selected;
	void Start () {
		_menuScript = GetComponent<menuScript>();
		_audioScript = GetComponent<audioTransition>();
	}
	
	// Update is called once per frame
	void Update () {
		selected = _menuScript.selectedButton;
		if(Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			switch (selected)
			{
				case 0:
				_audioScript.enabled = true;
				levelLoader.LoadLevel("PartOne");

				break;
				case 1:
				_audioScript.enabled = true;

				break ;
				case 2:
				_menu.SetActive(true);
				this.gameObject.SetActive(false);
				break;
			}
		}
	}
}
