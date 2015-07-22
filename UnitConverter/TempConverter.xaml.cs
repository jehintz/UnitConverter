using UnitConverter.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace UnitConverter
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TempConverter : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();
        private string toTemp = null;
        private string fromTemp = null;
        private float numberToConvert = 0F;
        internal SharedMethods m = new SharedMethods();

        public TempConverter()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
        }

        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void tempEntryBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox.Text.Length <= 0)
            {
                textBox.Text = "0";
                errorDisplay.Text = "";
            }

            //If the input is not a valid float-type number, show an error message.
            if (!float.TryParse(textBox.Text, out numberToConvert))
            {
                errorDisplay.Text = "Please enter a valid number.";
                tempAnswerDisplay.Text = "";
            }
            //If there is input and it is valid, perform a conversion.
            else
            {
                errorDisplay.Text = "";
                tempAnswerDisplay.Text = ConvertTemp(fromTemp, toTemp, numberToConvert);
            }
        }

        internal static string ConvertTemp(string from, string to, float input)
        {
            string answer;
            float convertedValue = 0.0F;
            string abbreviatedFromUnit;
            string abbreviatedToUnit;
            SharedMethods sm = new SharedMethods();

            if (from != null && to != null)
            {
                #region Convert from Fahrenheit
                if (from.Trim() == "Fahrenheit")
                {
                    if (to.Trim() == "Celsius")
                    {
                        convertedValue = (input - 32F) * 0.555555F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Kelvin")
                    {
                        convertedValue = (input + 459.67F) * 0.555555F;
                        goto Answered;
                    }
                    else
                    {
                        convertedValue = input;
                        goto Answered;
                    }
                }
                #endregion

                #region Convert from Celsius
                if (from.Trim() == "Celsius")
                {
                    if (to.Trim() == "Fahrenheit")
                    {
                        convertedValue = input * 1.8F + 32F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Kelvin")
                    {
                        convertedValue = input + 273.15F;
                        goto Answered;
                    }
                    else
                    {
                        convertedValue = input;
                        goto Answered;
                    }
                }
                #endregion

                #region Convert from Kelvin
                if (from.Trim() == "Kelvin")
                {
                    if (to.Trim() == "Fahrenheit")
                    {
                        convertedValue = input * 1.8F - 459.67F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Celsius")
                    {
                        convertedValue = input - 273.15F;
                        goto Answered;
                    }
                    else
                    {
                        convertedValue = input;
                        goto Answered;
                    }
                }
                #endregion
            }
            else
            {
                return "";
            }

            Answered:
            ShortenUnitsForDisplay abbreviateFrom = new ShortenUnitsForDisplay(from);
            ShortenUnitsForDisplay abbreviateTo = new ShortenUnitsForDisplay(to);
            abbreviatedFromUnit = abbreviateFrom.ToString();
            abbreviatedToUnit = abbreviateTo.ToString();
            string fromAnswerForDisplay, toAnswerForDisplay;
            sm.RemoveTrailingZeros(input, convertedValue, out fromAnswerForDisplay, out toAnswerForDisplay);
            answer = System.String.Format("{0} {1}\n  =\n{2} {3}", fromAnswerForDisplay, abbreviatedFromUnit, toAnswerForDisplay, abbreviatedToUnit);
            return answer;
        }

        private void fromTempSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox fromComboBox = (ComboBox)sender;

            if (fromComboBox.SelectedIndex != -1)
            {
                fromTemp = ((ComboBoxItem)fromComboBox.SelectedItem).Content.ToString();
                tempAnswerDisplay.Text = ConvertTemp(fromTemp, toTemp, numberToConvert);
            }
        }

        private void toTempSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox toComboBox = (ComboBox)sender;

            if (toComboBox.SelectedIndex != -1)
            {
                toTemp = ((ComboBoxItem)toComboBox.SelectedItem).Content.ToString();
                tempAnswerDisplay.Text = ConvertTemp(fromTemp, toTemp, numberToConvert);
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            tempEntryBox.Text = "0";
            toTempSelector.SelectedIndex = -1;
            fromTempSelector.SelectedIndex = -1;
            tempAnswerDisplay.Text = "";
            fromTemp = null;
            toTemp = null;
            numberToConvert = 0F;
        }

        private void tempEntryBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox.Text == "0")
            {
                textBox.Text = "";
            }
            else
            {
                textBox.SelectAll();
            }
        }

    }
}
