using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingingLantern : MonoBehaviour {

	public float offset;

	public float swingSpeed;
	public float swingDistance;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = new Vector3 (Mathf.PingPong (Time.time * swingSpeed, swingDistance) + offset, transform.position.y, transform.position.z);
		
	}
}
