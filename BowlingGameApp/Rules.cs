namespace BowlingGameApp
{
    public class Rules
    {
        public bool isStrike(int pinsRemaining, int throwsLeft)
        {
            return pinsRemaining == 0 && throwsLeft == 1 ? true : false;
        }

        public bool isSpare(int pinsRemaining, int throwsLeft)
        {
            return pinsRemaining == 0 && throwsLeft == 0 ? true : false;
        }
    }
}
