using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheLamp : MonoBehaviour {

	public bool isOn;
	public GameObject light;
	private Animator animator;

	// Use this for initialization
	void Start () {

		isOn = false;

		animator = GetComponent<Animator> ();
		light = transform.Find("light").gameObject;
		
	}
	
	// Update is called once per frame
	void Update () {


		animator.SetBool ("IsOn", isOn);

		if (isOn) {
			light.GetComponent<Light> ().enabled = true;
		} else {
			light.GetComponent<Light> ().enabled = false;
		}

		
	}
}
