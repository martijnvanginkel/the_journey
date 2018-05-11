using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour {

	private Light light;
	private Collider2D collider;

	public bool isOn;


	// Use this for initialization
	void Start () {

		light = GetComponent<Light> ();
		collider = GetComponent<Collider2D> ();
		isOn = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (isOn) {
			light.enabled = true;
			collider.enabled = true;
		} else {
			light.enabled = false;
			collider.enabled = false;
		}
		
	}
		
}
