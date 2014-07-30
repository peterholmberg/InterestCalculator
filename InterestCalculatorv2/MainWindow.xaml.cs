using System;
using System.Collections.Generic;
using System.Windows;

namespace InterestCalculator{
    public partial class MainWindow{
        private IEnumerable<decimal> CalculateYearlyCost{
            get{
                return Interest.CalculateYearlyCost(loanAmountSlider.Value, loanInterestRate.Value,
                                                    amortizationSlider.Value);
            }
        }

        private IEnumerable<decimal> CalculateDecreaseCost{
            get{
                return Interest.CalculatedMonthlyDecrease(loanAmountSlider.Value, loanInterestRate.Value,
                                                          amortizationSlider.Value);
            }
        }

        public MainWindow(){
            InitializeComponent();
            initializeEventHandlers();
            SetDefaultValues();
        }

        private void AmortizationSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e){
            amortizationLabel.Content = string.Format("Amortering: {0}", Convert.ToInt32(amortizationSlider.Value));
            PrintContentToTextBoxes();
        }

        private void LoanAmountSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e){
            loanLabel.Content = string.Format("Lån: {0}", Convert.ToInt32(loanAmountSlider.Value));
            PrintContentToTextBoxes();
        }

        private void MonthlyFeeSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e){
            monthlyFeeLabel.Content = string.Format("Avgift: {0}", Convert.ToInt32(monthlyFeeSlider.Value));
            PrintContentToTextBoxes();
        }

        private void LoanInterestRateValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e){
            PrintContentToTextBoxes();
        }

        private void PrintContentToTextBoxes(){
            perYearTextBox.Clear();
            perMonthTextBox.Clear();

            var yearCounter = 1;
            var monthCounter = 1;

            if (amortizationSlider.Value == 0)
                perYearTextBox.AppendText(string.Format("Lån: {0} kr", loanAmountSlider.Value));
            else{
                foreach (var year in CalculateYearlyCost){
                    perYearTextBox.AppendText(string.Format("År {0}: {1} kr\n", yearCounter, year));
                    yearCounter++;
                }
            }

            foreach (var month in CalculateDecreaseCost){
                perMonthTextBox.AppendText(string.Format("Månad {0}: {1} kr\n", monthCounter,
                                                         month + (decimal) monthlyFeeSlider.Value +
                                                         (decimal) amortizationSlider.Value));
                monthCounter++;
            }
        }

        private void initializeEventHandlers(){
            loanInterestRate.ValueChanged += LoanInterestRateValueChanged;
            loanAmountSlider.ValueChanged += LoanAmountSliderValueChanged;
            amortizationSlider.ValueChanged += AmortizationSliderValueChanged;
            monthlyFeeSlider.ValueChanged += MonthlyFeeSliderValueChanged;
            loanInterestRate.ValueChanged += LoanInterestRateValueChanged;
        }

        private void SetDefaultValues(){
            amortizationLabel.Content = string.Format("Amortering: {0}", Convert.ToInt32(amortizationSlider.Value));
            loanLabel.Content = string.Format("Lån: {0}", Convert.ToInt32(loanAmountSlider.Value));
            monthlyFeeLabel.Content = string.Format("Avgift: {0}", Convert.ToInt32(monthlyFeeSlider.Value));
            loanInterestRate.Value = 0.04m;
        }
    }
}