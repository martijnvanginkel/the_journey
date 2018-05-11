using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundMove : MonoBehaviour {

	// Definieer je spelerscript
	private PlayerController player;

	// Definieer je variable voor de snelheid en voor de huidige positie
	// Speed is public omdat je in Unity de snelheid aan wil passen en currenPosition is private omdat er geen andere scripts zijn die deze variable willen gebruiken
	public float speed;
	private Vector2 currentPosition;

	// Use this for initialization
	void Start () {

		// Zoek het object waar het playercontroller script aan zit 
		player = FindObjectOfType<PlayerController> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		// Huidige positie van de achtergrond
		currentPosition = new Vector2 (transform.position.x, transform.position.y);

		// Wanneer de speler naar links loopt (je kunt een boolean maken die checkt of je speler naar links loopt)
		if (Input.GetKey (KeyCode.LeftArrow)) {

			// zet de snelheid, kun je ook mooier doen door dit een variable te maken die of positief of negatief is zodat je niet handmatig elke keer de snelheid hoeft te schrijven
			speed = 1;
			// verander de x-positie van de achtergrond (de y positie blijft hetzelfde) door tijd * snelheid te doen
			transform.position = new Vector2 (currentPosition.x + Time.deltaTime * speed, currentPosition.y); 
		}

		//Zelfde als voor naar links 
		if (Input.GetKey (KeyCode.RightArrow)) {

			speed = -1;
			transform.position = new Vector2 (currentPosition.x + Time.deltaTime* speed, currentPosition.y); 
		}

	}
}
