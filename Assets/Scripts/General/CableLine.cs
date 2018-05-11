using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableLine : MonoBehaviour {

	//public GameObject[] waypoints;
	public GameObject[] waypoints;

	public float xOffset;
	public float yOffset;
	public float zOffset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		GetComponent<LineRenderer> ().positionCount = 2;

		GetComponent<LineRenderer> ().SetPosition(0, new Vector3(waypoints[0].transform.position.x + xOffset, waypoints[0].transform.position.y + yOffset, waypoints[0].transform.position.z + zOffset));
		GetComponent<LineRenderer> ().SetPosition(1, new Vector3(waypoints[1].transform.position.x - xOffset, waypoints[1].transform.position.y - yOffset, waypoints[1].transform.position.z - zOffset));

		GetComponent<LineRenderer> ().material.color = Color.black;

		
	}
}
