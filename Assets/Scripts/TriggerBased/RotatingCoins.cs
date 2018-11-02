using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCoins : MonoBehaviour {

	public float rotationSpeedX = 180f;
	public float rotationSpeedY = 0f;
	public float rotationSpeedZ = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate(new Vector3(rotationSpeedX, rotationSpeedY, rotationSpeedZ) * Time.deltaTime);
	}
}
