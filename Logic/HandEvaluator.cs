using System;
using System.Collections.Generic;
using Common;
using static Common.Enums.HandTypes;
using Entities;
using System.Linq;

namespace Logic
{
    public class HandEvaluator
    {

        public static string Evalutate(IEnumerable<PokerHand> pokerHands)
        {
            if (!Validate(pokerHands))
                throw new ArgumentException();

            return GetGameResult(pokerHands).ToString();
        }

        private static bool Validate(IEnumerable<PokerHand> pokerHands)
        {

            return true;
        }

        private static GameResult GetGameResult(IEnumerable<PokerHand> pokerHands)
        {
            return new GameResult(pokerHands);
        }

        private Enums.HandTypes EvaluateHandType(PokerHand hand)
        {
            if (IsStraightFlush(hand))
                return StraightFlush;

            if (IsFourOfAKind(hand))
                return FourOfAKind;

            if (IsFullHouse(hand))
                return FullHouse;

            if (IsFlush(hand))
                return Flush;

            if (IsStraight(hand))
                return Straight;

            if (IsThreeOfAKind(hand))
                return ThreeOfAKind;

            if (IsTwoPairs(hand))
                return TwoPairs;

            return IsPair(hand) ? Pair : HighCard;
        }

        public bool IsStraightFlush(PokerHand hand)
        {
            var firstSuit = hand.Cards.First().Suit;

            if (!hand.Cards.All(o => o.Suit == firstSuit))
                return false;

            var cardValues = hand.Cards.Select(o => o.Value);

            return !cardValues.Select((i,j) => i-j).Distinct().Skip(1).Any();
        }

        public bool IsFourOfAKind(PokerHand hand)
        {

            return false;
        }

        public bool IsFullHouse(PokerHand hand)
        {

            return false;
        }

        public bool IsFlush(PokerHand hand)
        {
            var firstSuit = hand.Cards.First().Suit;
            return hand.Cards.All(o => o.Suit == firstSuit) ? true : false;
        }

        public bool IsStraight(PokerHand hand)
        {
            var cardValues = hand.Cards.Select(o => o.Value);
            return !cardValues.Select((i,j) => i-j).Distinct().Skip(1).Any();
        }

        public bool IsThreeOfAKind(PokerHand hand)
        {

            return false;
        }

        public bool IsTwoPairs(PokerHand hand)
        {

            return false;
        }

        public bool IsPair(PokerHand hand)
        {
            return false;
        }
    }
}