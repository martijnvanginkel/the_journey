using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public PlayerController thePlayer;

	private Vector3 offset;

	public int zoom;
	public int normal;
	public int smooth;

	public bool isZoomed;

	public bool lockedCamera;

	public Vector3 viewPos;

	// Use this for initialization
	void Start () {

		thePlayer = FindObjectOfType<PlayerController> ();
		offset = transform.position - thePlayer.transform.position;

	}

	// Update is called once per frame
	void FixedUpdate () {

		if (lockedCamera == true) {

			transform.position = Vector3.Lerp(transform.position, new Vector3 (viewPos.x, viewPos.y, -4f), Time.deltaTime * 3.5f);

			isZoomed = false;
		}

		if (lockedCamera != true) {

			transform.position = Vector3.Lerp (this.transform.position, new Vector3 (thePlayer.transform.position.x, thePlayer.transform.position.y, -4f), Time.deltaTime * 3.5f);
			isZoomed = true;
		}

		if (isZoomed) {

			GetComponent<Camera> ().orthographicSize = Mathf.Lerp (GetComponent<Camera> ().orthographicSize, zoom, Time.deltaTime * smooth);
		} else {
			
			GetComponent<Camera> ().orthographicSize = Mathf.Lerp (GetComponent<Camera> ().orthographicSize, normal, Time.deltaTime * smooth);
		}
	}
}
