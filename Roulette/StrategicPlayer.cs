using System;
using System.Collections.Generic;

namespace Roulette
{
    public class StrategicPlayer : Player
    {
        private int _successiveLoses;
        public int SuccessiveLoses
        {
            get => _successiveLoses;
            set
            {
                _successiveLoses = value;
                if (_successiveLoses > LongestLosingStreak)
                {
                    LongestLosingStreak = _successiveLoses;
                }
            }
        }

        public int LongestLosingStreak { get; set; }
        private readonly int _startingBetAmount;
        public int LargestBet { get; set; }
        private int _currentBetAmount;
        public int CurrentBetAmount
        {
            get => _currentBetAmount;
            set
            {
                _currentBetAmount = value;
                if (_currentBetAmount > Bankroll)
                {
                    _currentBetAmount = Bankroll;
                }
                if (_currentBetAmount > LargestBet)
                {
                    LargestBet = _currentBetAmount;
                }
            }
        }

        private int _startingBankroll;

        private int _mainBankroll;
        private int _profitBankroll;
        public override int Bankroll
        {
            get => _mainBankroll;
            set
            {
                if (value > _startingBankroll)
                {
                    _mainBankroll = _startingBankroll;
                    _profitBankroll += value - _startingBankroll;
                }
                else
                {
                    _mainBankroll = value;
                }
            }
        }

        public int TotalBankroll => _mainBankroll + _profitBankroll;

        public StrategicPlayer(int startingBankroll, int startingBetAmount)
        {
            Bankroll = _startingBankroll = startingBankroll;
            CurrentBetAmount = _startingBetAmount = startingBetAmount;
        }

        public override IEnumerable<Bet> MakeBets()
        {
            Bankroll -= CurrentBetAmount;
            Console.WriteLine($"{Name} is betting {CurrentBetAmount}");
            yield return new Bet
            {
                BetType = Game.AvailableBets.Black,
                Player = this,
                Wager = CurrentBetAmount
            };
        }

        public override void RecievePayout(Bet bet)
        {
            base.RecievePayout(bet);

            if (bet.Winner == true)
            {
                SuccessiveLoses = 0;
                AdjustCurrentBetAfterWin();
            }
            else
            {
                SuccessiveLoses++;
                AdjustCurrentBetAfterLoss();

                if (Bankroll <= 0)
                {
                    Game.RemovePlayer(this);
                }
            }
        }

        private void AdjustCurrentBetAfterWin()
        {
            CurrentBetAmount = _startingBetAmount;
        }

        private void AdjustCurrentBetAfterLoss()
        {
            // standard double
            CurrentBetAmount = CurrentBetAmount * 2;
            
            // double plus min
            //CurrentBetAmount = CurrentBetAmount * 2 + _startingBetAmount;

            // min increment
            //CurrentBetAmount = _startingBankroll - Bankroll;
        }
    }
}