using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class resolutionScreenManager : MonoBehaviour {

	// Use this for initialization
	[SerializeField] private float countDown;
	private Sequence sequence;
	[SerializeField] private Text _killer;
	[SerializeField] private Text _achiever;
	[SerializeField] private Text _socialiser;
	[SerializeField] private Text _explorer;
	[SerializeField] private Text _totalScore;
	
	void Start () {
		sequence = DOTween.Sequence();

		sequence.Append(_killer.DOText("200000",countDown,true,ScrambleMode.Numerals,"0123456789"));
		sequence.Append(_achiever.DOText("200000",countDown,true,ScrambleMode.Numerals,"0123456789"));
		sequence.Append(_socialiser.DOText("200000",countDown,true,ScrambleMode.Numerals,"0123456789"));
		sequence.Append(_explorer.DOText("200000",countDown,true,ScrambleMode.Numerals,"0123456789"));
		sequence.Append(_totalScore.DOText("1234569842",countDown,true,ScrambleMode.Numerals,"0123456789"));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
