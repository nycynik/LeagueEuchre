using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour {

	public const int kNumPlayers = 4;
	public const int kCardsDealt = 5;

	public Sprite[] cards;
	public Sprite back;
	public GameObject[] PlayerHandGameObjects;

	private Deck gameDeck = new Deck ();
	private CardPile trickDeck;

	private List<Hand> PlayerHands;

	public enum GAME_STATE { STARTING, DEALING, BIDDING, PLAYING, REVIEW };

	// Use this for initialization
	void Start() {

		// initialization
		PlayerHands = new List<Hand>();
		for (int x = 0; x < kNumPlayers; x++) {			
			PlayerHands.Add (new Hand ());
		}
		gameDeck.InitDeck (cards, back);

		// start game
		GameState = GAME_STATE.DEALING;

	}

	
	// Update is called once per frame
	void Update () {
		
	}

	private void drawHand (int player) {
		GameObject p = PlayerHandGameObjects [player];

		foreach (Hand h in PlayerHands) {
			foreach (PlayingCard c in h.pile) {
				Debug.Log(c.ToString ());
			}
		}

	}

	private GAME_STATE _gameState;
	private GAME_STATE GameState 
	{
		get {return _gameState;} 

		set {
			if (_gameState != value) {
				_gameState = value;

				switch (GameState) {
				case GAME_STATE.DEALING:
					gameDeck.Shuffle ();
					trickDeck = gameDeck.MakePileFromDeck ();
					// deal
					Debug.Log (PlayerHands);
					Debug.Log (PlayerHands [0]);
					for (int p = 0; p < kNumPlayers; p++) {
						List<PlayingCard> cards = new List<PlayingCard> ();
						for (int x = 0; x < kCardsDealt; x++) {
							cards.Add (trickDeck.TakeTopCard ());							
						}
						PlayerHands [p].AddCards (cards);
						if (p == 0) {
							drawHand (0);
						}
					}
					break;
				case GAME_STATE.BIDDING:
					break;
				case GAME_STATE.PLAYING:
					break;
				case GAME_STATE.REVIEW:
					break;
				}
			}


		}   


	}

}
