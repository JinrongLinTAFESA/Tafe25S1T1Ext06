using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MortgageCalculator : Page
    {
        public MortgageCalculator()
        {
            this.InitializeComponent();
        }

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MainWindow));
		}

		private async void calculateButton_Click(object sender, RoutedEventArgs e)
		{

			double principalLoanAmount;
			int years;
			int months;
			double yearlyIntrestRate;
			double monthlyIntrestRate;
			double monthlyRepayment;

			try
			{
				principalLoanAmount = Math.Round(double.Parse(principalBorrowTextBox.Text), 2);
			}
			catch
			{
				var dialog = new MessageDialog("Error: Principal Borrow must have numbers");
				await dialog.ShowAsync();
				principalBorrowTextBox.Focus(FocusState.Programmatic);
				principalBorrowTextBox.SelectAll();
				return;
			}
			principalBorrowTextBox.Text = principalLoanAmount.ToString();

			try
			{
				years = int.Parse(yearsTextBox.Text);
			}
			catch
			{
				var dialog = new MessageDialog("Error: Years must be a whole number");
				await dialog.ShowAsync();
				yearsTextBox.Focus(FocusState.Programmatic);
				yearsTextBox.SelectAll();
				return;
			}

			if (string.IsNullOrWhiteSpace(monthsTextBox.Text))
			{
				monthsTextBox.Text = "0";
			}
			try
			{
				months = int.Parse(monthsTextBox.Text);
			}
			catch
			{
				var dialog = new MessageDialog("Error: Months must be a whole number");
				await dialog.ShowAsync();
				monthsTextBox.Focus(FocusState.Programmatic);
				monthsTextBox.SelectAll();
				return;
			}

			try
			{
				yearlyIntrestRate = double.Parse(yearlyIntrestRateTextBox.Text);
			}
			catch
			{
				var dialog = new MessageDialog("Error: Yearly Intrest Rate must have numbers");
				await dialog.ShowAsync();
				yearlyIntrestRateTextBox.Focus(FocusState.Programmatic);
				yearlyIntrestRateTextBox.SelectAll();
				return;
			}

			int totalMonths = (years * 12) + months;
			monthlyIntrestRate = (yearlyIntrestRate / 12)/100;

			monthlyIntrestRateTextBox.Text = monthlyIntrestRate.ToString("P");

			monthlyRepayment = principalLoanAmount * (monthlyIntrestRate * Math.Pow(1 + monthlyIntrestRate, totalMonths)) /
				(Math.Pow(1 + monthlyIntrestRate, totalMonths) - 1);

			monthlyRepaymentTextBox.Text = monthlyRepayment.ToString("C", new CultureInfo("en-AU"));
		}
	}
}
