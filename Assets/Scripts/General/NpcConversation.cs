using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NpcConversation : MonoBehaviour {

	public PlayerController player;

	public GameObject textBox;
	public Text theText;

	public string[] strings;
	private int currentString;

	public bool playerInRange;

	private bool talked;

	public int convLength;
	public bool secondConv;

	private bool allowed;
	private bool npcIsTalking;

	private Animator animator;


	// Use this for initialization
	void Start () {

		player = FindObjectOfType<PlayerController> ();
		animator = GetComponent<Animator> ();

		DisableTextBox ();
	}
	
	// Update is called once per frame
	void Update () {
	
		theText.text = strings [currentString];
		
		// If player hasn't talked to npc yet
		if (playerInRange && secondConv != true) {

			if (talked) {
				if(Input.GetKeyDown(KeyCode.LeftAlt)){

					if (currentString < convLength -1) {
						currentString += 1;
						EnableTextBox ();
					}
					else {
						DisableTextBox ();
						// Start coroutine cause first conversation is done
						StartCoroutine ("WaitASec");
					}
				}
			} else {
				currentString = 0;
				EnableTextBox ();
				talked = true;
			}

		}

		// Second conversation	
		if (playerInRange && secondConv == true) {

			if (currentString >= convLength) {

				EnableTextBox ();
			}
			if (Input.GetKeyDown (KeyCode.LeftAlt)) {
				
				if (currentString < strings.Length - 1) {
					currentString += 1;
				} else {
			
					currentString = convLength - 1;
					DisableTextBox ();
				}
			}
		}

		animator.SetBool ("IsTalking", npcIsTalking);
	}

	public IEnumerator WaitASec() {
		yield return new WaitForSeconds (1.5f);
		secondConv = true;
	}

	// Check if player is in range of girl to talk and set bool
	void OnTriggerEnter2D (Collider2D other) {
	
		if (other.CompareTag ("Player")) {
			playerInRange = true;
		}
	}

	void OnTriggerExit2D (Collider2D other) {

		if (other.CompareTag ("Player")) {
			playerInRange = false;
		}
	}

//	public void TurnAround () {
//		
//		if (player.transform.position.x > transform.position.x) {
//			transform.localScale = new Vector3 (1f, 1f, 1f);
//		} else {
//			transform.localScale = new Vector3 (-1f, 1f, 1f);
//		}
//	}


	// Enable textbox and don't allow player to walk
	public void EnableTextBox () {
		npcIsTalking = true;
		textBox.SetActive(true);
		player.canMove = false;

		if (player.transform.position.x > transform.position.x) {
			transform.localScale = new Vector3 (1f, 1f, 1f);
		} else {
			transform.localScale = new Vector3 (-1f, 1f, 1f);
		}
	}

	public void DisableTextBox () {
		npcIsTalking = false;
		textBox.SetActive(false);
		player.canMove = true;
	}
}
