using BowlingGameApp;

namespace BowlingGameApp.UnitTests
{
    public class ScoreTests
    {

        private readonly Score _score;

        public ScoreTests()
        {
            _score = new Score();
        }

        [Theory]
        [InlineData(2, 1, 1)]
        [InlineData(3, 2, 1)]
        [InlineData(9, 2, 7)]
        public void calculateTotalRoundScore_ScoresThatDoesNotGiveBonus_CalculatesCorrectSum(
            int expected, int firstThrow, int secondThrow)
        {
            //Arrange
            _score.currentRoundScore.Add(firstThrow);
            _score.currentRoundScore.Add(secondThrow);

            //Act
            var totalRoundScore = _score.calculateTotalRoundScore(_score.currentRoundScore, false, false, false);

            //Assert
            Assert.Equal(expected, totalRoundScore);
        }


        [Theory]
        [InlineData(20, 5, 5)]
        [InlineData(12, 1, 5)]
        [InlineData(18, 2, 7)]
        [InlineData(20, 10, 0)]
        public void calculateTotalRoundScore_UserGotStrikeLastRound_AddsBonusAndCalculatesSumCorrectly(
            int expected, int firstThrow, int secondThrow)
        {
            //Arrange
            _score.currentRoundScore.Add(firstThrow);
            _score.currentRoundScore.Add(secondThrow);

            //Act
            var totalRoundScore = _score.calculateTotalRoundScore(_score.currentRoundScore, true, false, false);

            //Assert
            Assert.Equal(expected, totalRoundScore);
        }


        [Theory]
        [InlineData(15, 5, 5)]
        [InlineData(7, 1, 5)]
        [InlineData(11, 2, 7)]
        [InlineData(20, 10, 0)]
        public void calculateTotalRoundScore_UserGotSpareLastRound_AddsBonusAndCalculatesSumCorrectly(
           int expected, int firstThrow, int secondThrow)
        {
            //Arrange
            _score.currentRoundScore.Add(firstThrow);
            _score.currentRoundScore.Add(secondThrow);

            //Act
            var totalRoundScore = _score.calculateTotalRoundScore(_score.currentRoundScore, false, true, false);

            //Assert
            Assert.Equal(expected, totalRoundScore);
        }

        [Theory]
        [InlineData(10, 5, 5)]
        [InlineData(10, 10, 0)]
        public void calculateTotalRoundScore_UserGetStrikeOrSpareInCurrentRound_BonusIsNotAddedToScore(
           int expected, int firstThrow, int secondThrow)
        {
            //Arrange
            _score.currentRoundScore.Add(firstThrow);
            _score.currentRoundScore.Add(secondThrow);

            //Act
            var totalRoundScore = _score.calculateTotalRoundScore(_score.currentRoundScore, false, false, false);

            //Assert
            Assert.Equal(expected, totalRoundScore);
        }

    }
}







