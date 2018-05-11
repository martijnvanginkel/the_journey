using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour {

	public TurningWheel turningWheel;

	private HangingLamp hangingLamp;
	private PlayerController player;
	private LevelManager levelManager;

	private Collider2D playerCollider;
	private Collider2D blockCollider;

	public float topPos;
	public float botPos;

	private bool grounded;

	private GameObject movingObject;

	public bool goingUp;

	public LightSwitch[] lights;

	public float upSpeed;
	public float downSpeed;

	// Use this for initialization
	void Start () {

		hangingLamp = FindObjectOfType<HangingLamp> ();
		player = FindObjectOfType<PlayerController> ();
		levelManager = FindObjectOfType<LevelManager> ();

		playerCollider = player.GetComponent<Collider2D> ();
		blockCollider = GetComponent<Collider2D> ();

		//topPos = hangingLamp.transform.position.y;
		botPos = this.transform.position.y;

		movingObject = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {

		goingUp = turningWheel.wheelIsTurning;

		foreach (LightSwitch light in lights) {

			if (movingObject.transform.position.y >= botPos) {

				light.isOn = true;
			} else {
				light.isOn = false;
			}
		}

		if (turningWheel.wheelIsTurning) {
			GoingUp (movingObject, upSpeed, topPos);		
		}else{
			GoingDown (movingObject, downSpeed, botPos);
		}
	}

	public void GoingUp (GameObject movingObject, float speed, float topPos) {

		if (movingObject.transform.position.y <= topPos) {
			movingObject.transform.position += Vector3.up * (Time.deltaTime * speed);
		}
	}

	public void GoingDown (GameObject movingObject, float speed, float botPos) {

		if (movingObject.transform.position.y >= botPos) {
			movingObject.transform.position += Vector3.down * (Time.deltaTime * speed);

		} 
	}		
}
