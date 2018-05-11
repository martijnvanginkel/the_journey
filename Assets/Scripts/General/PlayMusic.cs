using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMusic : MonoBehaviour {

	private AudioSource audioSource;

	public AudioClip [] clips;

	private int sceneSong;
	private int currentSong;

	public float timer;
	public float speed;

	public bool sceneChanged;

	private string sceneName;

	private void Awake ()
	{
		DontDestroyOnLoad (transform.gameObject);
		audioSource = GetComponent<AudioSource> ();

		Scene currentScene = SceneManager.GetActiveScene ();
		sceneName = currentScene.name;

		currentSong = 1;
		sceneSong = 1;
	}

	void Update () {

		// Song that should be played in this scene
		GetSceneSong ();
		// Play the song
        Play (clips [currentSong]);

		// Check if scene has changed
		if (SceneManager.GetActiveScene ().name != sceneName) {
			sceneChanged = true;
		}

		// Change song if scene changed
		if (sceneChanged) {
			ChangeSong ();
		} 

		if (sceneChanged == false && timer < 1) {
			VolumeUp ();
		} 
	}

	void VolumeDown () { 
		timer -= Time.deltaTime* speed;
		audioSource.volume = timer;
	}

	void VolumeUp () { 
		timer += Time.deltaTime* speed;
		audioSource.volume = timer;
	}

	void GetSceneSong () { 
		
		if (SceneManager.GetActiveScene ().name == "Laboratory" || SceneManager.GetActiveScene ().name == "Laboratory02") {
			sceneSong = 0;
		} else {
			sceneSong = 1;
		}
	}

	void ChangeSong () {

		if (currentSong != sceneSong) {
			if (timer > 0) {
				VolumeDown ();
			} else {
				sceneName = SceneManager.GetActiveScene ().name;

				if (sceneName == "Laboratory" || sceneName == "Laboratory02") {
					currentSong = 0;
				} else {
					currentSong = 1;
				}
				sceneChanged = false;
			}
		} else {
			sceneChanged = false;
		}
	}


	public void Play (AudioClip audio)
	{
		audioSource.clip = audio;

		if (audioSource.isPlaying) return;
		audioSource.Play ();
	}

	public void Stop ()
	{
		audioSource.Stop ();
	}
}
