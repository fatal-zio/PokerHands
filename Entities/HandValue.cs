using System.Linq;
using Common;
using static Common.Enums.HandTypes;

namespace Entities
{
    public class HandValue
    {
        public Enums.HandTypes HandType { get; private set; }

        public Card HighestCard { get; private set; }


        public HandValue(PokerHand hand)
        {
            HighestCard = GetHighCard(hand);
            HandType = EvaluateHandType(hand);
        }

        private Enums.HandTypes EvaluateHandType(PokerHand hand)
        {
            if (IsStraightFlush())
                return StraightFlush;

            if (IsFourOfAKind())
                return FourOfAKind;

            if (IsFullHouse())
                return FullHouse;

            if (IsFlush())
                return Flush;

            if (IsStraight())
                return Straight;

            if (IsThreeOfAKind())
                return ThreeOfAKind;

            if (IsTwoPairs())
                return TwoPairs;

            return IsPair() ? Pair : HighCard;
        }

        private Card GetHighCard(PokerHand hand)
        {
            return hand.Cards.ToArray().OrderByDescending(o => o.Value).FirstOrDefault();
        }

        private bool IsStraightFlush()
        {

            return false;
        }

        private bool IsFourOfAKind()
        {

            return false;
        }

        private bool IsFullHouse()
        {

            return false;
        }

        private bool IsFlush()
        {

            return false;
        }

        private bool IsStraight()
        {

            return false;
        }

        private bool IsThreeOfAKind()
        {

            return false;
        }

        private bool IsTwoPairs()
        {

            return false;
        }

        private bool IsPair()
        {

            return false;
        }

        private bool IsHighCard()
        {

            return false;
        }
    }
}