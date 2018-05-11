﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HipsterRaycast : MonoBehaviour {



	public float distance = 1f;
	public LayerMask obstacleMask;
	public RaycastHit2D hit;

	public bool playerBlocked;

	public GameObject obstacle;

	// Use this for initialization
	void Start () {


		
	}
	
	// Update is called once per frame
	void Update () {

		hit = Physics2D.Raycast (transform.position, Vector2.right * transform.localScale.x, distance, obstacleMask);

		// If Raycast hits collider
		if (hit.collider != null) {




//				box = hit.collider.gameObject;
//				box.GetComponent<FixedJoint2D> ().enabled = true;
//				box.GetComponent<BoxPull> ().beingPushed = true;
//				box.GetComponent<FixedJoint2D> ().connectedBody = this.GetComponent<Rigidbody2D> ();

			
		} 
	}

	// Teken de raycast en geef het een kleur
	void OnDrawGizmos () {
	
		Gizmos.color = Color.yellow;
		Gizmos.DrawLine (transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
	
	}
}