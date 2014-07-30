using InterestCalculator;
using NUnit.Framework;

namespace InterestCalculatorTest{
    [TestFixture]
    public static class InterestTest{
        private const decimal LoanAmount = 500000;
        private const decimal LoanInterestRate = 0.04m;

        [Test]
        public static void CalculateYearlyInterestCost(){
            Assert.AreEqual(14000, Interest.CalculateYearlyInterestCost(LoanAmount, LoanInterestRate));
        }

        [Test]
        public static void CalculateMonthlyInterestCost(){
            Assert.AreEqual(1167, Interest.CalculateMonthlyInterestCost(LoanAmount, LoanInterestRate));
        }

        [Test]
        public static void CalculateYearlyLoanCost(){
            Assert.AreEqual(514000, Interest.CalculateYearlyLoanCost(LoanAmount, LoanInterestRate));
        }
    }
}