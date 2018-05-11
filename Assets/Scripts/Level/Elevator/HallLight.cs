using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallLight : MonoBehaviour {

	public HallElevator elevator;
	//private ElevatorGuyController elevatorGuyController;

	public int stage;
	private bool on;

	public GameObject [] lights;

	// Use this for initialization
	void Start () {

		//elevatorGuyController = FindObjectOfType<ElevatorGuyController> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (elevator.stage == stage && elevator.moving == false) {
			LightOn (true);

		} else {
			
			LightOn (false);
		}
	}

	public void LightOn (bool on) { 
		foreach (GameObject light in lights)
		{
			light.GetComponent<Collider2D>().enabled = on;
			light.GetComponent<Light>().enabled = on;	
		}
	}
}
