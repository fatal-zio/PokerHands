using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using static Common.Enums.HandTypes;

namespace Entities
{
    public class PokerHand
    {
        public IEnumerable<Card> Cards { get; }
        public Enums.HandTypes HandType { get; private set; }
        public string PlayerName { get; }
        public Card HighestCard { get; private set; }

        public PokerHand(IEnumerable<Card> cards, string playerName)
        {
            var enumerable = cards as Card[] ?? cards.ToArray();

            if (enumerable.Length != 5)
                throw new ArgumentException();

            if (playerName.IsNullOrEmpty())
                throw new ArgumentException();

            Cards = enumerable;
            PlayerName = playerName;

            HandType = EvaluateHandType();
            HighestCard = GetHighCard();
        }

        private Card GetHighCard()
        {
            return Cards.ToArray().OrderByDescending(o => o.Value).FirstOrDefault();
        }

        private Enums.HandTypes EvaluateHandType()
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

        private bool IsStraightFlush()
        {
            var firstSuit = Cards.First().Suit;

            if (!Cards.All(o => o.Suit == firstSuit))
                return false;

            var cardValues = Cards.Select(o => o.Value);

            return !cardValues.Select((i, j) => i - j).Distinct().Skip(1).Any();
        }

        private bool IsFourOfAKind()
        {
            return Cards.GroupBy(c => c.Value).Any(g => g.Count() == 4);
        }

        private bool IsFullHouse()
        {
            return Cards.GroupBy(c => c.Value).Count() == 2 && Cards.GroupBy(c => c.Value).Any(g => g.Count() == 3);
        }

        private bool IsFlush()
        {
            var firstSuit = Cards.First().Suit;
            return Cards.All(o => o.Suit == firstSuit) ? true : false;
        }

        private bool IsStraight()
        {
            var cardValues = Cards.Select(o => o.Value);
            return !cardValues.Select((i, j) => i - j).Distinct().Skip(1).Any();
        }

        private bool IsThreeOfAKind()
        {
            return Cards.GroupBy(c => c.Value).Any(g => g.Count() == 3);
        }

        private bool IsTwoPairs()
        {
            var handList = Cards.Select(o => o.Value);
            var groups = handList.GroupBy(c => c).Where(grp => grp.Count() == 2);

            return groups.Count() == 2;
        }

        private bool IsPair()
        {
            return Cards.GroupBy(c => c.Value).Any(g => g.Count() == 2);
        }
    }
}