using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class InsertCoinScript : MonoBehaviour {

	[SerializeField] 	private Text _text;
	[SerializeField] private int desiredSize;
	[SerializeField] private GameObject mainMenu;
	private int originalSize;
	[SerializeField] private float SizeIncreaseSpeed;
	private bool increase;
	// Use this for initialization
	void Start () {
		originalSize = _text.fontSize;
		increase = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(_text.fontSize >= desiredSize)
		{
			increase = false;
		}
		if(_text.fontSize <= originalSize)
		{
			increase = true;
		}
		if(increase) _text.fontSize += 1;
		else {_text.fontSize -= 1; }

		if(Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			mainMenu.SetActive(true);
			this.gameObject.SetActive(false);		
		}
	}
}
