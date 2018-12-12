using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collector : MonoBehaviour {
	public int score;
	ScoreUI scoreUI;
    public AudioSource coinSound;

	void Start() {
		score = 0;
		scoreUI = GameObject.Find("ScoreText").GetComponent<ScoreUI>();
		coinSound = GetComponent<AudioSource>();
	}

	public void ReceiveCollectible(int collectibleScore) {
		score += collectibleScore;
		updateScoreUI();
        coinSound.Play();
	}

	public void updateScoreUI() {
		scoreUI.scoreText.text = roundScore(score);
	}

	String roundScore(int score) {
		if (score < 10)
			return "00" + score.ToString();
		else if (score < 100)
			return "0" + score.ToString();
		else
			return score.ToString();
	}

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "coin") {
    //        coinSound.Play();
    //    }
    //}
}
