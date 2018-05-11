using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	private PlayerController player;
	public Collider2D playerCollider;

	public GameObject deathParticle;

	private float deathCounter;
	private float alphaLevel;


	public GameObject screenFader;

	public Text deathMessage;
	public string messageInput;

	public bool playerIsDead = false;

	// Use this for initialization
	void Start () {

		player = FindObjectOfType<PlayerController> ();
		playerCollider = player.GetComponent<Collider2D> ();
		screenFader.GetComponent<SpriteRenderer>().enabled = true;
		deathMessage.GetComponent<Text> ().enabled = false;
		deathCounter = 3f;

	}
	
	// Update is called once per frame
	void Update () {

		deathCounter -= (Time.deltaTime * 2f);
		deathMessage.GetComponent<Text>().text = messageInput;

		if (playerIsDead) {
			StartCoroutine ("RespawnPlayer");
		} else {

			if (player.isInLight != true) {

				screenFader.GetComponent<SpriteRenderer> ().color = new Color (0f, 0f, 0f, 1f / deathCounter);

				if (deathCounter < 1f) {
					deathCounter = 1f;
					messageInput = "You're too afraid to stay in the dark any longer";
					playerIsDead = true;
				}
			} else {
				deathCounter = 5f;
				screenFader.GetComponent<SpriteRenderer> ().color = new Color (0f, 0f, 0f, 1f / deathCounter);
			}
		}
			
	}

	public IEnumerator RespawnPlayer () {
		player.canMove = false;
		screenFader.GetComponent<SpriteRenderer> ().color = new Color (0f, 0f, 0f, 1f);
		//yield return new WaitForSeconds (0.1f);
		deathMessage.GetComponent<Text>().enabled = true;
		yield return new WaitForSeconds (2.25f);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
