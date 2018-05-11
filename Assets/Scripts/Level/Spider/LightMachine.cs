using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMachine : MonoBehaviour
{
	private Animator animator;

	private bool playerOnMachine;
	public bool machineOn;

	public Light charger;
	public Light [] lights;

	private LampSwitch [] lightSwitches;
	private LiftSign [] liftSigns;
	private HallElevator hallElevator;
	private CameraController camera;
	private GirlController girl;

	public float waitTime;
	public bool allowed = true;
	private bool flicker = false;

	public float tParam = 0f;

	// Use this for initialization
	void Start ()
	{
		animator = GetComponent<Animator> ();

		lightSwitches = FindObjectsOfType<LampSwitch> ();
		liftSigns = FindObjectsOfType<LiftSign> ();
		hallElevator = FindObjectOfType<HallElevator> ();
		camera = FindObjectOfType<CameraController> ();
		girl = FindObjectOfType<GirlController> ();

		TurnOnLights (false);
		charger.intensity = 0;
	}

	// Update is called once per frame
	void Update ()
	{

		if (playerOnMachine && Input.GetKeyDown (KeyCode.LeftAlt) && allowed) {
			allowed = false;
			machineOn = true;
		}

	

			if (machineOn) {
				ChargePower ();
			}


		animator.SetBool ("IsOn", !allowed);
	}

	void TurnOnLights (bool on) {

		hallElevator.enabled = on;

		// Exceptions for the hall elevator
		if (hallElevator.enabled == true) {
			hallElevator.gameObject.GetComponent<Collider2D> ().isTrigger = true;
		} else {
			if (hallElevator.playerInElevator == false) {
				hallElevator.gameObject.GetComponent<Collider2D> ().isTrigger = false;
			} else {
				hallElevator.elevatorLight.enabled = false;
				hallElevator.lightCollider.enabled = false;
			}
		}

		// Enable/disable scripts
		foreach(LampSwitch lightSwitch in lightSwitches) {
			lightSwitch.enabled = on;
		}
		foreach (LiftSign liftSign in liftSigns) {
			liftSign.enabled = on;
		}
		// Switch all lights
		foreach (Light light in lights) {
			light.enabled = on;
			if (light.gameObject.GetComponent<Collider2D>() != null) {
				light.gameObject.GetComponent<Collider2D> ().enabled = on;
			}
		}
	}

	// - time.deltatime
	void ChargePower () {
		if (tParam < 1) {
			tParam += Time.deltaTime * 2f;
			charger.intensity = Mathf.Lerp (0, 8, tParam);

		} else {

			camera.lockedCamera = true;
			camera.normal = 11;
			camera.viewPos.x = 8f;
			camera.viewPos.y = -5f;

			machineOn = false;
			StartCoroutine ("TurnOnLightCo");
		}
	}
	private IEnumerator TurnOnLightCo () {

		// Keep light on for ..
        TurnOnLights (true);
		yield return new WaitForSeconds (waitTime);

		// Flicker light
		TurnOnLights (false);
		yield return new WaitForSeconds (0.8f);
		TurnOnLights (true);
		yield return new WaitForSeconds (0.3f);
		TurnOnLights (false);
		yield return new WaitForSeconds (0.2f);
		TurnOnLights (true);
		yield return new WaitForSeconds (2.5f);

		// Turn off lights and allow restart
		charger.intensity = 0f;
		tParam = 0f;
		camera.lockedCamera = false;
        TurnOnLights (false);
		allowed = true;
	}


	void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag ("Player")) {
			playerOnMachine = true;
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			playerOnMachine = false;
		}	
	}
}
