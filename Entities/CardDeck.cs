using System;
using System.Collections.Generic;
using System.Linq;
using Common;

namespace Entities
{
    public class CardDeck
    {
        public List<Card> Cards {get; private set;}

        public CardDeck()
        {
            Cards = new List<Card>();
            var suitValues = Enums.Suits.GetValues(typeof(Enums.Suits)).Cast<Enums.Suits>();

            foreach(var suit in suitValues)
            {
                Cards.AddRange(GetAllCardsForSuit(suit));
            }
        }

        private IEnumerable<Card> GetAllCardsForSuit(Enums.Suits suit)
        {
            var cards = new List<Card>();
            var cardValues = Enums.Suits.GetValues(typeof(Enums.CardValues)).Cast<Enums.CardValues>();

            foreach(var value in cardValues)
            {
                cards.Add(new Card(value, suit));
            }

            return cards;
        }

        public Card DrawCard(int cardIndex)
        {
            if(cardIndex < 0 || cardIndex > Cards.Count)
                throw new ArgumentException();

            var returnCard = Cards[cardIndex];

            Cards.RemoveAt(cardIndex);

            return returnCard;
        }
    }
}