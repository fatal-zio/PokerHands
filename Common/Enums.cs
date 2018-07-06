namespace Common
{
    public class Enums
    {
        public enum Suits
        {
            C, D, H, S
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