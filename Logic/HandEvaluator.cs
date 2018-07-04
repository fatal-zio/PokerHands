using System;
using System.Collections.Generic;
using Entities;

namespace Logic
{

    public static class HandEvaluator
    {

        public static string Evalutate(PokerHand playerOneHand, PokerHand playertwoHand)
        {
            if (!Validate(playerOneHand, playertwoHand))
                throw new ArgumentException();

            return GetGameResult(playerOneHand, playertwoHand).ToString();
        }

        private static bool Validate(PokerHand playerOneHand, PokerHand playertwoHand)
        {

            return true;
        }

        private static GameResult GetGameResult(PokerHand playerOneHand, PokerHand playertwoHand)
        {
            return new GameResult(playerOneHand, playertwoHand);
        }
    }

}