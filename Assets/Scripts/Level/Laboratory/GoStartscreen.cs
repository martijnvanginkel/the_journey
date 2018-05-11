using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoStartscreen : MonoBehaviour {

	private PlayerController player;
	private NpcConversation profConv;

	private Animator animator;
	private bool endGame;

	public GameObject flashScreen;


	public float portalTime;
	private float start;
	private float value;


	// Use this for initialization
	void Start () {

		player = FindObjectOfType<PlayerController> ();
		profConv = FindObjectOfType<NpcConversation> ();

		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (profConv.secondConv) {

			endGame = true;
			StartCoroutine ("EndGame");
		
		}

		animator.SetBool ("EndGame", endGame);
		
	}

	public IEnumerator EndGame () {

		yield return new WaitForSeconds (6);

		player.canMove = false;

		flashScreen.GetComponent<SpriteRenderer> ().enabled = true;
		value = Mathf.Lerp (0f, 1f, start += (Time.deltaTime / portalTime));
		flashScreen.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, value);
		yield return new WaitForSeconds (portalTime);


		Application.LoadLevel ("StartScreen");
	
	}
}
