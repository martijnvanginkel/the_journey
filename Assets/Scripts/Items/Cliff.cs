using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cliff : MonoBehaviour {

	public PlayerController thePlayer;

	private Rigidbody2D rb;

	private Collider2D playerCollider;
	private Collider2D cliffCollider;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D> ();

		thePlayer = FindObjectOfType<PlayerController> ();
		cliffCollider = GetComponent<Collider2D> ();
		playerCollider = thePlayer.GetComponent<Collider2D> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (cliffCollider.IsTouching (playerCollider)) {
		
			rb.isKinematic = false;

		}
		
	}


}
