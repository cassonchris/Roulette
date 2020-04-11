using System;
using System.Collections.Generic;

namespace Roulette
{
    public class Game
    {
        public Wheel Wheel { get; set; }
        public IList<Player> Players { get; set; }
        public AvailableBets AvailableBets { get; set; }
        public List<Bet> Bets { get; set; }

        public Game()
        {
            Wheel = new Wheel();
            AvailableBets = new AvailableBets();
            Players = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
            player.Game = this;
        }

        public void RemovePlayer(Player player)
        {
            Players.Remove(player);
            player.Game = null;
        }

        public void PlayRound()
        {
            Bets = new List<Bet>();

            MakeBets();
            var result = SpinWheel();
            ResolveBets(result);
        }

        private void MakeBets()
        {
            foreach (var player in Players)
            {
                Bets.AddRange(player.MakeBets());
            }
        }

        private Number SpinWheel()
        {
            var result = Wheel.Spin();
            Console.WriteLine($"{result.Value} {result.Color}");
            return result;
        }

        private void ResolveBets(Number number)
        {
            foreach (var bet in Bets)
            {
                if (bet.BetType.Color == number.Color)
                {
                    bet.Winner = true;
                    bet.Payout = bet.Wager * bet.BetType.PayoutMultiplier;
                    Console.WriteLine($"Paying {bet.Payout} to {bet.Player.Name}");
                }

                bet.Player.RecievePayout(bet);
            }
        }
    }

    public class AvailableBets
    {
        public BetType Black => new BetType(2, null, Color.Black);
        public BetType Red => new BetType(2, null, Color.Red);
    }
}