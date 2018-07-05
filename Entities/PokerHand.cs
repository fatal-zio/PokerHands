using System;
using System.Collections.Generic;
using System.Linq;
using Common;

namespace Entities
{

    public class PokerHand
    {

        public IEnumerable<Card> Cards { get; }
        public int HandValue { get; private set; }
        public string PlayerName { get; }

        public PokerHand(IEnumerable<Card> cards, string playerName)
        {
            var enumerable = cards as Card[] ?? cards.ToArray();

            if(enumerable.Length != 5)
                throw new ArgumentException();

            if(playerName.IsNullOrEmpty())
                throw new ArgumentException();

            Cards = enumerable;
            PlayerName = playerName;

            SetValue();
        }

        private void SetValue()
        {
            var r = new Random();
            HandValue = r.Next(0, 100);
        }
    }
}