using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrigger : MonoBehaviour {

	private PlayerController player;

	private Collider2D playerCollider;
	public GameObject fallObject;
	private Collider2D triggerCollider;

	public bool playerOnTrigger;

	// Use this for initialization
	void Start () {

		player = FindObjectOfType<PlayerController> ();
		playerCollider = player.GetComponent<Collider2D> ();
		triggerCollider = this.GetComponent<Collider2D> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (playerCollider.IsTouching (triggerCollider)) {
		
			playerOnTrigger = true;
		}

		if (playerOnTrigger) {
			fallObject.GetComponent<Rigidbody2D> ().isKinematic = false;	
		}
	}


}
