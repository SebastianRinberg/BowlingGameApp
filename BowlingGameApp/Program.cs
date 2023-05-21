using BowlingGameApp;

public class Program
{
    public static void Main()
    {

        BowlingGame game = new BowlingGame();
        Score score = new Score();
        Rules rules = new Rules();
        bool spareBonusEarned = game.spareBonusEarned;
        bool strikeBonusEarned = game.strikeBonusEarned;
        bool extendedRound = false;


        while (game.currentRound <= game.rounds)
        {
            bool strikeCurrentRound = game.strikeCurrentRound;
            bool spareCurrentRound = game.spareCurrentRound;
            int throwsLeft = game.throwsLeft;
            int pins = game.maxPins;
            Console.WriteLine($"Round: {game.currentRound}");

            while (throwsLeft > 0)
            {
                Console.WriteLine("PRESS ENTER TO THROW THE BALL");
                Console.ReadLine();

                score.currentRoundScore.Add(game.throwBall(pins));
                pins = game.CalculateRemainingPins(pins, score.currentRoundScore);
                throwsLeft--;

                if (!extendedRound)
                {
                    if (rules.isSpare(pins, throwsLeft))
                    {
                        spareCurrentRound = true;
                        Console.WriteLine("IT'S A SPAAAREEE!!!");
                    }
                    if (rules.isStrike(pins, throwsLeft))
                    {
                        strikeCurrentRound = true;
                        throwsLeft = 0;
                        Console.WriteLine("IT'S A STRIIIIIKEEEE!!!");
                    }
                }
                else
                {
                    if (throwsLeft > 0 && pins == 0)
                    {
                        pins = game.maxPins;
                    }
                }


                Console.WriteLine($"You Scored: {score.currentRoundScore[score.currentRoundScore.Count - 1]}");

                if (throwsLeft == 0)
                {
                    var sumOfRoundScore = score.calculateTotalRoundScore(score.currentRoundScore, strikeBonusEarned, spareBonusEarned, extendedRound);
                    game.updateRoundBonus(ref strikeBonusEarned, ref spareBonusEarned, game.currentRound, ref strikeCurrentRound, ref spareCurrentRound, ref throwsLeft, ref extendedRound, ref pins);
                   

                    if (extendedRound)
                    {
                        Console.WriteLine($"You Have Earned {throwsLeft} More Throws");
                    }
                    else
                    {
                        score.totalScore.Add(sumOfRoundScore);
                        Console.WriteLine($"You're Score For The Current Round Is: {sumOfRoundScore}");
                        Console.WriteLine($"You're Total Score is: {score.totalScore.Sum()}");
                        if (game.currentRound == 10)
                        {
                            Console.WriteLine("The Game Is Finished. Press Enter To Exit");
                            Console.ReadLine();
                        }
                    }
                }
            }
            score.currentRoundScore.Clear();
            game.currentRound++;
            Console.WriteLine("................................................................................................");
        }
    }
}










