using System.Collections.Generic;

namespace Entities
{
    public class GameResult
    {
        public string WinningPlayerName { get; private set; }

        public string Reason { get; private set; }

        public GameResult(IEnumerable<PokerHand> pokerHands)
        {
            WinningPlayerName = DecideWinningPlayer(pokerHands);
            Reason = GetOutcomeReason(pokerHands);
        }

        private string DecideWinningPlayer(IEnumerable<PokerHand> pokerHands)
        {
            return "DRAW";
        }

        private string GetOutcomeReason(IEnumerable<PokerHand> pokerHands)
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