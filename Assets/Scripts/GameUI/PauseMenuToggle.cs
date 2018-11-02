using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class PauseMenuToggle : MonoBehaviour {

	public CanvasGroup canvasGroup;
	public EndMenuToggle endMenuToggle;

	void Awake() {
		canvasGroup = GetComponent<CanvasGroup>();
		if (canvasGroup == null)
			Debug.LogError("Required canvas group component is missed.", canvasGroup);
	}

	// Use this for initialization
	void Start() {
		
	}
	
	// Update is called once per frame
	void Update() {
		if (endMenuToggle.canvasGroup.interactable == false && Input.GetButtonUp("Pause")) {
			if (canvasGroup.interactable) {
				canvasGroup.interactable = false;
				canvasGroup.blocksRaycasts = false;
				canvasGroup.alpha = 0f;
				Time.timeScale = 1f;
			} else {
				canvasGroup.interactable = true;
				canvasGroup.blocksRaycasts = true;
				canvasGroup.alpha = 1f;
				Time.timeScale = 0f;
			}
		}
	}
}
