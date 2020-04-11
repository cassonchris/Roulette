using System.Collections.Generic;

namespace Roulette
{
    public abstract class Player
    {
        public string Name { get; set; }
        public virtual int Bankroll { get; set; }
        public Game Game { get; set; }

        public abstract IEnumerable<Bet> MakeBets();

        public virtual void RecievePayout(Bet bet)
        {
            Bankroll += bet.Payout;
        }
    }
}