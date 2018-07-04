using Common;

namespace Entities
{
    public class Card
    {
        public int Value { get; set; }
        public string Name { get; private set; }

        public string Suit { get; private set; }

        public override string ToString()
        {

            return string.Empty;
        }

        public Card(Enums.CardValues value, Enums.Suits suit)
        {
            Value = (int)value;
            Name = value.ToString();
            Suit = suit.ToString();
        }
    }
}