using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyElevator : MonoBehaviour
{

	private PlayerController player;
	private bool playerInElevator;

	public GameObject [] pulleys;

	private Vector2 startVector;
	public int [] level;

	public int stage;
	public float speed;
	public float pauseSeconds;

	public bool moving;
	public bool increment;

	public bool liftSign;

	// Use this for initialization
	void Start ()
	{
		player = FindObjectOfType<PlayerController> ();
		startVector = transform.position;

	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		if (playerInElevator && Input.GetKeyDown (KeyCode.LeftAlt) && moving == false) {
			StartCoroutine ("WaitAndStart");
		}

		if (moving) {
			MoveElevator ();
		}

	}

	// Increment level on which the elevator is
	void Increment ()
	{
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
	void MoveElevator ()
	{

		transform.position = Vector3.MoveTowards (new Vector3 (transform.position.x, transform.position.y, transform.position.z), new Vector3 (startVector.x, startVector.y + level [stage], transform.position.z), speed * Time.deltaTime);

		if (transform.position.y == startVector.y + level[stage]) {
			moving = false;
			liftSign = false;
		}

		foreach (GameObject pulley in pulleys) {
			pulley.transform.Rotate (new Vector3 (0, 0, 100) * Time.deltaTime * 5);
		}
	}

	public IEnumerator WaitAndStart ()
	{
		liftSign = true;
		yield return new WaitForSeconds (pauseSeconds);
        Increment ();
		moving = true;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			playerInElevator = true;
			player.transform.SetParent (this.transform);
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			playerInElevator = false;
			player.transform.SetParent (null);
		}

	}
}
