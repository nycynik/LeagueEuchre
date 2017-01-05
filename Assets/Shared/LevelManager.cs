using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevel;

	// Use this for initialization
	void Start () {
		if (autoLoadNextLevel > 0) {
			Invoke ("LoadNextScene", autoLoadNextLevel);
		}
	}
	
	public void LoadScene(string scene) {
		Debug.Log ("LM:Load Scene " + scene);
		SceneManager.LoadScene (scene);
	}

	public void Quit() {
		Application.Quit (); // does not work in ios
	}

	public void LoadNextScene() {
		SceneManager.LoadScene (1);
		autoLoadNextLevel = 0;
	}
}

