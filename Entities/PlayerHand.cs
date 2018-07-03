using System;
using System.Collections.Generic;
using System.Linq;
using Common;

namespace Entities
{

    public class PlayerHand
    {

        public IEnumerable<Card> Cards { get; }
        public int HandValue { get; private set; }
        public string PlayerName { get; }

        public PlayerHand(IEnumerable<Card> cards, string playerName)
        {
            var enumerable = cards as Card[] ?? cards.ToArray();

            if(enumerable.Length != 5)
                throw new ArgumentException();

            if(playerName.IsNullOrEmpty())
                throw new ArgumentException();

            Cards = enumerable;
            PlayerName = playerName;

            SetHandValue();
        }

        private void SetHandValue()
        {
            HandValue = 0;
        }
    }
}