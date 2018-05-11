using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineButton : MonoBehaviour {

	public GameObject theMachine;

	public bool playerOnButton;

	public int stages;
	public int currentStage;

	public bool goingUp;

	public Vector2[] positions;

	public float speed;
	public float waitTime;

//	private Animator animator;

	// Use this for initialization
	void Start () {

		//animator = GetComponent<Animator> ();
		stages = positions.Length;
		
	}
	
	// Update is called once per frame
	void Update () {

		StartCoroutine ("GoUp");

		if (currentStage == stages - 1) {
			
			goingUp = false;

		}

		if (currentStage == 0) {
			
			goingUp = true;

		}

		if (Input.GetKeyDown (KeyCode.A) && playerOnButton) {

			if (goingUp) {
				
				currentStage++;

			} else {
				
				currentStage--;
			
			}
		}
			
		//animator.SetInteger ("currentStage", );
	}

	public IEnumerator GoUp() {

		yield return new WaitForSeconds(waitTime);
		theMachine.transform.position = Vector2.MoveTowards (new Vector2 (theMachine.transform.position.x, theMachine.transform.position.y), positions[currentStage], speed * Time.deltaTime);

	}

	void OnTriggerEnter2D (Collider2D other) {

		if (other.tag == "Player"){

			playerOnButton = true;

		}
	}

	void OnTriggerExit2D (Collider2D other) {

		if (other.CompareTag ("Player")) {
			
			playerOnButton = false;

		}
	}
}
