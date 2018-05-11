using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class PlayerPush : MonoBehaviour {

//	public PlayerController thePlayer;

//	public float distance = 1f;
//	public LayerMask boxMask;
//	public RaycastHit2D hit;

//	public GameObject box;

//	// Use this for initialization
//	void Start () {

//		thePlayer = FindObjectOfType<PlayerController> ();
		
//	}
	
//	// Update is called once per frame
//	void Update () {

//		hit = Physics2D.Raycast (transform.position, Vector2.right * transform.localScale.x, distance, boxMask);

//		// If Raycast hits collider
//		if (hit.collider != null && hit.collider.gameObject.tag == "Pushable" && Input.GetKeyDown (KeyCode.LeftAlt)) {

//			if (thePlayer.holdingLight == false) {

//				box = hit.collider.gameObject;
//				box.GetComponent<FixedJoint2D> ().enabled = true;
//				box.GetComponent<BoxPull> ().beingPushed = true;
//				box.GetComponent<FixedJoint2D> ().connectedBody = this.GetComponent<Rigidbody2D> ();
//			}
			
//		} else if (Input.GetKeyUp (KeyCode.LeftAlt)) {
		
//			box.GetComponent<FixedJoint2D> ().enabled = false;
//			box.GetComponent<BoxPull> ().beingPushed = false;
//		}
//	}

//	// Teken de raycast en geef het een kleur
//	void OnDrawGizmos () {
	
//		Gizmos.color = Color.yellow;
//		Gizmos.DrawLine (transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
	
//	}
//}
