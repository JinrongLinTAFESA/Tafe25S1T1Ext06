using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class CurrencyConverter : Page
    {	
		public CurrencyConverter()
        {
            this.InitializeComponent();
        }

		private double GetConversionRate(string fromCurrency, string toCurrency)
		{
			double currencyRate = -1;

			if (fromCurrency == "USD" && toCurrency == "EUR") currencyRate = 0.85189982;
			if (fromCurrency == "USD" && toCurrency == "GBP") currencyRate = 0.72872436;
			if (fromCurrency == "USD" && toCurrency == "INR") currencyRate = 74.257327;

			if (fromCurrency == "EUR" && toCurrency == "USD") currencyRate = 1.1739732;
			if (fromCurrency == "EUR" && toCurrency == "GBP") currencyRate = 0.8556672;
			if (fromCurrency == "EUR" && toCurrency == "INR") currencyRate = 87.00755;

			if (fromCurrency == "GBP" && toCurrency == "USD") currencyRate = 1.371907;
			if (fromCurrency == "GBP" && toCurrency == "EUR") currencyRate = 1.1686692;
			if (fromCurrency == "GBP" && toCurrency == "INR") currencyRate = 101.68635;

			if (fromCurrency == "INR" && toCurrency == "USD") currencyRate = 0.011492628;
			if (fromCurrency == "INR" && toCurrency == "EUR") currencyRate = 0.013492774;
			if (fromCurrency == "INR" && toCurrency == "GBP") currencyRate = 0.0098339397;

			return currencyRate;
		}



		private void lblResult_SelectionChanged(object sender, RoutedEventArgs e)
		{

		}

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MainWindow));
		}

		private void convertButton_Click(object sender, RoutedEventArgs e)
		{
			double amount;
			if (!double.TryParse(amountTextBox.Text, out amount))
			{
				resultTextBox.Text = "Error: Please enter a valid number for amount.";
				return;
			}

			ComboBoxItem fromItem = (ComboBoxItem)frCurrencyComboBox.SelectedItem;
			ComboBoxItem toItem = (ComboBoxItem)toCurrencyComboBox.SelectedItem;
			string fromCurrency = fromItem.Content.ToString();
			string toCurrency = toItem.Content.ToString();

			double currencyRate = GetConversionRate(fromCurrency, toCurrency);
			if (currencyRate == -1)
			{
				resultTextBox.Text = "Error: Invalid currency conversion request.";
				return;
			}

			double convertedAmount = amount * currencyRate;
			resultTextBox.Text = $"{amount} {fromCurrency} = {convertedAmount:F2} {toCurrency}";
		}
	}
}
