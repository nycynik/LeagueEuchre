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
//		Scene sceneTest = SceneManager.GetSceneByName (scene);
//		if (sceneTest.IsValid ()) {
			Debug.Log ("LM:Load Scene " + scene);
			SceneManager.LoadScene (scene);
//		} else {
//			Debug.LogError ("LM:Load Scene attempt to load Invalid Scene " + scene);
//		}
	}

	public void Quit() {
		Application.Quit (); // does not work in ios
	}

	public void LoadNextScene() {
		SceneManager.LoadScene (1);
		autoLoadNextLevel = 0;
	}
}

