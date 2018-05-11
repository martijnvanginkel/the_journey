using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour {

	private Animator animator;
	private GirlController girl;

	private bool isWalking;

	public float idleOffset;
	public float idleDistance;
	public float idleSpeed;
	public float walkSpeed;

	public Transform target;



	// Use this for initialization
	void Start () {

		animator = GetComponent<Animator> ();
		girl = FindObjectOfType<GirlController> ();

		isWalking = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (girl.endOfLevel) {
			WalkAway ();
		} else {
			Idle ();
		}

		animator.SetBool ("IsWalking", isWalking);
	}

	void Idle () {

		transform.position = new Vector3 (Mathf.PingPong (Time.time * idleSpeed, idleDistance) + idleOffset, transform.position.y, transform.position.z);
    
	}

	void WalkAway () {

		transform.position = Vector3.MoveTowards(transform.position, new Vector2(target.transform.position.x, transform.position.y), Time.deltaTime * walkSpeed);

		if (transform.position.x == target.position.x) {
			girl.destroyGirl = true;
		}
	}
}
