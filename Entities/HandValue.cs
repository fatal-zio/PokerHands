using System.Linq;
using Common;
using static Common.Enums.HandTypes;

namespace Entities
{
    public class HandValue
    {
        public Enums.HandTypes HandType { get; private set; }

        public Card HighestCard { get; private set; }

        public HandValue(PokerHand hand, Enums.HandTypes handType)
        {
            HighestCard = GetHighCard(hand);
            HandType = handType;
        }

        private Card GetHighCard(PokerHand hand)
        {
            return hand.Cards.ToArray().OrderByDescending(o => o.Value).FirstOrDefault();
        }
    }
}