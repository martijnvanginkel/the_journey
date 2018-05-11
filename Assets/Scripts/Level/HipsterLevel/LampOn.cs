using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampOn : MonoBehaviour {

	public MachineOn machine;

	public Light light;

	// Use this for initialization
	void Start () {

		light.enabled = false;
		
	}
	
	// Update is called once per frame
	void Update () {

		if (machine.isOn) {
			light.enabled = true;
		} else {
			light.enabled = false;
		}
		
	}
}
