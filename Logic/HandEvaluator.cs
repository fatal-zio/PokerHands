using System;
using System.Collections.Generic;
using Entities;

namespace Logic
{

    public static class HandEvaluator
    {
        public static string Evalutate(IEnumerable<Card> redCards, IEnumerable<Card> blueCards)
        {
            if(!Validate(redCards, blueCards))
                throw new ArgumentException();


            return string.Empty;
        }

        private static bool Validate(IEnumerable<Card> redCards, IEnumerable<Card> blueCards)
        {

            return true;
        }
    }

}