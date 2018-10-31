using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
	public float timePassed = 0f;
	public CanvasGroup pauseCanvasGroup;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!pauseCanvasGroup.interactable) {
			timePassed += Time.deltaTime;
		}
	}
}
