using System.Collections.Generic;
using System.Linq;

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
            var winningValue = pokerHands.OrderByDescending(o => o.HandValue).FirstOrDefault().HandValue;
            var winningHands = pokerHands.Where(o => o.HandValue.Equals(winningValue));

            if(winningHands.Count() > 1)
            {
                return "DRAW";
            }

            return winningHands.First().PlayerName;
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
                return string.Format("{0} Wins! {1}.", WinningPlayerName, Reason);
            }
        }
    }
}