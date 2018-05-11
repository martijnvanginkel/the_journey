using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLampPath : MonoBehaviour {

	public Vector3[] positions;

	public int stage = 0;

	public float speed;

	//public GameObject cable;
	public GameObject lantern;
	public GameObject[] pulleys;

	public bool receiverIsOn;
	public bool machineIsOn;

	public float receiverConnectTime;

	public Animator machineAnimator;
	public Animator receiverAnimator;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update ()
	{
		// Machine en receiver animations
		machineAnimator.SetBool ("IsOn", machineIsOn);
		receiverAnimator.SetBool ("IsOn", receiverIsOn);

		// Turn off if back to startingpoint
		if (stage == positions.Length && receiverIsOn) {
			stage = 0;
		}

		if(machineIsOn){

			StartCoroutine("ReceiverOnCo");
		}

		if (receiverIsOn) {

			MoveLantern();
				
		} 
	}

	public IEnumerator ReceiverOnCo () {

		yield return new WaitForSeconds(receiverConnectTime);
		receiverIsOn = true;
	}

	void MoveLantern () {
		
		lantern.transform.position = Vector3.MoveTowards (new Vector3 (lantern.transform.position.x, lantern.transform.position.y, lantern.transform.position.z), positions [stage], speed * Time.deltaTime);

		// Turn pulleys
		foreach (GameObject pulley in pulleys){
			pulley.transform.Rotate (new Vector3 (0, 0, 100) * Time.deltaTime * 5);
		}

		if (lantern.transform.position == positions [stage]) {

			if (stage < (positions.Length)) {
				stage++;
			} 
		}

	}
}
