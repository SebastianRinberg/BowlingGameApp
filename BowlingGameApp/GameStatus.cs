using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGameApp
{
    public class GameStatus
    {
        public int rounds { get; set; }
        public int currentRound { get; set; }
        public int throwsLeft { get; set; }
        public int pins { get; set; }
        public int maxPins { get; set; }
        public bool strikeBonusEarned { get; set; }
        public bool spareBonusEarned { get; set; }
        public bool strikeCurrentRound { get; set; }
        public bool spareCurrentRound { get; set; }
        public bool extendedRound { get; set; }
        public int maxThrows { get; set; }


        public GameStatus()
        {
            rounds = 10;
            currentRound = 1;
            pins = 10;
            maxPins = 10;
            maxThrows = 2;
            throwsLeft = maxThrows;
            strikeCurrentRound = false;
            spareCurrentRound = false;
            strikeBonusEarned = false;
            spareBonusEarned = false;
            extendedRound = false;
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
    }
}
