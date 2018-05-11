using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangingLamp: MonoBehaviour {

	public FallingBlock fallingBlock;

	public float upSpeed;
	public float downSpeed;

	//public GameObject pulley;

	// Use this for initialization
	void Start () {

		fallingBlock.topPos = transform.position.y;

	}
	
	// Update is called once per frame
	void Update () {

		if (fallingBlock.goingUp) {
			fallingBlock.GoingDown (this.gameObject, upSpeed, fallingBlock.botPos - 1);


		} else {
			fallingBlock.GoingUp (this.gameObject, downSpeed, fallingBlock.topPos);
		}

	}
}
