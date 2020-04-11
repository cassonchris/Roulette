using System;
using System.Linq;
using System.Threading;

namespace Roulette
{
    class Program
    {
        static void Main(string[] args)
        {
            var profits = new int[50];
            for (int i = 0; i < 50; i++)
            {
                profits[i] = RunGameSession();
            }

            var averageProfit = profits.Average();
            Console.WriteLine($"Average profit -> {averageProfit}");
            Console.ReadLine();
        }

        private static int RunGameSession()
        {
            var startingBankroll = 635;

            var game = new Game();
            var strategicPlayer = new StrategicPlayer(startingBankroll, 5)
            {
                Name = "Chris"
            };
            game.AddPlayer(strategicPlayer);

            for (int i = 0; i < 30; i++)
            {
                game.PlayRound();
            }

            Console.WriteLine($"{strategicPlayer.Name}'s final bankroll -> {strategicPlayer.TotalBankroll}");
            Console.WriteLine($"{strategicPlayer.Name}'s longest losing streak -> {strategicPlayer.LongestLosingStreak}");
            Console.WriteLine($"{strategicPlayer.Name}'s largest bet -> {strategicPlayer.LargestBet}");

            return strategicPlayer.TotalBankroll - startingBankroll;
        }
    }
}
