using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Common.Enums.HandTypes;

namespace Entities
{
    public class GameResult
    {
        public string WinningPlayerName { get; private set; }
        public string Reason { get; private set; }

        public IEnumerable<PokerHand> PokerHands { get; private set; }

        public GameResult(IEnumerable<PokerHand> pokerHands)
        {
            PokerHands = pokerHands;
            WinningPlayerName = DecideWinningPlayer();
        }

        private string DecideWinningPlayer()
        {
            var winningValue = PokerHands.OrderByDescending(o => o.HandType).FirstOrDefault().HandType;
            var winningHands = PokerHands.Where(o => o.HandType.Equals(winningValue));

            if (winningHands.Count() > 1)
            {
                return SettleDraw();
            }
            else
            {
                Reason = winningHands.First().HandType.ToString();

                return winningHands.First().PlayerName;
            }
        }

        private string SettleDraw()
        {
            var type = PokerHands.FirstOrDefault().HandType;
            var retVal = "DRAW";

            switch (type)
            {
                case StraightFlush:
                    retVal = DecideStraightFlushDraw();
                    break;

                case FourOfAKind:
                    retVal = DecideFourOfAKindDraw();
                    break;

                case FullHouse:
                    retVal = DecideFullHouseDraw();
                    break;

                case Flush:
                    retVal = DecideFlushDraw();
                    break;

                case Straight:
                    retVal = DecideStraightDraw();
                    break;

                case ThreeOfAKind:
                    retVal = DecideThreeOfAKindDraw();
                    break;

                case TwoPairs:
                    retVal = DecideTwoPairDraw();
                    break;

                case Pair:
                    retVal = DecidePairDraw();
                    break;

                case HighCard:
                    retVal = DecideHighCardDraw();
                    break;
            }

            return retVal;
        }

        private string DecideHighCardDraw()
        {

            return "DRAW";
        }

        private string DecidePairDraw()
        {

            return "DRAW";
        }

        private string DecideTwoPairDraw()
        {

            return "DRAW";
        }

        private string DecideThreeOfAKindDraw()
        {

            return "DRAW";
        }

        private string DecideStraightDraw()
        {

            return "DRAW";
        }

        private string DecideFlushDraw()
        {

            return "DRAW";
        }

        private string DecideFullHouseDraw()
        {

            return "DRAW";
        }

        private string DecideFourOfAKindDraw()
        {

            return "DRAW";
        }

        private string DecideStraightFlushDraw()
        {

            return "DRAW";
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            if (WinningPlayerName == "DRAW")
            {
                sb.AppendLine("DRAW!");
            }
            else
            {
                sb.AppendLine(string.Format("{0} Wins! {1}!", WinningPlayerName, Reason));
            }

            foreach (var hand in PokerHands)
            {
                sb.AppendLine(hand.PlayerName);

                foreach (var card in hand.Cards)
                {
                    sb.Append(string.Format("{0}of{1} ", card.Name, card.Suit));
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}