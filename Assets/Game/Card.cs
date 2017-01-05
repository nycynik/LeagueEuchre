using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {

	public Sprite[] card;
	private SpriteRenderer sr;
	private int curCardId = 0;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();
		Invoke ("ChangeCard", 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ChangeCard() {
		sr.sprite = card [curCardId];
		curCardId += 1;
		if (curCardId > 23) {
			curCardId = 0;
		}
		Invoke ("ChangeCard", 1);
	}
}
