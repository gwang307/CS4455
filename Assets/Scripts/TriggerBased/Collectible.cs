using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {
	public int collectibleScore;

	void OnTriggerEnter(Collider c) {
		if (c.attachedRigidbody != null) {
			Collector collector = c.attachedRigidbody.gameObject.GetComponent<Collector>();
			if (collector != null) {
				collector.ReceiveCollectible(collectibleScore);
				//EventManager.TriggerEvent<BombBounceEvent, Vector3>(c.transform.position);
				Destroy(this.gameObject);
			}
		}
	}
}
