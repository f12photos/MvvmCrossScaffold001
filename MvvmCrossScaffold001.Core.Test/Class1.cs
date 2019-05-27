using System;
using MvvmCrossScaffold001.Core.Services;
using NUnit.Framework;

namespace MvvmCrossScaffold001.Core.Test
{
    [TestFixture]
    public class TipServiceTests
    {
        [Test]
        public void TestThatZeroGenerosityReturnsZeroTip()
        {
            // Arrange
            var tip = new CalculationService();

            // Act
            var result = tip.TipAmount(42.35, 0);

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void TestThatTenGenerosityReturnsTenPercentTip()
        {
            // Arrange
            var tip = new CalculationService();

            // Act
            var result = tip.TipAmount(42.35, 10);

            // Assert
            Assert.AreEqual(4.235, result);
        }
    }
}
