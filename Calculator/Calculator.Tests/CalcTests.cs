using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    [TestClass]
    public class CalcTests
    {
        [TestMethod]
        public void Calc_Sum_3_and_2_result_5()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            var result = calc.Sum(3, 2);

            //Assert
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Calc_Sum_0_and_0_result_0()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            var result = calc.Sum(0, 0);

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Calc_Sum_MAX_and_1_throws()
        {
            Calc calc = new Calc();

            Assert.ThrowsException<OverflowException>(() => calc.Sum(int.MaxValue, 1));
            Assert.ThrowsException<OverflowException>(() => calc.Sum(int.MinValue, -1));

        }
    }
}
