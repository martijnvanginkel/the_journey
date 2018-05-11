using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampSwitch : MonoBehaviour {

	private PlayerController player;

	// Switch
	private bool playerOnSwitch;

	public bool isOn;
	public bool allOn;

	private GameObject red;
	private GameObject green;

	//Lamp
	public GameObject greenLight;
	public GameObject redLight;

	// Use this for initialization
	void Start () {

		player = FindObjectOfType<PlayerController> ();

		green = this.transform.Find ("Green").gameObject;
		red = this.transform.Find ("Red").gameObject;
	}
	
	// Update is called once per frame
	void Update () {

		if (playerOnSwitch && Input.GetKeyDown (KeyCode.LeftAlt)) {
			isOn = !isOn;
		}

		if (allOn) {
			AllOn ();
		} else { 
			
			if (isOn) {
				LightOn (true);
			} else {
				LightOn (false);
			}
		}
	}

	public void LightOn (bool isTrue) { 

		// Switch
		red.GetComponent<Light> ().enabled = !isOn;
		green.GetComponent<Light> ().enabled = isOn;

		// Lamps
		greenLight.GetComponent<Light> ().enabled = isOn;
		greenLight.GetComponent<Collider2D> ().enabled = isOn;
		redLight.GetComponent<Light> ().enabled = !isOn;
		redLight.GetComponent<Collider2D> ().enabled = !isOn;
	}

	public void AllOn () {

		isOn = true;
		
		greenLight.GetComponent<Light> ().enabled = isOn;
		redLight.GetComponent<Light> ().enabled = isOn;

		greenLight.GetComponent<Collider2D> ().enabled = isOn;
		redLight.GetComponent<Collider2D> ().enabled = isOn;
	}


	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			playerOnSwitch = true;
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			playerOnSwitch = false;
		}	
	}
}
