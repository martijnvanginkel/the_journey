using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroController : MonoBehaviour {

	public GameObject swingingLamp;


	public GameObject player;
	private bool playerAwake = false;

	public float portalTime;

	public float start;
	public float value;

	public GameObject flashScreen;
	public GameObject darkScreen;

	private bool startScreen = true;

	// Use this for initialization
	void Start () {

		value = 1f;
		start = 1f;
	}
	
	// Update is called once per frame
	void Update () {

		if (startScreen) {
			StartCoroutine ("StartScreen");
		} 

		if (playerAwake) {
			StartCoroutine ("PortalFlash");
		}

		player.GetComponent<Animator> ().SetBool ("IsAwake", playerAwake);
		
	}

	public IEnumerator StartScreen () {
	
		yield return new WaitForSeconds (2f);
		darkScreen.GetComponent<SpriteRenderer> ().enabled = true;

		if (value > 0) {
			value -= (Time.deltaTime / 3f);
		}

		darkScreen.GetComponent<SpriteRenderer> ().color = new Color (0f, 0f, 0f, value);
		yield return new WaitForSeconds (portalTime);
		StartCoroutine ("TurnOnLamp");
		start = 0f;
		startScreen = false;
	}

	public IEnumerator TurnOnLamp () {

		yield return new WaitForSeconds (3);
		swingingLamp.GetComponent<Animator> ().SetBool ("TurnLampOn", true);
		yield return new WaitForSeconds (5);
		playerAwake = true;
	}

	public IEnumerator PortalFlash ()
	{
		yield return new WaitForSeconds (1f);

		flashScreen.GetComponent<SpriteRenderer> ().enabled = true;
		value = Mathf.Lerp (0f, 1f, start += (Time.deltaTime / portalTime));
		flashScreen.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, value);
		yield return new WaitForSeconds (portalTime);
		Application.LoadLevel ("Laboratory");	
	}


}
