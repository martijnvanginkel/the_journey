using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallElevator : MonoBehaviour
{
	private PlayerController player;
	public bool playerInElevator;

	public GameObject [] pulleys;

	[HideInInspector]
	public bool doorOpen;

	public Light elevatorLight;
	public Collider2D lightCollider;

	private Animator animator;

	private Vector2 startVector;
	public int [] level;

	public int stage;
	public float speed;
	public float pauseSeconds;

	public bool moving;
	private bool increment;

	// Use this for initialization
	void Start ()
	{
		player = FindObjectOfType<PlayerController> ();
		startVector = transform.position;
		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		if (playerInElevator && Input.GetKeyDown (KeyCode.LeftAlt) && moving == false && player.myRigidbody.velocity.magnitude < 4) {
			StartCoroutine ("WaitAndStart");
           // Increment ();
		}

		if (moving) {
			MoveElevator ();
		}

		if (playerInElevator) {
			doorOpen = true;
			elevatorLight.enabled = true;
			lightCollider.enabled = true;
			if (moving) {
				player.canMove = false;
			} else { 
				player.canMove = true;
			}
		} else {
			doorOpen = false;
			elevatorLight.enabled = false;
			lightCollider.enabled = false;
		}

		animator.SetBool ("InElevator", doorOpen);
	}

	// Increment level on which the elevator is
	void Increment () {

		if (moving == false) {

			if (stage == 0 || stage == level.Length - 1) {
				increment = !increment;
			}
			if (increment) {
				stage++;
			} else {
				stage--;
			}
		}
	}

	// Move the elevator to the current level
	void MoveElevator () { 

		transform.position = Vector3.MoveTowards (new Vector3 (transform.position.x, transform.position.y, transform.position.z), new Vector3 (startVector.x, startVector.y + level [stage], transform.position.z), speed * Time.deltaTime);

		if (transform.position.y == startVector.y + level [stage]) {
			moving = false;
		}

		foreach (GameObject pulley in pulleys) {
			pulley.transform.Rotate (new Vector3 (0, 0, 100) * Time.deltaTime * 5);
		}
	}

	public IEnumerator WaitAndStart () {

		yield return new WaitForSeconds (pauseSeconds);
        Increment ();
		moving = true;	
       
	}

	void OnTriggerEnter2D (Collider2D other) { 
		if (other.CompareTag ("Player")) {
			playerInElevator = true;
			player.transform.SetParent (this.transform);
		}
		if (other.CompareTag ("NPC")) {
			playerInElevator = true;
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.CompareTag ("Player")) {
			playerInElevator = false;
			player.transform.SetParent (null);
		}
		if (other.CompareTag ("NPC")) {
			playerInElevator = false;
		}
	}
}
