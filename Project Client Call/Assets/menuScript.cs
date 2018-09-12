using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class menuScript : MonoBehaviour {

	// Use this for initialization
	
	[SerializeField] private Image _stroke;
	[SerializeField] private Button[] button = new Button[4];
	private int buttonCount;
	void Start () {
		buttonCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			buttonCount += 1;
			/*stroke.rectTransform.position = button[buttonCount].transform.position;*/
			//_stroke.GetComponent<Animator>().Play("stroke", 0, 0);
		}
		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			
		}
	}
}
