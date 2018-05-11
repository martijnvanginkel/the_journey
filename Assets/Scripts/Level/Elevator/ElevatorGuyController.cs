using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorGuyController : MonoBehaviour {

	private PlayerController player;
	private HallElevator elevator;
	private CameraController camera;
	private LevelManager levelManager;

	public GameObject endPoint;

	[HideInInspector]
	public bool endAnimation;

	public int walkDistance;
	public float walkSpeed;


	private bool firstStage;
	private Animator animator;

	private bool isWalking;

	private Vector3 startPos;

	public GameObject teleportParticle;

	public HallLight [] hallLights;

	// Use this for initialization
	void Start () {

		player = FindObjectOfType<PlayerController> ();
		elevator = FindObjectOfType<HallElevator> ();
		camera = FindObjectOfType<CameraController> ();
		levelManager = FindObjectOfType<LevelManager> ();

		animator = GetComponent<Animator> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (player.transform.position.x > endPoint.transform.position.x) {

			endAnimation = true;

			camera.lockedCamera = true;
			
			elevator.doorOpen = true;
			player.canMove = false;

			StartCoroutine ("MoveElevator");

		}

		if (endAnimation) {
			foreach (HallLight hallLight in hallLights) {
				hallLight.LightOn (true);
			}
		}

		animator.SetBool ("IsWalking", isWalking);
		
	}

	public IEnumerator MoveElevator () {


		if (!firstStage) {

			levelManager.enabled = false;

			elevator.stage = 0;
			elevator.moving = true;

			yield return new WaitForSeconds (2);

			if (elevator.stage == 0) {
				isWalking = true;
				walkSpeed = 2;
				transform.localScale = new Vector3 (1f, 1f, 1f);
				transform.position = Vector3.MoveTowards (transform.position, new Vector3 (3, transform.position.y, transform.position.z), walkSpeed * Time.deltaTime);
			}

			if (transform.position.x == startPos.x + 3) {
				isWalking = false;
				elevator.stage = 1;
				firstStage = true;
			}


		}


		if (firstStage) {

			yield return new WaitForSeconds (2);
			isWalking = true;
			walkSpeed = 1;
			transform.position = Vector3.MoveTowards (transform.position, new Vector3 (6, transform.position.y, transform.position.z), walkSpeed* Time.deltaTime);

			if (transform.position.x == startPos.x + 6) {
				isWalking = false;
				StartCoroutine ("DestroyGuy");
			}
		}

	}

	public IEnumerator DestroyGuy () { 
		yield return new WaitForSeconds (1);
		Instantiate (teleportParticle, new Vector3(transform.position.x, transform.position.y, -4f), transform.rotation);
		Destroy (this.gameObject);
		levelManager.enabled = true;
		camera.lockedCamera = false;
		player.canMove = true;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("Elevator")) {
			transform.SetParent (elevator.transform);
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.CompareTag ("Elevator")) {
			transform.SetParent (null);
		}

	}
}
