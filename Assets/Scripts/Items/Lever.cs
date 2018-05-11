using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour {

	public bool isOn;

	private bool playerOnLever;

	private Animator animator;

	// Use this for initialization
	void Start () {

		animator = GetComponent<Animator> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (playerOnLever && Input.GetKeyDown (KeyCode.A)) {
		
			isOn = !isOn;
		}

		animator.SetBool ("IsOn", isOn);
			
	}

	void OnTriggerEnter2D (Collider2D other) {
	
		if (other.tag == "Player"){

			playerOnLever = true;
		}
	}

	void OnTriggerExit2D (Collider2D other) {

		if (other.CompareTag ("Player")) {

			playerOnLever = false;
		}
	}
}
