using Entities;
using Common;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void CanTest()
        {
            Assert.AreEqual(true, true);
        }

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
    }
}