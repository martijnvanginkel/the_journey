using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour
{

	private Rigidbody2D rb;
	private Animator animator;
	private Collider2D spiderCollider;
	private bool isWalking;

	public float moveSpeed;
	private int rotation;
	private bool freeze;

	public RaycastHit2D hit;
	public float rayDistance;

	private Vector2 rayPos;
	private bool canAdd = false;

	private bool isInLight;
	public LayerMask lightSource;
	public LayerMask wallMask;


	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		spiderCollider = GetComponent<Collider2D> ();

	}

	// Update is called once per frame
	void Update ()
	{

		isInLight = Physics2D.IsTouchingLayers (spiderCollider, lightSource);

		if (!isInLight) {
			moveSpeed = 2;
			MoveSpider (moveSpeed);
		} else { 
		
		}

		animator.SetBool ("IsWalking", isWalking);
	}

	public void MoveSpider (float moveSpeed) {

		HitWall (moveSpeed);

		isWalking = true;
		rb.isKinematic = false;
		transform.rotation = Quaternion.Euler(0, 0, rotation);

		switch (rotation) { 
			case 0: 
				rb.velocity = new Vector2 (moveSpeed, rb.velocity.y);
				FreezeConstraintX (false);
				break;
			case 90:
				rb.velocity = new Vector2 (rb.velocity.x, moveSpeed);
            	FreezeConstraintX (true);
				break;
			case 180:
				rb.velocity = new Vector2 (-moveSpeed, rb.velocity.y);
                FreezeConstraintX (false);
				break;
			case 270:
				rb.velocity = new Vector2 (rb.velocity.x, -moveSpeed);
             	FreezeConstraintX (true);
				break;
		}
	}

	public void StopSpider () {

		//RandomNumber ();

		isWalking = false;
		rb.isKinematic = true;
		rb.velocity = Vector2.zero;
	}

	void FreezeConstraintX (bool freeze) {
		if (freeze) {
			rb.constraints = RigidbodyConstraints2D.FreezePositionX;
		} else {
			rb.constraints = RigidbodyConstraints2D.FreezePositionY;
		}	
	}

	void HitWall (float moveSpeed) { 
	
		rayPos = transform.right* moveSpeed;
		hit = Physics2D.Raycast (transform.position, rayPos* transform.localScale.x, rayDistance, wallMask);

		if (hit.collider != null && hit.collider.gameObject.tag == "TurningPoint") {

			canAdd = true;

			if (canAdd) {
				canAdd = false;

				if (moveSpeed > 0) {
					if (rotation != 270) {
						rotation += 90;
					} else {
						rotation = 0;
					}
				} else {
					if (rotation != 0) {
						rotation -= 90;
					} else {
						rotation = 270;
					}
				}
			}
		} 
	}

	//public IEnumerator ChangeDirection () {

	//	yield return new WaitForSeconds (1);

	//}


	void OnDrawGizmos ()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawLine (transform.position, (Vector2)transform.position + rayPos * transform.localScale.x * rayDistance);
	}
}
