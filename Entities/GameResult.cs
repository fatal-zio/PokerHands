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
        private IEnumerable<PokerHand> PokerHands { get; set; }

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

            return "DRAW";

            //HighCard, Pair, TwoPairs, ThreeOfAKind, Straight, Flush, FullHouse, FourOfAKind, StraightFlush

            // switch(type)
            // {
            //     case StraightFlush:

            //     break;

            //     case FourOfAKind:

            //     break;

            //     case FullHouse:

            //     break;

            //     case Flush:
                
            //     break;

            //     case Straight:

            //     break;

            //     case ThreeOfAKind:

            //     break;

            //     case TwoPairs:

            //     break;

            //     case Pair:

            //     break;

            //     case HighCard:

            //     break;

            //     default:
            //         return "DRAW";
            // }

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