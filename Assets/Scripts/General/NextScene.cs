using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScene : MonoBehaviour {

	public PlayerController player;

	public string nextLevel;

	public bool onDoor;

	private Animator animator;

	// Use this for initialization
	void Start () {

		player = FindObjectOfType<PlayerController> ();
		animator = GetComponent<Animator> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (onDoor && Input.GetKey (KeyCode.LeftAlt)) {
			Application.LoadLevel(nextLevel);
		}

		animator.SetBool("OnDoor", onDoor);
		
	}

	void OnTriggerEnter2D (Collider2D other) {
	
		if (other.CompareTag ("Player")) {
			onDoor = true;
		}
	}

	void OnTriggerExit2D (Collider2D other) {

		if (other.CompareTag ("Player")) {
			onDoor = false;
		}
	}

}
