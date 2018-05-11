using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampMachine : MonoBehaviour {

	public bool playerOnMachine;

	public MovingLampPath movingLamp;

	public float startingUpTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (playerOnMachine && Input.GetKey (KeyCode.LeftAlt)){
			movingLamp.machineIsOn = true;
		}
		
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag ("Player")) {
			playerOnMachine = true;
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			playerOnMachine = false;
		}	
	}
}
