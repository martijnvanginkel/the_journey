using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningWheel : MonoBehaviour {

	private PlayerController player;
	private CameraController camera;

	public bool inRange;
	public bool wheelIsTurning = false;

	public int cameraZoom;
	public int cameraXPos;
	public int cameraYPos;


	// Use this for initialization
	void Start () {

		player = FindObjectOfType<PlayerController> ();
		camera = FindObjectOfType<CameraController> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (inRange && player.myRigidbody.velocity.magnitude < 0.5) {
			if (Input.GetKey(KeyCode.LeftAlt)) {
				player.canMove = false;
				wheelIsTurning = true;
			} else {

				player.canMove = true;
				camera.lockedCamera = false;
				wheelIsTurning = false;
				player.turningWheel = false;
			}
		}


		if (wheelIsTurning) {
			transform.Rotate (new Vector3 (0, 0, 25) * Time.deltaTime * 5);
			player.turningWheel = true;
			player.canMove = false;

			camera.lockedCamera = true;
			camera.normal = cameraZoom;
			camera.viewPos.x = cameraXPos;
			camera.viewPos.y = cameraYPos;
		} 
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag ("Player")) {
			inRange = true;
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.CompareTag ("Player")) {
			inRange = false;
		}
	}
}
