using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOut : MonoBehaviour {

	public CameraController camera;

	// Use this for initialization
	void Start () {
		camera = FindObjectOfType<CameraController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag ("Player")) {
			camera.lockedCamera = true;
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.CompareTag ("Player")) {
			camera.lockedCamera = false;
		}
	}
}
