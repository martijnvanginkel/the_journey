using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingLamp : MonoBehaviour {

	public GameObject[] waypoints;
	public float speed;
	public bool isOn;

	public GameObject lantern;
	public int stage;
	//private bool forward;
	private bool onStartbutton;

	public ToughGuyRun toughGuy;
	//public NpcConversation npcConv;

	private Animator machineAnimator;
	public Animator receiverAnimator;

	private bool machineOn;

	public PulleyController[] pulleyControllers;


	// Use this for initialization
	void Start () {

		toughGuy = FindObjectOfType<ToughGuyRun> ();
		//npcConv = FindObjectOfType<NpcConversation>()
		pulleyControllers = FindObjectsOfType<PulleyController>();

		lantern.transform.position = waypoints[stage].transform.position;

		machineAnimator = GetComponent<Animator> ();
		//forward = true;
	}
	
	// Update is called once per frame
	void Update () {

		// If start the machine, guy walks to platform first
		if (onStartbutton && Input.GetKey (KeyCode.A)) {
			toughGuy.guyWalking = true;
			machineOn = true;
		}
		// If machine is on, move towards next waypoint

		foreach(PulleyController pulley in pulleyControllers)
		if(pulley.isOn == true){
			isOn = true;
		}

		if (isOn) {
			
			lantern.transform.position = Vector3.MoveTowards (new Vector3 (lantern.transform.position.x, lantern.transform.position.y, lantern.transform.position.z), waypoints [stage].transform.position, speed * Time.deltaTime);
		}
			
		// If the lantern is at a waypoint
		if (lantern.transform.position == waypoints [stage].transform.position) {

			// If its not the last point, ++
			if (stage != waypoints.Length - 1) {
				stage++;
			}
			if (lantern.transform.position == waypoints[waypoints.Length - 1].transform.position) {
				isOn = false;

				toughGuy.guyWalking = true;
				
			}
		}
		// turn pulleys
		foreach (GameObject waypoint in waypoints) {
			if (isOn) {
				waypoint.transform.Rotate (new Vector3 (0, 0, 100) * Time.deltaTime);
			}
		}

		// set lines between from point to the next
		for (int i = 0; i < waypoints.Length - 1; i++) {
			waypoints[i].GetComponent<LineRenderer> ().positionCount = 2;
			waypoints[i].GetComponent<LineRenderer> ().SetPosition(0, new Vector3(waypoints[i].transform.position.x + 0.1f, waypoints[i].transform.position.y, -1f));
			waypoints[i].GetComponent<LineRenderer> ().SetPosition(1, new Vector3(waypoints[i + 1].transform.position.x - 0.1f, waypoints[i + 1].transform.position.y, -1f));
			waypoints[i].GetComponent<LineRenderer> ().material.color = Color.black;
		}

		machineAnimator.SetBool ("IsOn", machineOn);
		receiverAnimator.SetBool ("IsOn", machineOn);


	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag ("Player")) {
			onStartbutton = true;
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.CompareTag ("Player")) {
			onStartbutton = false;
		}
	}

	public IEnumerator StartMachineCo () {
		yield return new WaitForSeconds (2);
		isOn = true;
	}
}
