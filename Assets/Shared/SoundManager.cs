using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour {

	public AudioClip[] soundClips;

	private AudioSource audioSource;
	private int nowPlaying = -1;

	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad (gameObject);
	}
	
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}

	private void stopMusic () {
		audioSource.Stop ();
	}

	private void playClip (int clipId) {

		if (nowPlaying != clipId) {
			AudioClip bgMusic = soundClips[clipId];
			audioSource.clip = bgMusic;
			audioSource.loop = true;
			audioSource.Play ();
			nowPlaying = clipId;
		}
	}

	void OnLevelWasLoaded (int sceneId) {
		Debug.Log (sceneId);
		switch (sceneId) {
		case 3:
			playClip (0);
			audioSource.volume = 0.2f;
			break;
		case 1:
		case 2:
		case 4:
		case 5:
			// play background music.
			playClip(0);
			audioSource.volume = 0.8f;		
			break;
		case 6:
			stopMusic ();
			break;
		}


	}
}
