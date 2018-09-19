using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class ResolutionScreenManager : MonoBehaviour {

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
		
		HighScoreManager.instance.CalcTotalScore();
		
		sequence.Append(_killer.DOText(HighScoreManager.instance.KillerScore.ToString(),countDown,true,ScrambleMode.Numerals,"0123456789"));
		sequence.Append(_achiever.DOText(HighScoreManager.instance.AchieverScore.ToString(),countDown,true,ScrambleMode.Numerals,"0123456789"));
		sequence.Append(_socialiser.DOText(HighScoreManager.instance.SocialScore.ToString(),countDown,true,ScrambleMode.Numerals,"0123456789"));
		sequence.Append(_explorer.DOText(HighScoreManager.instance.ExplorerScore.ToString(),countDown,true,ScrambleMode.Numerals,"0123456789"));
		sequence.Append(_totalScore.DOText(HighScoreManager.instance.CalcTotalScore().ToString(),countDown,true,ScrambleMode.Numerals,"0123456789"));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
