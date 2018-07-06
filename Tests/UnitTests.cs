using Entities;
using Common;
using NUnit.Framework;
using Logic;
using System.Linq;
using System.Collections.Generic;
using static Common.Enums.CardValues;
using static Common.Enums.Suits;

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
            var card = deck.DrawCard(0);

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
            var card = deck.DrawCard(0);

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

            cards.Add(new Card(Two, C));
            cards.Add(new Card(Three, C));
            cards.Add(new Card(Four, C));
            cards.Add(new Card(Five, C));
            cards.Add(new Card(Six, C));

            var evaluator = new HandEvaluator();
            var hand = new PokerHand(cards, "Blah");
            var result = evaluator.IsStraightFlush(hand);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void IsFourOfAKind()
        {
            var cards = new List<Card>();

            cards.Add(new Card(Two, C));
            cards.Add(new Card(Two, H));
            cards.Add(new Card(Two, D));
            cards.Add(new Card(Two, S));
            cards.Add(new Card(Six, C));

            var evaluator = new HandEvaluator();
            var hand = new PokerHand(cards, "Blah");
            var result = evaluator.IsFourOfAKind(hand);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void IsFullHouse()
        {
            var cards = new List<Card>();

            cards.Add(new Card(Two, C));
            cards.Add(new Card(Two, H));
            cards.Add(new Card(Two, D));
            cards.Add(new Card(Three, S));
            cards.Add(new Card(Three, C));

            var evaluator = new HandEvaluator();
            var hand = new PokerHand(cards, "Blah");
            var result = evaluator.IsFullHouse(hand);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void IsFlush()
        {
            var cards = new List<Card>();

            cards.Add(new Card(Two, C));
            cards.Add(new Card(Three, C));
            cards.Add(new Card(Nine, C));
            cards.Add(new Card(Five, C));
            cards.Add(new Card(Six, C));

            var evaluator = new HandEvaluator();
            var hand = new PokerHand(cards, "Blah");
            var result = evaluator.IsFlush(hand);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void IsStraight()
        {
            var cards = new List<Card>();

            cards.Add(new Card(Two, C));
            cards.Add(new Card(Three, C));
            cards.Add(new Card(Four, H));
            cards.Add(new Card(Five, C));
            cards.Add(new Card(Six, C));

            var evaluator = new HandEvaluator();
            var hand = new PokerHand(cards, "Blah");
            var result = evaluator.IsStraight(hand);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void IsThreeOfAKind()
        {
            var cards = new List<Card>();

            cards.Add(new Card(Two, C));
            cards.Add(new Card(Two, H));
            cards.Add(new Card(Two, D));
            cards.Add(new Card(Three, S));
            cards.Add(new Card(Five, C));

            var evaluator = new HandEvaluator();
            var hand = new PokerHand(cards, "Blah");
            var result = evaluator.IsThreeOfAKind(hand);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void IsTwoPairs()
        {
            var cards = new List<Card>();

            cards.Add(new Card(Two, C));
            cards.Add(new Card(Two, H));
            cards.Add(new Card(Three, D));
            cards.Add(new Card(Three, S));
            cards.Add(new Card(Five, C));

            var evaluator = new HandEvaluator();
            var hand = new PokerHand(cards, "Blah");
            var result = evaluator.IsTwoPairs(hand);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void IsPair()
        {
            var cards = new List<Card>();

            cards.Add(new Card(Two, C));
            cards.Add(new Card(Two, H));
            cards.Add(new Card(Three, D));
            cards.Add(new Card(Seven, S));
            cards.Add(new Card(Five, C));

            var evaluator = new HandEvaluator();
            var hand = new PokerHand(cards, "Blah");
            var result = evaluator.IsPair(hand);
            Assert.AreEqual(true, result);
        }
        #endregion
    }
}