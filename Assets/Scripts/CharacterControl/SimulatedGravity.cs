using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulatedGravity : MonoBehaviour {

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		rb.AddForce(transform.localScale.x * new Vector3(0f, -9.81f, 0f), ForceMode.Acceleration);
	}
}
