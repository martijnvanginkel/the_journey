using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulleyController : MonoBehaviour {

	public PlayerController player;

	//public SlidingLamp slidingObject;

	public bool isOn;

	public bool onTurningwheel;

	public GameObject pulley;

	public float speed;
	public float value;

	public bool goingDown;
	private float startPos;

	public float startingDistance;

	//public LineRenderer lineRenderer;

	// Use this for initialization
	void Start () {

		//slidingObject = FindObjectOfType<SlidingLamp> ();
		startPos = pulley.transform.position.y;
		player = FindObjectOfType<PlayerController> ();

		pulley.GetComponent<Light> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (pulley.transform.position.y >= startPos + value ) {
			goingDown = true;
		}
		if (pulley.transform.position.y <= startPos - value) {
			goingDown = false;
		}

		if (onTurningwheel && isOn != true) {


			if (Input.GetKey (KeyCode.A)) {

				//pulley.GetComponent<Light> ().enabled = true;
				pulley.GetComponent<Light> ().enabled = true;

				player.turningWheel = true;
				player.canMove = false;

				transform.Rotate (new Vector3 (0, 0, 25) * Time.deltaTime * 5);


				if (goingDown) {
					pulley.transform.position += Vector3.down * (Time.deltaTime * speed);
					pulley.transform.Rotate (new Vector3 (0, 0, -100) * Time.deltaTime * 7);
				} else {
				
					pulley.transform.position += Vector3.up * (Time.deltaTime * speed);
					pulley.transform.Rotate (new Vector3 (0, 0, 100) * Time.deltaTime * 7);
				}
			}
				 else {
					player.turningWheel = false;
					player.canMove = true;

					pulley.GetComponent<Light> ().enabled = false;
				}

		} 
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag ("Player")) {
			onTurningwheel = true;
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.CompareTag ("Player")) {
			onTurningwheel = false;
		}
	}

}
