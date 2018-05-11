using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftSign : MonoBehaviour {

	public EmptyElevator elevator;

	public int level;

	public Light light;

	public bool allowed;

	// Use this for initialization
	void Start () {

		//light.enabled = false;
		
	}
	
	// Update is called once per frame
	void Update () {

		if (elevator.stage == level && elevator.moving == false) {
			allowed = true;
		} else {
			allowed = false;
		}


		if (allowed && elevator.liftSign) {
			light.enabled = true;
		} 


		if (elevator.liftSign == false) {
			light.enabled = false;
		}
		
	}
}
