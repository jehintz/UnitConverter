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
    public sealed partial class SpeedConverter : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();
        private string toSpeed = null;
        private string fromSpeed = null;
        private float numberToConvert = 0F;
        internal SharedMethods m = new SharedMethods();

        public SpeedConverter()
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

        private void speedEntryBox_LostFocus(object sender, RoutedEventArgs e)
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
                speedAnswerDisplay.Text = "";
            }
            //If there is input and it is valid, perform a conversion.
            else
            {
                errorDisplay.Text = "";
                speedAnswerDisplay.Text = ConvertSpeed(fromSpeed, toSpeed, numberToConvert);
            }
        }

        internal static string ConvertSpeed(string from, string to, float input)
        {
            string answer;
            float convertedValue = 0.0F;
            string abbreviatedFromUnit;
            string abbreviatedToUnit;
            SharedMethods sm = new SharedMethods();

            if (from != null && to != null)
            {
                if (from != null && to != null)
                {
                    #region Convert from MPH
                    if (from.Trim() == "Miles/Hour")
                    {
                        if (to.Trim() == "Kilometers/Hour")
                        {
                            convertedValue = input * 1.60934F;
                            goto Answered;
                        }
                        else if (to.Trim() == "Feet/Second")
                        {
                            convertedValue = input * 1.46667F;
                            goto Answered;
                        }
                        else if (to.Trim() == "Meters/Second")
                        {
                            convertedValue = input * 0.44704F;
                            goto Answered;
                        }
                        else
                        {
                            convertedValue = input;
                            goto Answered;
                        }
                    }
                    #endregion

                    #region Convert from KPH
                    if (from.Trim() == "Kilometers/Hour")
                    {
                        if (to.Trim() == "Miles/Hour")
                        {
                            convertedValue = input * 0.621371F;
                            goto Answered;
                        }
                        else if (to.Trim() == "Feet/Second")
                        {
                            convertedValue = input * 0.911344F;
                            goto Answered;
                        }
                        else if (to.Trim() == "Meters/Second")
                        {
                            convertedValue = input * 0.277778F;
                            goto Answered;
                        }
                        else
                        {
                            convertedValue = input;
                            goto Answered;
                        }
                    }
                    #endregion

                    #region Convert from FPS
                    if (from.Trim() == "Feet/Second")
                    {
                        if (to.Trim() == "Miles/Hour")
                        {
                            convertedValue = input * 0.681818F;
                            goto Answered;
                        }
                        else if (to.Trim() == "Kilometers/Hour")
                        {
                            convertedValue = input * 1.09728F;
                            goto Answered;
                        }
                        else if (to.Trim() == "Meters/Second")
                        {
                            convertedValue = input * 0.3048F;
                            goto Answered;
                        }
                        else
                        {
                            convertedValue = input;
                            goto Answered;
                        }
                    }
                    #endregion

                    #region Convert from MPS
                    if (from.Trim() == "Meters/Second")
                    {
                        if (to.Trim() == "Miles/Hour")
                        {
                            convertedValue = input * 2.23694F;
                            goto Answered;
                        }
                        else if (to.Trim() == "Kilometers/Hour")
                        {
                            convertedValue = input * 3.6F;
                            goto Answered;
                        }
                        else if (to.Trim() == "Feet/Second")
                        {
                            convertedValue = input * 3.28084F;
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

        private void fromSpeedSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox fromComboBox = (ComboBox)sender;

            if (fromComboBox.SelectedIndex != -1)
            {
                fromSpeed = ((ComboBoxItem)fromComboBox.SelectedItem).Content.ToString();
                speedAnswerDisplay.Text = ConvertSpeed(fromSpeed, toSpeed, numberToConvert);
            }
        }

        private void toSpeedSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox toComboBox = (ComboBox)sender;

            if (toComboBox.SelectedIndex != -1)
            {
                toSpeed = ((ComboBoxItem)toComboBox.SelectedItem).Content.ToString();
                speedAnswerDisplay.Text = ConvertSpeed(fromSpeed, toSpeed, numberToConvert);
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            speedEntryBox.Text = "0";
            toSpeedSelector.SelectedIndex = -1;
            fromSpeedSelector.SelectedIndex = -1;
            speedAnswerDisplay.Text = "";
            fromSpeed = null;
            toSpeed = null;
            numberToConvert = 0F;
        }

        private void speedEntryBox_GotFocus(object sender, RoutedEventArgs e)
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
