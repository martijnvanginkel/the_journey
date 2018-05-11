using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public LightController[] lights;
	//public GameObject[] lights;

	public LevelManager levelManager;

	//Components
	public Collider2D myCollider;
	public Rigidbody2D myRigidbody;
	private Animator myAnimator;

	// Walk
	public float moveSpeed;
	//public float jumpHeight;
	//public float climbSpeed;

	//public LayerMask whatIsGround;
	public LayerMask whatIsLightsource;

	//public bool grounded;
	public bool canMove;
	//public bool canJump;

	public bool turningWheel;

	public bool isInLight;

	public GameObject deathParticle;
	public float deathTimer;
	public float timeInDanger;


	// Use this for initialization
	void Start () {

		myRigidbody = GetComponent<Rigidbody2D>();
		myCollider = GetComponent<Collider2D> ();
		myAnimator = GetComponent<Animator> ();

		levelManager = FindObjectOfType<LevelManager> ();
		lights = FindObjectsOfType<LightController> ();


		canMove = true;
		//canJump = true;

	}
	
	// Update is called once per frame
	void Update () {


		Walk ();
		
		//Light ();

	
		isInLight = Physics2D.IsTouchingLayers (myCollider, whatIsLightsource);

		// Animations
		myAnimator.SetFloat ("Speed", Mathf.Abs(myRigidbody.velocity.x));
		//myAnimator.SetBool ("Grounded", grounded);
		myAnimator.SetBool ("TurningWheel", turningWheel);

	
	}
		
	void Walk () {

		if (!canMove) {
			return;
		} else {
			if (Input.GetKey (KeyCode.RightArrow)) {
				myRigidbody.velocity = new Vector2 (moveSpeed, myRigidbody.velocity.y);
				transform.localScale = new Vector3 (1f, 1f, 1f);
			} 
			if (Input.GetKey (KeyCode.LeftArrow)) {
				myRigidbody.velocity = new Vector2 (-moveSpeed, myRigidbody.velocity.y);
				transform.localScale = new Vector3 (-1f, 1f, 1f);
			} 
		}
	}

	//void Jump () {
		
	//	grounded = Physics2D.IsTouchingLayers (myCollider, whatIsGround);

	//	if (!canJump) {
	//		return;
	//	} else {
	//		if (Input.GetKeyDown (KeyCode.UpArrow)) {
	//			if (grounded) {
	//				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.y, jumpHeight);
	//			}
	//		}
	//	}
	//}
}