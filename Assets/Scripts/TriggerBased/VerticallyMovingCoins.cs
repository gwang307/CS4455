using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticallyMovingCoins : MonoBehaviour {
	public float upperBound;
	public float lowerBound;
	public float verticalSpeed;
	private bool movingUp = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.y >= upperBound)
			movingUp = false;
		else if (this.transform.position.y <= lowerBound)
			movingUp = true;

		if (movingUp)
			this.transform.Translate(new Vector3(-Time.deltaTime * verticalSpeed, 0, 0));
		else
			this.transform.Translate(new Vector3(Time.deltaTime * verticalSpeed, 0, 0));
	}
}
