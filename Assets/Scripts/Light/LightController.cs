using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {

	public PlayerController thePlayer;

	public GameObject display;

	//public PlayerPush playerPushing;

	public bool inPickUpRange;
	public bool holdingLight;

	public bool isLantern;
	public bool isTorch;

	// Use this for initialization
	void Start () {

		thePlayer = FindObjectOfType<PlayerController> ();
		//playerPushing = FindObjectOfType<PlayerPush> ();
		
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (Input.GetKeyDown (KeyCode.LeftAlt)) {

			if (inPickUpRange) {

				holdingLight = true;
			} 
		}
			
		if (holdingLight) {

			GetComponent<Renderer> ().enabled = false;
			transform.parent = thePlayer.transform;

			display.SetActive (false);
		} 
		//if (!holdingLight) {

		//	GetComponent<Renderer> ().enabled = true;
		//	transform.localScale = new Vector3 (1f, 1f, 1f);
		//	transform.parent = null;
	

		//}

	}
		
		
	void OnTriggerEnter2D (Collider2D other) {

		if (other.CompareTag  ("Player")) {
			inPickUpRange = true;
		}
	}

	void OnTriggerExit2D (Collider2D other) {

		if (other.CompareTag ("Player")) {
			inPickUpRange = false;
		}
	}
}
