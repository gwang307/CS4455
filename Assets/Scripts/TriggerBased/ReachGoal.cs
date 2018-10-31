using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReachGoal : MonoBehaviour {

	public EndMenuToggle endMenuToggle;

	void OnTriggerEnter(Collider c) {
		if (c.attachedRigidbody != null) {
			endMenuToggle.endGame();
		}
	}
}
