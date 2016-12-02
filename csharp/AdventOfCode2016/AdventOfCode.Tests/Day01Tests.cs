using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests
{
    [TestClass]
    public class Day01Tests
    {
        [TestMethod]
        public void R2_L3_Has_Correct_Position()
        {
            const string input = "R2, L3";
            var expected = new Position { X = 2, Y = 3 };

            Day01.Solve(input);
            Position actual = Day01.Position;

            Assert.AreEqual(expected.X, actual.X);
            Assert.AreEqual(expected.Y, actual.Y);
        }

        [TestMethod]
        public void R2_L3_Returns_5()
        {
            const string input = "R2, L3";
            const int expected = 5;

            int actual = Day01.Solve(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void R2_R2_R2_Returns_2()
        {
            const string input = "R2, R2, R2";
            const int expected = 2;

            int actual = Day01.Solve(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void R5_L5_R5_R3_Returns_12()
        {
            const string input = "R5, L5, R5, R3";
            const int expected = 12;

            int actual = Day01.Solve(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void L2_L2_Returns_4_Negative_Coordinate()
        {
            const string input = "L2, L2";
            const int expected = 4;

            int actual = Day01.Solve(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
