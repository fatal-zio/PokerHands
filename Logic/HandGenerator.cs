using System.Collections.Generic;
using Entities;
using Common;
using System;

namespace Logic
{

    public class HandGenerator
    {
        public IEnumerable<PokerHand> GenerateHands()
        {
            var hands = new List<PokerHand>();
            var deck = new CardDeck();

            hands.Add(GenerateHand(ref deck, Constants.PLAYER_ONE_NAME));
            hands.Add(GenerateHand(ref deck, Constants.PLAYER_TWO_NAME));

            return hands;
        }

        private PokerHand GenerateHand(ref CardDeck deck, string playerName)
        {
            var cards = new List<Card>();

            for(var i = 0; i < Constants.NUMBER_OF_CARDS_IN_HAND; i++)
            {
                cards.Add(deck.DrawCard(GetRandomIndex()));
            }

            return new PokerHand(cards, playerName);
        }

        private int GetRandomIndex()
        {
            var r = new Random();
            return r.Next(0, 51);
        }

    }


}