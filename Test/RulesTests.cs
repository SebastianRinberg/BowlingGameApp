using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace BowlingGameApp.UnitTests
{
    public class RulesTests
    {

        private Rules _rules;

        public RulesTests()
        {
            _rules = new Rules();
        }


        [Theory]
        [InlineData(0, 1)]
        public void IsStrike_UserScoresAStrike_ReturnsTrue(
            int pinsRemaining, int remainingThrows)
        {
            //Act
            bool result = _rules.isStrike(pinsRemaining, remainingThrows);

            //Assert
            Assert.True(result);
        }


        [Theory]
        [InlineData(9, 1)]
        [InlineData(0, 0)]
        public void IsStrike_UserDoesNotScoreAStrike_ReturnsFalse(
            int pinsRemaining, int remainingThrows)
        {
            //Act
            bool result = _rules.isStrike(pinsRemaining, remainingThrows);

            //Assert
            Assert.False(result);
        }


        [Theory]
        [InlineData(0, 0)]
        public void IsSpare_UserScoresASpare_ReturnsTrue(
            int pinsRemaining, int remainingThrows)
        {
            //Act
            bool result = _rules.isSpare(pinsRemaining, remainingThrows);

            //Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(9, 1)]
        [InlineData(0, 1)]
        public void IsSpare_UserDoesNotScoreASpare_ReturnsFalse(
            int pinsRemaining, int remainingThrows)
        {
            //Act
            bool result = _rules.isSpare(pinsRemaining, remainingThrows);

            //Assert
            Assert.False(result);
        }
    }
}
