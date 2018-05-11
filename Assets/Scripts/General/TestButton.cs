using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestButton : MonoBehaviour {

	public Button buttonRight;
	public Button buttonLeft;

    void Start()
    {
		buttonRight.GetComponent<Button> ().onClick.AddListener (WalkMonkey);
		buttonLeft.GetComponent<Button> ().onClick.AddListener (WalkMonkey);
    }

    void WalkMonkey()
    {
		// Je code om te lopen
    }
}
