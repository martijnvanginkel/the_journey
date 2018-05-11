using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {

	public PlayerController thePlayer;
	public Lever theLever;
//	public CameraZoom theCamera;

	public Vector2 positionB;
	public Vector2 positionA;

	//private Collider2D platformCollider;
//	private Collider2D playerCollider;

	public float speed;

	public bool onPlatform;
	public bool turnedOn;

	public float waitTime;

	// Use this for initialization
	void Start () {

		thePlayer = FindObjectOfType<PlayerController> ();
//		theCamera = FindObjectOfType<CameraZoom> ();
		//platformCollider = GetComponent<Collider2D> ();
		//playerCollider = thePlayer.GetComponent<Collider2D> ();

	}
	
	// Update is called once per frame

	void Update () {
		
		if (theLever.isOn) {
			StartCoroutine ("GoUp");
		}

		if (!theLever.isOn) {
			StartCoroutine ("GoDown");
		}

//		if (platformCollider.IsTouching (playerCollider)) {
//			theCamera.isZoomed = !theCamera.isZoomed;
//		}
//
	}

	public IEnumerator GoUp() {

		yield return new WaitForSeconds(waitTime);
		transform.position = Vector2.MoveTowards (new Vector2 (transform.position.x, transform.position.y), positionA, speed * Time.deltaTime);

	}

	public IEnumerator GoDown() {

		yield return new WaitForSeconds(waitTime);
		transform.position = Vector2.MoveTowards (new Vector2 (transform.position.x, transform.position.y), positionB, speed * Time.deltaTime);

	}

}