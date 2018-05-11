using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampButton : MonoBehaviour
{


	public bool playerOnButton;

	public Light lightSource;

	private Animator animator;
	private bool isOn;

	public Animator receiver;
	private CameraController camera;

	// Use this for initialization
	void Start ()
	{
		animator = GetComponent<Animator> ();

		camera = FindObjectOfType<CameraController> ();

		lightSource.enabled = false;

	}

	// Update is called once per frame
	void Update ()
	{

		if (playerOnButton && Input.GetKeyDown (KeyCode.LeftAlt)) {
			isOn = true;
			lightSource.enabled = true;
			camera.lockedCamera = true;
			camera.viewPos.x = 12;
			camera.viewPos.y = 8;
		}

		receiver.SetBool ("IsOn", isOn);
		animator.SetBool ("IsOn", isOn);
	}

	void OnTriggerEnter2D (Collider2D other)
	{

		if (other.CompareTag ("Player")) {
			playerOnButton = true;
		}

	}

	void OnTriggerExit2D (Collider2D other)
	{

		if (other.CompareTag ("Player")) {
			playerOnButton = false;
		}

	}
}
