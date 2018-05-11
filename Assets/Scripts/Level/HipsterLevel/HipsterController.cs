using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HipsterController : MonoBehaviour {

	private PlayerController player;
	private NpcConversation npc;

	public float npcTrigger;
	public bool npcCanWalk = false;

	public float walkSpeed;

	public Vector3 walkToPos;

	public bool inRange;
	private bool isWalking;

	private Animator animator;
	private Rigidbody2D rb;

	public float walkDistance;

	public Collider2D bigBlock;
	public bool hit;

	public GameObject teleportParticle;

	// Use this for initialization
	void Start () {

		player = FindObjectOfType<PlayerController> ();
		animator = GetComponent<Animator> ();

		npc = GetComponent<NpcConversation> ();
		walkDistance = transform.position.x + walkDistance;

		rb = GetComponent<Rigidbody2D> ();
		rb.isKinematic = true;

	}
	
	// Update is called once per frame
	void Update () {

		hit = GetComponent<Collider2D> ().IsTouching (bigBlock);

		// Check if player is past triggerpoint
		if (player.transform.position.x < npcTrigger) {
			npcCanWalk = true;
			npc.secondConv = true;
		}

		if (npcCanWalk && !hit) {
			if (inRange) {
				rb.isKinematic = false;
				GetComponent<Collider2D> ().isTrigger = false;
				isWalking = true;
			}else {
				transform.localScale = new Vector3 (-1f, 1f, 1f);
			}
		} else {
			isWalking = false;

		}
	
		if (hit) {
			npc.convLength = 3;
		}

		// Move to position
		if (isWalking) {

			transform.localScale = new Vector3 (1f, 1f, 1f);
			transform.position = Vector3.MoveTowards (transform.position, new Vector3 (walkDistance, transform.position.y, transform.position.z), walkSpeed * Time.deltaTime);

			// If at endposition
			if (transform.position.x == walkDistance) {

				isWalking = false;
				if (inRange) {
					StartCoroutine ("DestroyHipster");
				}
			}
		} else {
			transform.localScale = new Vector3 (-1f, 1f, 1f);
		}
			
		animator.SetBool ("IsWalking", isWalking);
	}

	public IEnumerator DestroyHipster () {

		transform.localScale = new Vector3 (-1f, 1f, 1f);

		yield return new WaitForSeconds (1);
		Instantiate (teleportParticle, new Vector3(transform.position.x, transform.position.y, -4f), transform.rotation);
		npc.DisableTextBox ();
		Destroy (this.gameObject);
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
