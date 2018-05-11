using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineOn : MonoBehaviour {

//	private PlayerController player;

	private bool inRange;
	public bool isOn;

	private Animator animator;

	// Use this for initialization
	void Start () {

		//player = FindObjectOfType<PlayerController> ();
		animator = GetComponent<Animator> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (inRange && Input.GetKeyDown (KeyCode.LeftAlt)) {
			isOn = !isOn;
		}

		animator.SetBool ("IsOn", isOn);

	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.CompareTag ("Player")) {
			inRange = true;
		}
	}

	void OnTriggerExit2D (Collider2D other){
		if (other.CompareTag ("Player")) {
			inRange = false;
		}
	}
}
