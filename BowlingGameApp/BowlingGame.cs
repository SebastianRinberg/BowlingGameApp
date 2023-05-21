namespace BowlingGameApp
{
    public class BowlingGame
    {
        public int rounds { get; set; }
        public int currentRound { get; set; }
        public int throwsLeft { get; set; }
        public int maxPins { get; set; }
        public bool strikeBonusEarned { get; set; }
        public bool spareBonusEarned { get; set; }
        public bool strikeCurrentRound { get; set; }
        public bool spareCurrentRound { get; set; }

        public BowlingGame()
        {
            rounds = 10;
            currentRound = 1;
            maxPins = 10;
            throwsLeft = 2;
            strikeCurrentRound = false;
            spareCurrentRound = false;
            strikeBonusEarned = false;
            spareBonusEarned |= false;
        }


        public int throwBall(int pinsRemaining)
        {
            Random random = new Random();
            return random.Next(0, pinsRemaining + 1);
        }

        public int CalculateRemainingPins(int pins, List<int> currentRoundScore)
        {
            return pins - currentRoundScore[currentRoundScore.Count - 1];
        }

        public void updateRoundBonus(ref bool strikeBonusEarned, ref bool spareBonusEarned, int currentRound, ref bool strikeCurrentRound, ref bool spareCurrentRound, ref int throwsLeft, ref bool extendedRound, ref int pins)
        {
            if (extendedRound)
            {
                extendedRound = false;
            }

            if (strikeBonusEarned)
            {
                strikeBonusEarned = false;
            }

            if (spareBonusEarned)
            {
                spareBonusEarned = false;
            }

            if (strikeCurrentRound)
            {
                if (currentRound == 10)
                {
                    extendedRound = true;
                    throwsLeft = 2;
                    strikeCurrentRound = false;
                    pins = 10;
                }
                else
                {
                    strikeBonusEarned = true;
                }
            }
            if (spareCurrentRound)
            {
                if (currentRound == 10)
                {
                    extendedRound = true;
                    throwsLeft = 1;
                    spareCurrentRound = false;
                    pins = 10;
                }
                else
                {
                    spareBonusEarned = true;
                }
            }
        }
    }
}
