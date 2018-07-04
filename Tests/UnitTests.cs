using Entities;
using Common;
using NUnit.Framework;
using Logic;
using System.Linq;

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
            var generator = new HandGenerator();

            var hands = generator.GenerateHands();

            Assert.AreEqual(expected: 2, actual: hands.ToList().Count);
        }

        #endregion
    }
}