using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

//	private PlayerController player;

//	private Collider2D playerCollider;

//	private Collider2D trapCollider;

	public bool isOnTrap = false;

	public Collider2D[] childObjects;

	public float openTime;
	public float closeTime;


	private Animator animator;

	// Use this for initialization
	void Start () {

		//player = FindObjectOfType<PlayerController> ();

		//playerCollider = player.GetComponent<Collider2D> ();
		//trapCollider = GetComponent<BoxCollider2D> ();

		childObjects = GetComponentsInChildren<Collider2D> ();

		animator = GetComponent<Animator> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		animator.SetBool ("IsOnTrap", isOnTrap);
	}

	public IEnumerator OpenTrap () {

		yield return new WaitForSeconds(openTime);
		isOnTrap = true;
		foreach (Collider2D child in childObjects) {

			child.enabled = false;
		}
		yield return new WaitForSeconds(1f);
		foreach (Collider2D child in childObjects) {

			child.enabled = true;
		}

	}

	public IEnumerator CloseTrap () {

		yield return new WaitForSeconds(closeTime);
		isOnTrap = false;

		yield return new WaitForSeconds(1f);

	
	}

	void OnTriggerEnter2D (Collider2D other) {

		if (other.CompareTag ("Player")) {
			StartCoroutine ("OpenTrap");
		}

	}

	void OnTriggerExit2D (Collider2D other) {

		if (other.CompareTag ("Player")) {
			StartCoroutine ("CloseTrap");
		}

	}
}
