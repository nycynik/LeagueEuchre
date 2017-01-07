using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour {

	public Sprite front;
	public Sprite back;

	private SpriteRenderer sr;
	private int curCardId = 0;
	private SuitEnum _suit;
	private int _rank;
	private bool showing = false;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();
		Invoke ("FlipCard", 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FlipCard() {
		showing = !showing;
		if (!showing) {
			sr.sprite = back;
		} else {
			sr.sprite = front;
		}
		Invoke ("FlipCard", 1);
	}
}
