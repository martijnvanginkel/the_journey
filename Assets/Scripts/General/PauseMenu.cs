using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool gameIsPaused = false;

	public GameObject pauseMenuUI;

	private PlayerController player;

	void Start () {
		player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (gameIsPaused) {
				Resume ();
			} else {
				Pause ();
			}
		}
	}

	public void Resume () {
		pauseMenuUI.SetActive (false);
		player.canMove = true;
		Time.timeScale = 1f;
		gameIsPaused = false;
	}

	void Pause () {
		pauseMenuUI.SetActive (true);
		player.canMove = false;
		Time.timeScale = 0f;
		gameIsPaused = true;
	}

	public void RestartLevel () {
		//SceneManager.LoadScene(SceneManager.GetActiveScene);
		Resume ();
		 SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void QuitGame () {
		SceneManager.LoadScene ("StartScreen");
	}
}
