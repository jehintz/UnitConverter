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
    public sealed partial class LengthConverter : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();
        private string toLength = null;
        private string fromLength = null;
        private float numberToConvert = 0F;
        internal SharedMethods m = new SharedMethods();

        public LengthConverter()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
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

        private void lengthEntryBox_LostFocus(object sender, RoutedEventArgs e)
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
                lengthAnswerDisplay.Text = "";
            }
            //If there is input and it is valid, perform a conversion.
            else
            {
                errorDisplay.Text = "";
                lengthAnswerDisplay.Text = ConvertLength(fromLength, toLength, numberToConvert);
            }
        }

        internal static string ConvertLength(string from, string to, float input)
        {
            string answer;
            float convertedValue = 0.0F;
            string abbreviatedFromUnit;
            string abbreviatedToUnit;
            SharedMethods sm = new SharedMethods();

            if(from != null && to != null)
            {
                #region Convert from Centimeters
                if (from.Trim() == "Centimeters")
                {
                    if (to.Trim() == "Kilometers")
                    {
                        convertedValue = input * 0.00001F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Meters")
                    {
                        convertedValue = input * 0.01F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Millimeters")
                    {
                        convertedValue = input * 10F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Miles")
                    {
                        convertedValue = input * 0.0000062137F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Yards")
                    {
                        convertedValue = input * 0.0109361F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Feet")
                    {
                        convertedValue = input * 0.0328084F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Inches")
                    {
                        convertedValue = input * 0.393701F;
                        goto Answered;
                    }
                    else
                    {
                        convertedValue = input;
                        goto Answered;
                    }
                }
                #endregion

                #region Convert from Kilometers
                if (from.Trim() == "Kilometers")
                {
                    if (to.Trim() == "Centimeters")
                    {
                        convertedValue = input * 100000F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Meters")
                    {
                        convertedValue = input * 1000F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Millimeters")
                    {
                        convertedValue = input * 1000000F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Miles")
                    {
                        convertedValue = input * 0.621371F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Yards")
                    {
                        convertedValue = input * 1093.61F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Feet")
                    {
                        convertedValue = input * 3280.84F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Inches")
                    {
                        convertedValue = input * 39370.1F;
                        goto Answered;
                    }
                    else
                    {
                        convertedValue = input;
                        goto Answered;
                    }
                }
                #endregion

                #region Convert from Meters
                if (from.Trim() == "Meters")
                {
                    if (to.Trim() == "Centimeters")
                    {
                        convertedValue = input * 100F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Kilometers")
                    {
                        convertedValue = input * 0.001F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Millimeters")
                    {
                        convertedValue = input * 1000F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Miles")
                    {
                        convertedValue = input * 0.000621371F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Yards")
                    {
                        convertedValue = input * 1.09361F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Feet")
                    {
                        convertedValue = input * 3.28084F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Inches")
                    {
                        convertedValue = input * 39.3701F;
                        goto Answered;
                    }
                    else
                    {
                        convertedValue = input;
                        goto Answered;
                    }
                }
                #endregion

                #region Convert from Millimeters
                if (from.Trim() == "Millimeters")
                {
                    if (to.Trim() == "Centimeters")
                    {
                        convertedValue = input * 0.1F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Kilometers")
                    {
                        convertedValue = input * 0.000001F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Meters")
                    {
                        convertedValue = input * 0.001F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Miles")
                    {
                        convertedValue = input * 0.00000062137F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Yards")
                    {
                        convertedValue = input * 0.00109361F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Feet")
                    {
                        convertedValue = input * 0.00328084F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Inches")
                    {
                        convertedValue = input * 0.0393701F;
                        goto Answered;
                    }
                    else
                    {
                        convertedValue = input;
                        goto Answered;
                    }
                }
                #endregion

                #region Convert from Miles
                if (from.Trim() == "Miles")
                {
                    if (to.Trim() == "Centimeters")
                    {
                        convertedValue = input * 160934F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Kilometers")
                    {
                        convertedValue = input * 1.60934F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Meters")
                    {
                        convertedValue = input * 1609.34F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Millimeters")
                    {
                        convertedValue = input * 1609000F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Yards")
                    {
                        convertedValue = input * 1760F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Feet")
                    {
                        convertedValue = input * 5280F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Inches")
                    {
                        convertedValue = input * 63360F;
                        goto Answered;
                    }
                    else
                    {
                        convertedValue = input;
                        goto Answered;
                    }
                }
                #endregion

                #region Convert from Yards
                if (from.Trim() == "Yards")
                {
                    if (to.Trim() == "Centimeters")
                    {
                        convertedValue = input * 91.44F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Kilometers")
                    {
                        convertedValue = input * 0.0009144F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Meters")
                    {
                        convertedValue = input * 0.9144F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Millimeters")
                    {
                        convertedValue = input * 914.4F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Miles")
                    {
                        convertedValue = input * 0.000568182F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Feet")
                    {
                        convertedValue = input * 3F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Inches")
                    {
                        convertedValue = input * 36F;
                        goto Answered;
                    }
                    else
                    {
                        convertedValue = input;
                        goto Answered;
                    }
                }
                #endregion

                #region Convert from Feet
                if (from.Trim() == "Feet")
                {
                    if (to.Trim() == "Centimeters")
                    {
                        convertedValue = input * 30.48F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Kilometers")
                    {
                        convertedValue = input * 0.0003048F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Meters")
                    {
                        convertedValue = input * 0.3048F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Millimeters")
                    {
                        convertedValue = input * 304.8F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Miles")
                    {
                        convertedValue = input * 0.000189394F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Yards")
                    {
                        convertedValue = input * 0.333333F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Inches")
                    {
                        convertedValue = input * 12F;
                        goto Answered;
                    }
                    else
                    {
                        convertedValue = input;
                        goto Answered;
                    }
                }
                #endregion

                #region Convert from Inches
                if (from.Trim() == "Inches")
                {
                    if (to.Trim() == "Centimeters")
                    {
                        convertedValue = input * 2.54F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Kilometers")
                    {
                        convertedValue = input * 0.0000254F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Meters")
                    {
                        convertedValue = input * 0.0254F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Millimeters")
                    {
                        convertedValue = input * 25.4F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Miles")
                    {
                        convertedValue = input * 0.000015783F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Yards")
                    {
                        convertedValue = input * 0.0277778F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Feet")
                    {
                        convertedValue = input * 0.0833333F;
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

        private void fromLengthSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox fromComboBox = (ComboBox)sender;

            if (fromComboBox.SelectedIndex != -1)
            {
                fromLength = ((ComboBoxItem)fromComboBox.SelectedItem).Content.ToString();
                lengthAnswerDisplay.Text = ConvertLength(fromLength, toLength, numberToConvert);
            }
        }

        private void toLengthSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox toComboBox = (ComboBox)sender;

            if (toComboBox.SelectedIndex != -1)
            {
                toLength = ((ComboBoxItem)toComboBox.SelectedItem).Content.ToString();
                lengthAnswerDisplay.Text = ConvertLength(fromLength, toLength, numberToConvert);
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            lengthEntryBox.Text = "0";
            toLengthSelector.SelectedIndex = -1;
            fromLengthSelector.SelectedIndex = -1;
            lengthAnswerDisplay.Text = "";
            fromLength = null;
            toLength = null;
            numberToConvert = 0F;
        }

        private void lengthEntryBox_GotFocus(object sender, RoutedEventArgs e)
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

        private void switchButton_Click(object sender, RoutedEventArgs e)
        {
            if (fromLengthSelector.SelectedIndex >= 0 && toLengthSelector.SelectedIndex >= 0)
            {
                int fromSelectedIndex = fromLengthSelector.SelectedIndex;
                int toSelectedIndex = toLengthSelector.SelectedIndex;

                fromLengthSelector.SelectedIndex = toSelectedIndex;
                toLengthSelector.SelectedIndex = fromSelectedIndex;
            }
        }

    }
}
