using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuddenKillWater : MonoBehaviour {

	Transform player;

	void Start() {
		player = GameObject.Find("MC2").GetComponent<Transform>();
	}

	void OnTriggerEnter(Collider c) {
		if (c.attachedRigidbody != null) {
			Collector collector = c.attachedRigidbody.gameObject.GetComponent<Collector>();
			if (collector != null) {
				player.position = new Vector3(-136.98f, 12, 169.3f);
				collector.score = Mathf.Max(collector.score - 500, 0);
				collector.updateScoreUI();
			}
		}
	}

}
