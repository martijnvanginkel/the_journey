using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMovement : MonoBehaviour {

	private PlayerController player;

	private bool playerInStopzone;

	public Light lightSource;

	// Use this for initialization
	void Start () {

		player = FindObjectOfType<PlayerController> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (playerInStopzone) {

			if (lightSource.enabled == false) {
				player.canMove = false;
			} else {
				player.canMove = true;
			}
		} 
		
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag ("Player")) {
			playerInStopzone = true;
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.CompareTag ("Player")) {
			playerInStopzone = false;
		}
	}
}
