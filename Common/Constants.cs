using System.Collections.Generic;

namespace Common
{

    public static class Constants
    {
        private const int nUMBER_OF_CARDS_IN_DECK = 52;

        public static int NUMBER_OF_CARDS_IN_DECK => nUMBER_OF_CARDS_IN_DECK;

        private const int nUMBER_OF_CARDS_IN_HAND = 5;

        public static int NUMBER_OF_CARDS_IN_HAND => nUMBER_OF_CARDS_IN_HAND;

        private const string pLAYER_ONE_NAME = "BLUE";

        public static string PLAYER_ONE_NAME => pLAYER_ONE_NAME;

        private const string pLAYER_TWO_NAME = "RED";

        public static string PLAYER_TWO_NAME => pLAYER_TWO_NAME;
    }
}