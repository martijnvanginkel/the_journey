using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlController : MonoBehaviour {

	private CameraController camera;
	private FallingBlock fallingBlock;
	private TurningWheel turningWheel;

	private bool notUsed = true;
	public GameObject theLantern;
	public GameObject teleportParticle;

	public bool endAnimation;

	public PlayerController player;

	public GameObject flashScreen;
	public bool portalFlash;

	public float portalTime;
	private float start;
	private float value;


	public bool endOfLevel;

	public bool destroyGirl;

	private bool instantiateGirl;
	private bool instantiatePlayer;


	// Use this for initialization
	void Start () {

		camera = FindObjectOfType<CameraController> ();
		player = FindObjectOfType<PlayerController> ();
		fallingBlock = FindObjectOfType<FallingBlock> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (player.transform.position.y > 0) {
			if (player.transform.position.x > transform.position.x) {
				transform.localScale = new Vector3 (1f, 1f, 1f);
			} else {
				transform.localScale = new Vector3 (-1f, 1f, 1f);
			}
		}

		if (fallingBlock.transform.position.y > fallingBlock.topPos - 0.5f) {

			endOfLevel = true;

		}

		if (destroyGirl) {
			destroyGirl = false;
			StartCoroutine ("DestroyGirlCo");
		}
			
	}

	public IEnumerator DestroyGirlCo () {


		camera.lockedCamera = true;
		camera.normal = 4;
		camera.viewPos.x = 7;
		camera.viewPos.y = 3;

		yield return new WaitForSeconds (1.5f);

		if (instantiateGirl == false) {

			instantiateGirl = true;
			Instantiate (teleportParticle, new Vector3 (transform.position.x, transform.position.y, -3f), transform.rotation);
			GetComponent<SpriteRenderer> ().enabled = false;

		}

		yield return new WaitForSeconds (2f);


		StartCoroutine ("PortalFlashCo");
	
	}


	public IEnumerator PortalFlashCo ()
	{
		player.canMove = false;

		flashScreen.GetComponent<SpriteRenderer> ().enabled = true;
		value = Mathf.Lerp (0f, 1f, start += (Time.deltaTime / portalTime));
		flashScreen.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, value);
		yield return new WaitForSeconds (1.5f);
		Application.LoadLevel ("Laboratory02");
	}
}


