using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachinePlatform : MonoBehaviour {

	public GameObject theMachine;
	public MachineButton theButton;

	public Vector2[] positions;

	public float speed;
	public float waitTime;

	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame
	void Update () {

		StartCoroutine("GoUp");

	}

	public IEnumerator GoUp() {

		yield return new WaitForSeconds(waitTime);
		theMachine.transform.position = Vector2.MoveTowards (new Vector2 (theMachine.transform.position.x, theMachine.transform.position.y), positions[1], speed * Time.deltaTime);

	}

}
