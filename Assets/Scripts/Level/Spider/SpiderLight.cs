using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderLight : MonoBehaviour {

	private TurningWheel turningWheel;

	public float highPoint;
	public float lowPoint;

	// Use this for initialization
	void Start () {

		turningWheel = FindObjectOfType<TurningWheel> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (turningWheel.wheelIsTurning) {
			MoveUp ();
		} else {
			MoveDown ();
		}

		if (transform.position.y <= lowPoint) { 
			// Levelmanager ...
			// text = 
		}
	}

	private void MoveUp () { 
		if (transform.position.y < highPoint) {
			transform.Translate (Vector3.up* Time.deltaTime, Space.World);
		} 
	}

	private void MoveDown () {
		if (transform.position.y > lowPoint) { 
			transform.Translate (Vector3.down * (Time.deltaTime / 5f), Space.World);
		}
	}
}
