using System.Linq;

namespace BowlingKata.Logic
{
    public class Game
    {
        private readonly int[] _rolls = new int[21];
        private int _currentRoll;
        private int _totalScore;

        public void Roll(int pins)
        {
            _rolls[_currentRoll] = pins;
            _currentRoll++;
        }
        
        public int Score()
        {
            _currentRoll = 0;

            for (int frame = 1; frame < 11; frame++)
            {
                if (IsStrike())
                {
                    AddStrikeBonus();
                }
                else if (IsSpare())
                {
                    AddSpareBonus();
                }
                else
                {
                    AddNormalScore();
                }
            }

            return _totalScore;
        }

        private void AddNormalScore()
        {
            _totalScore += _rolls[_currentRoll] + _rolls[_currentRoll + 1];
            _currentRoll += 2;
        }

        private void AddSpareBonus()
        {
            _totalScore += 10 + _rolls[_currentRoll + 2];
            _currentRoll += 2;
        }
        private void AddStrikeBonus()
        {
            _totalScore += 10 + _rolls[_currentRoll + 1] +_rolls[_currentRoll + 2];
            _currentRoll += 1;
        }
        private bool IsSpare()
        {
            return _rolls[_currentRoll] + _rolls[_currentRoll + 1] == 10;
        }
        private bool IsStrike()
        {
            return _rolls[_currentRoll] == 10;
        }
    }
}