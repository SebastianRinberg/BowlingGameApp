namespace BowlingGameApp
{
    public class Score
    {
        public List<int> totalScore { get; set; }
        public List<int> currentRoundScore { get; set; }


        public Score()
        {
            totalScore = new List<int>();
            currentRoundScore = new List<int>();
        }

        public int calculateTotalRoundScore(List<int> currentRoundScore, bool strikeBonusEarned, bool spareBonusEarned, bool extendedRound)
        {
            if (!extendedRound) {
                if (strikeBonusEarned)
                {
                    currentRoundScore.AddRange(currentRoundScore);
                }
                else if (spareBonusEarned)
                {
                    currentRoundScore.Add(currentRoundScore[0]);
                }
            }
            return currentRoundScore.Sum();
        }
    }
}
