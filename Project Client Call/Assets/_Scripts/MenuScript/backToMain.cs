using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backToMain : MonoBehaviour {

	[SerializeField] private GameObject menu;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Space)) 
		{
			menu.SetActive(true);
			this.gameObject.SetActive(false);
		}
	}
}
