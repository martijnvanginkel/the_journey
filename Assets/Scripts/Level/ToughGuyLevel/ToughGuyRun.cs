using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToughGuyRun : MonoBehaviour {

	private SlidingLamp slidingLamp;
	private NpcConversation toughGuyConv;
	private Collider2D guyCollider;
	private Animator animator;
	private Rigidbody2D rb;

	public PlatformScript platform;
	public GameObject[] guyPositions;
	public Collider2D platformCollider;
	public GameObject teleportParticle;


	public int stage;
	public float speed;
	public bool guyWalking;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D> ();
		slidingLamp = FindObjectOfType<SlidingLamp> ();
		toughGuyConv = FindObjectOfType<NpcConversation> ();
		animator = GetComponent<Animator> ();
		guyCollider = GetComponent<Collider2D> ();

		stage = 0;

	}
	
	// Update is called once per frame
	void Update () {


		// Make guy child of platform
		if (guyCollider.IsTouching (platformCollider)) {
			transform.SetParent (platform.transform);

		}

		// Gets triggered by slidingLamp position
		if (guyWalking) {

			// Change rotation and position
			transform.localScale = new Vector3 (1f, 1f, 1f);
			transform.position = Vector3.MoveTowards (new Vector3 (transform.position.x, transform.position.y, transform.position.z), new Vector3 (guyPositions [stage].transform.position.x, transform.position.y, transform.position.z), speed * Time.deltaTime);

			// If the guy is at its position..
			if (transform.position.x == guyPositions [stage].transform.position.x) {
				// Stop walking and freeze XConstraint
				guyWalking = false;
				//rb.constraints = RigidbodyConstraints2D.FreezePositionX;

				// To next position if its not the last
				if (stage != guyPositions.Length - 1) {
					stage++;
				} else {
					// If its the last position..
					rb.constraints = RigidbodyConstraints2D.FreezePositionY;
					guyCollider.isTrigger = true;
					transform.SetParent (null);
					guyWalking = false;
					transform.localScale = new Vector3 (-1f, 1f, 1f);

					// If at his last position, talk and start dissapear coroutine
					if (toughGuyConv.playerInRange) {

						toughGuyConv.EnableTextBox ();
						toughGuyConv.theText.text = "Wow thank you, now I can finally leave!";

						StartCoroutine ("DestroyToughGuy");

					}
				}
				// Start the machine
				slidingLamp.StartCoroutine ("StartMachineCo");
			} 
		} 
			
		animator.SetBool ("IsWalking", guyWalking);
	}

	public IEnumerator DestroyToughGuy () {
		
		toughGuyConv.enabled = false;
		yield return new WaitForSeconds (2);
		Instantiate (teleportParticle, transform.position, transform.rotation);
		toughGuyConv.DisableTextBox ();
		Destroy (this.gameObject);
	}
}
