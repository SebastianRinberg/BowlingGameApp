using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BowlingGameApp.UnitTests
{
    public class GameStatusTests
    {
        private readonly GameStatus _status;


        public GameStatusTests()
        {


           _status = new GameStatus();


        }

        [Theory]
        [InlineData(10, 10, 0)]
        [InlineData(3, 10, 7)]
        [InlineData(9, 10, 1)]
        [InlineData(0, 5, 5)]
        [InlineData(1, 2, 1)]
        public void CalculateRemainingPins_UserOverturnsDifferentCombinationsOfPins_CalculatesRemainingPinsCorrectly(
           int expected, int initialPins, int pinsOverturned)
        {
            //Arrange
            var currentRoundScore = new List<int>();
            currentRoundScore.Add(pinsOverturned);

            //Act
            var result = _status.CalculateRemainingPins(initialPins, currentRoundScore);

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(10)]
        public void throwBall_UserThrowsBallWithAllPinsRemaining_ResultIsARandomNumberBetweenZeroAndTen(int pinsRemaining)
        {
           
            //Act and Assert
            for (int i = 0; i < 50; i++)
            {
                var result = _status.throwBall(pinsRemaining);
                Assert.InRange(result, 0, 10);
            }
        }

        [Theory]
        [InlineData(9)]
        [InlineData(8)]
        [InlineData(7)]
        [InlineData(6)]
        [InlineData(4)]
        [InlineData(1)]
        [InlineData(0)]
        public void throwBall_UserThrowsBallWithLessThanTenPinsRemaining_ResultIsARandomNumberBetweenZeroAndRemainingPins(int pinsRemaining)
        {

            //Act and Assert
            for (int i = 0; i < 50; i++)
            {
                var result = _status.throwBall(pinsRemaining);
                Assert.InRange(result, 0, pinsRemaining);
            }
        }
    }

}
