using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayUI : MonoBehaviour {

	public string myString;
	public Text myText;
	public float fadeTime;
	public bool displayInfo;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		FadeText ();
		
	}

	void FadeText () {
		
		if (displayInfo) {
			myText.text = myString;
			myText.CrossFadeAlpha(1.0f, 0.1f, false);
		} else {
			myText.CrossFadeAlpha(0.0f, 0.3f, false);
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
	
		if (other.CompareTag ("Player")) {
			displayInfo = true;
		}
	}

	void OnTriggerExit2D (Collider2D other) {

		if (other.CompareTag ("Player")) {
			displayInfo = false;
		}
	}
}
