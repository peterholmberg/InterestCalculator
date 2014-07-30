using System.Collections.Generic;

namespace InterestCalculator {
    public static class Interest {
        private static decimal _loan;
        private static decimal _interestRate;
        private static decimal _amortization;

        public static decimal CalculateMonthlyInterestCost(decimal loanAmount, decimal loanInterestRate) {
            var result = ((CalculateYearlyInterestCost(loanAmount, loanInterestRate)) / 12);
            return decimal.Round(result, 0);
        }

        public static decimal CalculateYearlyInterestCost(decimal loanAmount, decimal loanInterestRate) {
            var result = (loanAmount * loanInterestRate) * 0.7m;
            return decimal.Round(result, 0);
        }

        public static decimal CalculateYearlyLoanCost(decimal loan, decimal interestRate) {
            loan += (CalculateYearlyInterestCost(loan, interestRate));
            return loan;
        }

        public static IEnumerable<decimal> CalculatedMonthlyDecrease(double loanAmount, decimal? loanAmountInterestRate,
                                                                     double amortizationAmount) {
            if (loanAmountInterestRate != null)
                _interestRate = (decimal)loanAmountInterestRate;
            else
                _interestRate = 1.00m;

            _loan = (decimal)loanAmount;
            _amortization = (decimal)amortizationAmount;
            var monthlyDecreaseList = new List<decimal>();

            for (var i = 1; i <= 12; i++) {
                monthlyDecreaseList.Add(CalculateMonthlyInterestCost(_loan, _interestRate));
                _loan -= _amortization;
            }

            return monthlyDecreaseList;
        }

        public static IEnumerable<decimal> CalculateYearlyCost(double loanAmount, decimal? loanAmountInterestRate,
                                                               double amortizationAmount) {
            if (loanAmountInterestRate != null)
                _interestRate = (decimal)loanAmountInterestRate;
            else
                _interestRate = 1.00m;

            _loan = (decimal)loanAmount;
            _amortization = (decimal)amortizationAmount;
            var yearlyDecreaseList = new List<decimal>();

            while (_loan > 0) {
                yearlyDecreaseList.Add(CalculateYearlyLoanCost(_loan, _interestRate));
                _loan -= (_amortization * 12);
            }

            return yearlyDecreaseList;
        }
    }
}