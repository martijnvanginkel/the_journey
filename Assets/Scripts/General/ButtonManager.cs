using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonManager : MonoBehaviour {

	public void NewGameBtn (string newGameLevel) {

		SceneManager.LoadScene (newGameLevel);
	}

	public void ExitGameBtn () {
		Application.Quit ();
	}
}
