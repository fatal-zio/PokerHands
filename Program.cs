using System;
using Logic;

namespace PokerHands
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(HandEvaluator.Evalutate( HandGenerator.GenerateHands()));
            Console.ReadLine();
        }
    }
}
