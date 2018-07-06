namespace Common
{
    public class Enums
    {
        public enum Suits
        {
            Clubs, Diamonds, Hearts, Spades
        }

        public enum CardValues
        {
            Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace
        }

        public enum HandTypes
        {
            HighCard, Pair, TwoPairs, ThreeOfAKind, Straight, Flush, FullHouse, FourOfAKind, StraightFlush
        }
    }
}