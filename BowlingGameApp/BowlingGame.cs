using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGameApp
{
    public class BowlingGame
    {
        private GameStatus status;
        private Rules rules;
        private Score score;

        public void PlayGame()
        {
            status = new GameStatus();
            score = new Score();
            rules = new Rules();


            while (status.currentRound <= status.rounds)
            {
                
                Console.WriteLine($"Round: {status.currentRound}");

                while (status.throwsLeft > 0)
                {
                    Console.WriteLine("PRESS ENTER TO THROW THE BALL");
                    Console.ReadLine();

                    score.currentRoundScore.Add(status.throwBall(status.pins));
                    status.pins = status.CalculateRemainingPins(status.pins, score.currentRoundScore);
                    status.throwsLeft--;

                    if (!status.extendedRound)
                    {
                        if (rules.isSpare(status.pins, status.throwsLeft))
                        {
                            status.spareCurrentRound = true;
                            Console.WriteLine("IT'S A SPAAAREEE!!!");
                        }
                        if (rules.isStrike(status.pins, status.throwsLeft))
                        {
                            status.strikeCurrentRound = true;
                            status.throwsLeft = 0;
                            Console.WriteLine("IT'S A STRIIIIIKEEEE!!!");
                        }
                    }
                    else
                    {
                        if (status.throwsLeft > 0 && status.pins == 0)
                        {
                            status.pins = status.maxPins;
                        }
                    }

                    Console.WriteLine($"You Scored: {score.currentRoundScore[score.currentRoundScore.Count - 1]}");

                    if (status.throwsLeft == 0)
                    {
                        var sumOfRoundScore = score.calculateTotalRoundScore(score.currentRoundScore, status.strikeBonusEarned, status.spareBonusEarned, status.extendedRound);
                        UpdateRoundBonus();


                        if (status.extendedRound)
                        {
                            Console.WriteLine($"You Have Earned {status.throwsLeft} More Throws");
                        }
                        else
                        {
                            score.totalScore.Add(sumOfRoundScore);
                            Console.WriteLine($"You're Score For The Current Round Is: {sumOfRoundScore}");
                            Console.WriteLine($"You're Total Score is: {score.totalScore.Sum()}");
                            if (status.currentRound == 10)
                            {
                                Console.WriteLine("The Game Is Finished. Press Enter To Exit");
                                Console.ReadLine();
                            }
                        }
                    }
                }
                UpdateGameStatus();
                Console.WriteLine("................................................................................................");
            }

        }


        private void UpdateGameStatus()
        {
            status.throwsLeft = status.maxThrows;
            status.currentRound++;
            score.currentRoundScore.Clear();
            status.pins = status.maxPins;
        }


        private void UpdateRoundBonus()
        {
            if (status.extendedRound)
            {
                status.extendedRound = false;
            }

            if (status.strikeBonusEarned)
            {
                status.strikeBonusEarned = false;
            }

            if (status.spareBonusEarned)
            {
                status.spareBonusEarned = false;
            }

            if (status.strikeCurrentRound)
            {
                if (status.currentRound == 10)
                {
                    status.extendedRound = true;
                    status.throwsLeft = status.maxThrows;
                    status.strikeCurrentRound = false;
                    status.pins = status.maxPins;
                }
                else
                {
                    status.strikeCurrentRound = false;
                    status.strikeBonusEarned = true;
                }
            }
            if (status.spareCurrentRound)
            {
                if (status.currentRound == 10)
                {
                    status.extendedRound = true;
                    status.throwsLeft = 1;
                    status.spareCurrentRound = false;
                    status.pins = status.maxPins;
                }
                else
                {
                    status.spareCurrentRound = false;
                    status.spareBonusEarned = true;
                }
            }
        }
    }
}
