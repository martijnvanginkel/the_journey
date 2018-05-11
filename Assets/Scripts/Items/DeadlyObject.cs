using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlyObject : MonoBehaviour {

	private PlayerController player;
	private LevelManager levelManager;

	private Collider2D objectCollider;
	private Collider2D playerCollider;

	public bool hitPlayer;

	// Use this for initialization
	void Start () {

		levelManager = FindObjectOfType<LevelManager> ();
		player = FindObjectOfType<PlayerController> ();

		playerCollider = player.GetComponent<Collider2D> ();
		objectCollider = GetComponent<Collider2D> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		hitPlayer = objectCollider.IsTouching(playerCollider);

		if (hitPlayer) {
			levelManager.messageInput = "You died";
			levelManager.playerIsDead = true;
		}
		
	}

	void OnCollision2DEnter (Collider2D other) {

		if (other.CompareTag ("Player")) {
			hitPlayer = true;
		}

	}

	void OnCollision2DExit (Collider2D other) {
		if (other.CompareTag ("Player")) {
			hitPlayer = false;
		}
	}
		
}
