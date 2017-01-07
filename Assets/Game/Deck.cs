using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum SuitEnum {
	Hearts=0,
	Diamonds = 1,
	Clubs=2,
	Spades=3,
}

public class PlayingCard {
	private SuitEnum _suit;
	private int _rank;
	public Sprite front;
	public Sprite back;

	public SuitEnum Suit { get { return _suit; } }
	public int Rank { get { return _rank; } }

	private GameObject _card;

	public PlayingCard(SuitEnum suit, int rank, Vector3 position, Quaternion rotation, Sprite front, Sprite back) {
		// to do: validate rank, position, and rotation
		string assetName = string.Format("DeckOfCards_{0}_{1}", (int)suit, rank);  // Example:  "Card_1_10" would be the Jack of Hearts.
		assetName = "Player1Card";
		GameObject asset = GameObject.Find(assetName);
		if (asset == null) {
			Debug.LogError("Asset '" + assetName + "' could not be found.");
		} else {
			// _card = Instantiate(asset, position, rotation);
			_suit = suit;
			_rank = rank;
		}
	}

	public override string ToString ()
	{
		return string.Format ("[PlayingCard: Suit={0}, Rank={1}]", Suit, Rank);
	}
}

public class CardSet {
	public List<PlayingCard> pile = new List<PlayingCard>();

	public void AddCards(List<PlayingCard> cards) {
		pile.AddRange (cards);
	}

}

/***
 * A class that holds cards in it, e.g. discard pile, or a trick 
 */
public class CardPile : CardSet {

	public PlayingCard TakeTopCard() {
		if (pile.Count == 0)
			return null; // no card to give you.

		// take the first card off the deck and add it to the discard pile
		PlayingCard card = pile[0];
		pile.RemoveAt(0);

		return card;
	}

}

/***
 * A class that represents the cards in a players hand.
 */
public class Hand : CardSet {
	
}

public class Deck {

	private List<PlayingCard> deck = new List<PlayingCard>();

	public Deck() {
		
	}

	public void InitDeck(Sprite[] cards, Sprite cardBack) {
		this.deck.Clear ();

		foreach (Sprite sprite in cards) {
			String[] spriteParts = sprite.name.Split ('_');

			// create card
			PlayingCard card = new PlayingCard(
				(SuitEnum)int.Parse(spriteParts [1]), 
				int.Parse(spriteParts [2]), 
				new Vector3(), 
				new Quaternion(),
				sprite,
				cardBack
			);
			deck.Add (card);
		}
	}

	public void Shuffle() {
		for (int i = 0; i < deck.Count; i++) {
			PlayingCard swap_card = deck[i];
			int randomIndex = UnityEngine.Random.Range(i, deck.Count);
			deck[i] = deck[randomIndex];
			deck[randomIndex] = swap_card;
		}
	}

	public CardPile MakePileFromDeck () {
		CardPile pile = new CardPile();
		pile.AddCards(deck);
		return pile;
	}

	/*** 
	 * PermanentlyRemoveCard
	 * 
	 * Removes the card from the deck, if there is more than one card, will remove the 
	 * first instance of that card it finds.
	 */
	public void PermanentlyRemoveCard (SuitEnum suit, int rank) {
		
	}

	public override string ToString ()
	{
		string deckRepresentation = "";
		for (int i = 0; i < deck.Count; i++) {
			deckRepresentation += String.Format ("{0}{1} ", deck[i].Suit, deck[i].Rank);
		}
		return string.Format ("[Deck {0}]", deckRepresentation);
	}

}


