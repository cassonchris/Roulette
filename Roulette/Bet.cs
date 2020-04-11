namespace Roulette
{
    public class BetType
    {
        public int PayoutMultiplier { get; set; }
        public int? Number { get; set; }
        public Color? Color { get; set; }

        public BetType(int payoutMultiplier, int? number, Color? color)
        {
            PayoutMultiplier = payoutMultiplier;
            Number = number;
            Color = color;
        }
    }

    public class Bet
    {
        public int Wager { get; set; }
        public BetType BetType { get; set; }
        public Player Player { get; set; }
        public bool? Winner { get; set; }
        public int Payout { get; set; }
    }
}