using System;
using NUnit.Framework;

namespace InterestCalculatorTest{
    [TestFixture]
    public class InvestmentsTest{
        private const double Interest = 1.15;
        private const double Year = 16.00;
        private const double Futurevalue = 10000000.00;
        private const double Monthlyamount = 12000.00;
        private const double Months = 12.00;
        private const double Startvalue = 750000.00;

        [Test]
        public void PresentValue(){
            Assert.AreEqual(1068647.70, Investments.CalculatePresentValue(Interest, Year, Futurevalue));
        }

        [Test]
        public void AnnuitetValue(){
            Assert.AreEqual(115295373, Investments.CalculateAnnuitet(Monthlyamount, Interest, Year, Months));
        }

        [Test]
        public void FutureValue(){
            Assert.AreEqual(66804641, Investments.CalculateFutureValue(Interest, Year, Startvalue));
        }
    }

    public static class Investments{
        public static decimal CalculatePresentValue(double interest, double year, double futurevalue){
            var res = Math.Pow(interest, year);
            var result = futurevalue/res;
            return decimal.Round((decimal) result, 1);
        }

        public static decimal CalculateAnnuitet(double monthlyAmount, double interest, double year, double months){
            var interestPerMonth = interest/12;
            var numberOfMonths = year*months;
            var interestPerNumberOfMonths = interestPerMonth/numberOfMonths;
            var l = monthlyAmount*interestPerMonth;
            var result = Math.Pow(l, interestPerNumberOfMonths);
            return (decimal) result;
        }

        public static decimal CalculateFutureValue(double interest, double year, double startvalue){
            var res = Math.Pow(interest, year);
            var result = startvalue*res;

            return (decimal) result;
        }

        //=Månadsspar.*(((((1+(Avkastning./12))^(År.*Perioder))-1))/(Avkastning./12))
    }
}