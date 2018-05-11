using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour {

	private PlayerController player;
	private SlidingLamp slidingLamp;

	public Vector3[] positions;
	public float speed;
	public float startSpeed;

	private Collider2D platformCollider;
	private Collider2D playerCollider;

	private int stage;

	private float distancePlatform;
	private float distanceLamp;

	// Use this for initialization
	void Start () {

		player = FindObjectOfType<PlayerController> ();
		slidingLamp = FindObjectOfType<SlidingLamp> ();

		platformCollider = GetComponent<Collider2D> ();
		playerCollider = player.GetComponent<Collider2D> ();

		startSpeed = slidingLamp.speed;

		speed = slidingLamp.speed;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		// If on collider make child of platform
		if (platformCollider.IsTouching (playerCollider)) {
			player.transform.SetParent (this.transform);
		} else {
			// Don't be a child of platform anymore
			player.transform.SetParent (null);
		}
			
		// If turned on start movement
		if (slidingLamp.isOn) {
			
			// If at position move to next position
			if (transform.position == positions [stage]) {

				// distance between waypoints
				if (positions.Length - 1 != stage) {
					distancePlatform = Vector2.Distance (positions [stage], positions [stage + 1]);
					distanceLamp = Vector2.Distance (slidingLamp.waypoints [stage].transform.position, slidingLamp.waypoints [stage + 1].transform.position);
				}

				speed = (distancePlatform / distanceLamp) * startSpeed;

				if (stage != positions.Length - 1) {
					stage++;
				}
			}

			// Move to position
			transform.position = Vector3.MoveTowards (new Vector3 (transform.position.x, transform.position.y, transform.position.z), positions [stage], speed * Time.deltaTime);

		} 
	}
}
