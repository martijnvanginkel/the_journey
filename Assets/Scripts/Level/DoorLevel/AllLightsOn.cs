using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllLightsOn : MonoBehaviour {

	private PlayerController player;
	private CameraController camera;

	private bool playerOnSwitch;

	public LampSwitch[] lights;

	public bool isOn;

	public GameObject npc;
	public GameObject teleportParticle;

	private bool notUsed = true;

	// Use this for initialization
	void Start () {

		player = FindObjectOfType<PlayerController> ();
		camera = FindObjectOfType<CameraController> ();
		lights = FindObjectsOfType<LampSwitch> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (notUsed) {
			if (playerOnSwitch) {
				npc.GetComponent<Animator> ().SetBool ("IsCheering", true);
				StartCoroutine ("ShowLights");
			}
		}
	}

	public IEnumerator ShowLights () { 
	
		player.canMove = false;
		camera.lockedCamera = true;
		camera.normal = 7;
		camera.viewPos.x = 15;
		yield return new WaitForSeconds (2);

		foreach (LampSwitch light in lights) {
			light.allOn = true;
		}
	
		yield return new WaitForSeconds (2);

		if (notUsed) {
			notUsed = false;
			Instantiate (teleportParticle, new Vector3(npc.transform.position.x, npc.transform.position.y, -4f), npc.transform.rotation);
		}

		Destroy (npc.gameObject);
		yield return new WaitForSeconds (2);
		player.canMove = true;
		camera.lockedCamera = false;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			playerOnSwitch = true;
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			playerOnSwitch = false;
		}	
	}
}
