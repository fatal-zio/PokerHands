using Entities;
using Common;
using NUnit.Framework;
using Logic;
using System.Linq;
using System.Collections.Generic;
using static Common.Enums.CardValues;
using static Common.Enums.Suits;
using static Common.Enums.HandTypes;

namespace UnitTests
{
    [TestFixture]
    public class UnitTests
    {

        #region Basic
        [Test]
        public void CanTest()
        {
            Assert.AreEqual(true, true);
        }
        #endregion

        #region Card Deck
        [Test]
        public void CreateDeck()
        {
            var deck = new CardDeck();

            Assert.IsNotNull(deck);
        }

        [Test]
        public void DrawCard()
        {
            var deck = new CardDeck();
            var card = deck.DrawCard();

            Assert.IsNotNull(card);
        }

        [Test]
        public void CardsInDeck()
        {
            var deck = new CardDeck();
            Assert.AreEqual(deck.Cards.Count, Constants.NUMBER_OF_CARDS_IN_DECK);
        }

        [Test]
        public void DrawSubtractsACard()
        {
            var deck = new CardDeck();
            var card = deck.DrawCard();

            Assert.AreEqual(deck.Cards.Count, Constants.NUMBER_OF_CARDS_IN_DECK -1);
        }

        #endregion

        #region Generate Hands

        [Test]
        public void GeneratePokerHands()
        {
            var hands = HandGenerator.GenerateHands();

            Assert.AreEqual(expected: 2, actual: hands.ToList().Count);
        }
        #endregion

        #region Hand Types

        [Test]
        public void IsStraightFlush()
        {
            var cards = new List<Card>();

            cards.Add(new Card(Two, Clubs));
            cards.Add(new Card(Three, Clubs));
            cards.Add(new Card(Four, Clubs));
            cards.Add(new Card(Five, Clubs));
            cards.Add(new Card(Six, Clubs));

            var evaluator = new HandEvaluator();
            var hand = new PokerHand(cards, "Blah");
            Assert.AreEqual(StraightFlush, hand.HandType);
        }

        [Test]
        public void IsFourOfAKind()
        {
            var cards = new List<Card>();

            cards.Add(new Card(Two, Clubs));
            cards.Add(new Card(Two, Hearts));
            cards.Add(new Card(Two, Diamonds));
            cards.Add(new Card(Two, Spades));
            cards.Add(new Card(Six, Clubs));

            var evaluator = new HandEvaluator();
            var hand = new PokerHand(cards, "Blah");
            Assert.AreEqual(FourOfAKind, hand.HandType);
        }

        [Test]
        public void IsFullHouse()
        {
            var cards = new List<Card>();

            cards.Add(new Card(Two, Clubs));
            cards.Add(new Card(Two, Hearts));
            cards.Add(new Card(Two, Diamonds));
            cards.Add(new Card(Three, Spades));
            cards.Add(new Card(Three, Clubs));

            var evaluator = new HandEvaluator();
            var hand = new PokerHand(cards, "Blah");
            Assert.AreEqual(FullHouse, hand.HandType);
        }

        [Test]
        public void IsFlush()
        {
            var cards = new List<Card>();

            cards.Add(new Card(Two, Clubs));
            cards.Add(new Card(Three, Clubs));
            cards.Add(new Card(Nine, Clubs));
            cards.Add(new Card(Five, Clubs));
            cards.Add(new Card(Six, Clubs));

            var evaluator = new HandEvaluator();
            var hand = new PokerHand(cards, "Blah");
            Assert.AreEqual(Flush, hand.HandType);
        }

        [Test]
        public void IsStraight()
        {
            var cards = new List<Card>();

            cards.Add(new Card(Two, Clubs));
            cards.Add(new Card(Three, Clubs));
            cards.Add(new Card(Four, Hearts));
            cards.Add(new Card(Five, Clubs));
            cards.Add(new Card(Six, Clubs));

            var evaluator = new HandEvaluator();
            var hand = new PokerHand(cards, "Blah");
            Assert.AreEqual(Straight, hand.HandType);
        }

        [Test]
        public void IsThreeOfAKind()
        {
            var cards = new List<Card>();

            cards.Add(new Card(Two, Clubs));
            cards.Add(new Card(Two, Hearts));
            cards.Add(new Card(Two, Diamonds));
            cards.Add(new Card(Three, Spades));
            cards.Add(new Card(Five, Clubs));

            var evaluator = new HandEvaluator();
            var hand = new PokerHand(cards, "Blah");
            Assert.AreEqual(ThreeOfAKind, hand.HandType);
        }

        [Test]
        public void IsTwoPairs()
        {
            var cards = new List<Card>();

            cards.Add(new Card(Two, Clubs));
            cards.Add(new Card(Two, Hearts));
            cards.Add(new Card(Three, Diamonds));
            cards.Add(new Card(Three, Spades));
            cards.Add(new Card(Five, Clubs));

            var evaluator = new HandEvaluator();
            var hand = new PokerHand(cards, "Blah");
            Assert.AreEqual(TwoPairs, hand.HandType);
        }

        [Test]
        public void IsPair()
        {
            var cards = new List<Card>();

            cards.Add(new Card(Two, Clubs));
            cards.Add(new Card(Two, Hearts));
            cards.Add(new Card(Three, Diamonds));
            cards.Add(new Card(Seven, Spades));
            cards.Add(new Card(Five, Clubs));

            var evaluator = new HandEvaluator();
            var hand = new PokerHand(cards, "Blah");
            Assert.AreEqual(Pair, hand.HandType);
        }
        #endregion
    }
}