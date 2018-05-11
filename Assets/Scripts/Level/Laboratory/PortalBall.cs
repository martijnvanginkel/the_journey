using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBall : MonoBehaviour {

	private PlayerController player;
	public GameObject flashScreen;

	public bool playerInPortal;

	public float portalTime;
	private float start;
	private float value;

	private Animator animator;

	// Use this for initialization
	void Start () {

		player = FindObjectOfType<PlayerController> ();
		animator = GetComponent<Animator> ();

		flashScreen.GetComponent<SpriteRenderer> ().enabled = false;

		start = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (playerInPortal) {
			StartCoroutine ("PortalFlash");
		}

		animator.SetBool ("PlayerInPortal", playerInPortal);

	}

	void OnTriggerEnter2D (Collider2D other) {
	
		if (other.CompareTag ("Player")) {
			playerInPortal = true;
		}
	}

	public IEnumerator PortalFlash () {
		player.canMove = false;

		flashScreen.GetComponent<SpriteRenderer> ().enabled = true;
		value = Mathf.Lerp (0f, 1f, start += (Time.deltaTime / portalTime));
		flashScreen.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, value);
		yield return new WaitForSeconds (portalTime);
		Application.LoadLevel ("TutorialLevel");
	}
}
