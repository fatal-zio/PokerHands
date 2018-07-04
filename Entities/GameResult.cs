using System.Collections.Generic;

namespace Entities
{
    public class GameResult
    {
        public string WinningPlayerName { get; private set; }

        public string Reason { get; private set; }

        public GameResult(PokerHand playerOneHand, PokerHand playerTwoHand)
        {
            WinningPlayerName = DecideWinningPlayer(playerOneHand, playerTwoHand);
            Reason = GetOutcomeReason(playerOneHand, playerTwoHand);
        }

        private string DecideWinningPlayer(PokerHand playerOneHand, PokerHand playerTwoHand)
        {
            return "DRAW";
        }

        private string GetOutcomeReason(PokerHand playerOneHand, PokerHand playerTwoHand)
        {
            return "Higher Numbers";
        }

        public override string ToString()
        {
            if(WinningPlayerName == "DRAW")
            {
                return WinningPlayerName;
            }
            else
            {
                return string.Format("{0) Wins! {2}.", WinningPlayerName, Reason);
            }
        }
    }
}