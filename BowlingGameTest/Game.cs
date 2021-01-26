using System;

namespace BowlingGameTest
{
    public class Game
    {
        private int[] rolls = new int[21];
        private int currentRool = 0;
        private int _topScoreToGetBonusStrike = 10;

        public Game()
        {
        }

        public void Roll(int pins)
        {
            rolls[currentRool++] = pins;
        }

        public int Score()
        {
            int score = 0;
            int frameIndex = 0;
            for (int frame = 0; frame < _topScoreToGetBonusStrike; frame++)
            {
                if (IsStrike(frameIndex))
                {
                    score += _topScoreToGetBonusStrike + StrikeBonus(frameIndex);

                    frameIndex++;
                }
                else if (IsSpare(frameIndex))
                {
                    score += _topScoreToGetBonusStrike + SpareBonus(frameIndex);
                    frameIndex += 2;
                }
                else
                {
                    score += SumOfBallsInFrame(frameIndex);
                    frameIndex += 2;
                }
            }
            return score;
        }

        private bool IsStrike(int frameIndex)
        {
            return rolls[frameIndex] == _topScoreToGetBonusStrike;
        }

        private int SumOfBallsInFrame(int frameIndex)
        {
            return rolls[frameIndex] +
                        rolls[frameIndex + 1];
        }

        private int SpareBonus(int frameIndex)
        {
            return rolls[frameIndex + 2];
        }

        private int StrikeBonus(int frameIndex)
        {
            return rolls[frameIndex + 1] +
                      rolls[frameIndex + 2];
        }

        private bool IsSpare(int frameIndex)
        {
            return rolls[frameIndex] +
                rolls[frameIndex + 1] == _topScoreToGetBonusStrike;
        }
    }
}