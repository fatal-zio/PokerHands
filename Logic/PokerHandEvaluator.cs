using System;
using System.Collections.Generic;
using Common;
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
    }
}