using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreUI : MonoBehaviour {
	public Text scoreText;

	// Use this for initialization
	void Start () {
		scoreText = GetComponent<Text>();
		int curr_hs = PlayerPrefs.GetInt("high_score", 0);
		scoreText.text = "HIGH SCORE: " + roundScore(curr_hs);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	String roundScore(int score) {
		if (score < 10)
			return "00" + score.ToString();
		else if (score < 100)
			return "0" + score.ToString();
		else
			return score.ToString();
	}
}
