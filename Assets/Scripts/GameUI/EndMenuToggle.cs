using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof(CanvasGroup))]
public class EndMenuToggle : MonoBehaviour {

	public CanvasGroup canvasGroup;
	private GameObject collector;
	public ScoreUI scoreUI;
	public HighScoreUI endHighScoreUI;
	private Timer timer;
	private int new_result_score;
	private int new_high_score;
	private int display_score;
	private int display_high_score;

	void Awake() {
		canvasGroup = GetComponent<CanvasGroup>();
		if (canvasGroup == null)
			Debug.LogError("Required canvas group component is missed.", canvasGroup);
		collector = GameObject.Find("SomeDude_RootMotion");
		timer = GetComponent<Timer>();
	}

	// Use this for initialization
	void Start() {
		
	}

	void Update() {
		if (display_high_score < display_score) {
			if (display_high_score < new_high_score - 50)
				display_high_score += 50;
			else
				display_high_score = new_high_score;
		} else if (display_score < display_high_score) {
			if (display_score < new_result_score - 50)
				display_score += 50;
			else
				display_score = new_result_score;
		} else {
			if (display_high_score < new_high_score - 50)
				display_high_score += 50;
			else
				display_high_score = new_high_score;
			if (display_score < new_result_score - 50)
				display_score += 50;
			else
				display_score = new_result_score;
		}
		scoreUI.scoreText.text = roundScore(display_score);
		endHighScoreUI.scoreText.text = "HIGH SCORE: " + roundScore(display_high_score);
	}
	
	// Update is called once per frame
	public void endGame() {
		// Display UI & Block Control
		canvasGroup.interactable = true;
		canvasGroup.blocksRaycasts = true;
		canvasGroup.alpha = 1f;
		collector.GetComponent<ThirdPersonUserControl>().enabled = false;

		// Calculate & Assign Scores
		float timePassed = timer.timePassed;
		float timeBonus = Mathf.Max((15f - timePassed), 0f) * 100f;
		int timeBonusInt = Mathf.RoundToInt(timeBonus);

		int curr_high_score = PlayerPrefs.GetInt("high_score", 0);
		display_high_score = curr_high_score;
		display_score = collector.GetComponent<Collector>().score;
		new_result_score = display_score + timeBonusInt;
		if (new_result_score > curr_high_score) {
			PlayerPrefs.SetInt("high_score", new_result_score);
			endHighScoreUI.scoreText.text = "HIGH SCORE: " + roundScore(curr_high_score);
			new_high_score = new_result_score;
		}
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
