using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDoor : MonoBehaviour {

	private PlayerController player;

	public bool playerOnDoor;

	public GameObject otherDoor;

	private Animator animator;

	// Use this for initialization
	void Start () {

		player = FindObjectOfType<PlayerController> ();
		animator = GetComponent<Animator> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (playerOnDoor && Input.GetKeyDown (KeyCode.LeftAlt)) {

			player.transform.position = otherDoor.transform.position;
		}

		animator.SetBool ("OnDoor", playerOnDoor);
		
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag("Player")) {
			playerOnDoor = true;
		}
	}
	void OnTriggerExit2D (Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			playerOnDoor = false;
		}	
	}
}
