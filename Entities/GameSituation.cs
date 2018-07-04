using System.Collections.Generic;

namespace Entities
{
    public class GameSituation
    {
        public List<PokerHand> Hands { get; private set; }
        public GameResult Result { get; private set; }
    }
}