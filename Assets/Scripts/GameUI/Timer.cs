using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	public float timePassed = 0f;
	public CanvasGroup pauseCanvasGroup;
	Text countdownText;
	float countDown;
	
	// Use this for initialization
	void Start () {
		countDown = 60f;
		countdownText = GameObject.Find("CountdownText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!pauseCanvasGroup.interactable) {
			timePassed += Time.deltaTime;
			float timeBonus = Mathf.Max((countDown - timePassed), 0f) * 100f;
			int timeBonusInt = Mathf.RoundToInt(timeBonus);
			countdownText.text = "Time Bonus:\n" + roundScore(timeBonusInt);
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
