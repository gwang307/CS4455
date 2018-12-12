using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collector : MonoBehaviour {
	public int score = 0;
	public ScoreUI scoreUI;
    public AudioSource coinSound;

    private void Start()
    {
        coinSound = GetComponent<AudioSource>();
    }

    public void ReceiveCollectible(int collectibleScore) {
		score += collectibleScore;
		scoreUI.scoreText.text = roundScore(score);
        coinSound.Play();
		
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
