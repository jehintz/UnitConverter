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

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace UnitConverter
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WeightConverter : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();
        private string toWeight = null;
        private string fromWeight = null;
        private float numberToConvert = 0F;
        internal SharedMethods m = new SharedMethods();

        public WeightConverter()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
        }

        /// <summary>
        /// Gets the <see cref="NavigationHelper"/> associated with this <see cref="Page"/>.
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        /// <summary>
        /// Gets the view model for this <see cref="Page"/>.
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session.  The state will be null the first time a page is visited.</param>
        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper registration

        /// <summary>
        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// <para>
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="NavigationHelper.LoadState"/>
        /// and <see cref="NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.
        /// </para>
        /// </summary>
        /// <param name="e">Provides data for navigation methods and event
        /// handlers that cannot cancel the navigation request.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        //Upon the keyboard being closed when a change is made to the entry box...
        private void weightEntryBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            //If there is no input, default to "0".
            if (textBox.Text.Length <= 0)
            {
                textBox.Text = "0";
                errorDisplay.Text = "";
            }

            //If the input is not a valid float-type number, show an error message.
            if (!float.TryParse(textBox.Text, out numberToConvert))
            {
                errorDisplay.Text = "Please enter a valid number.";
                weightAnswerDisplay.Text = "";
            }
            //If there is input and it is valid, perform a conversion.
            else
            {
                errorDisplay.Text = "";
                weightAnswerDisplay.Text = ConvertWeight(fromWeight, toWeight, numberToConvert);
            }
        }

        //When a unit is selected on the "from" side, try to perform a conversion.
        private void fromWeightSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox fromComboBox = (ComboBox)sender;

            if (fromComboBox.SelectedIndex != -1)
            {
                fromWeight = ((ComboBoxItem)fromComboBox.SelectedItem).Content.ToString();
                weightAnswerDisplay.Text = ConvertWeight(fromWeight, toWeight, numberToConvert);
            }
        }

        //When the unit is selected on the "to" side, try to perform a conversion.
        private void toWeightSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox toComboBox = (ComboBox)sender;

            if (toComboBox.SelectedIndex != -1)
            {
                toWeight = ((ComboBoxItem)toComboBox.SelectedItem).Content.ToString();
                weightAnswerDisplay.Text = ConvertWeight(fromWeight, toWeight, numberToConvert);
            }
        }

        //Math for the conversions.
        internal static string ConvertWeight(string from, string to, float input)
        {
            string answer;
            float convertedValue = 0.0F;
            string abbreviatedFromUnit;
            string abbreviatedToUnit;
            SharedMethods sm = new SharedMethods();

            //If both a From and To unit have been selected, convert the value in the textbox and display the result.
            if (from != null && to != null)
            {
                //From pounds.
                if (from.Trim() == "Pounds")
                {
                    if (to.Trim() == "Kilograms")
                    {
                        convertedValue = input * 0.453592F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Tons")
                    {
                        convertedValue = input * 0.0005F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Grams")
                    {
                        convertedValue = input * 453.592F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Milligrams")
                    {
                        convertedValue = input * 453592F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Ounces")
                    {
                        convertedValue = input * 16F;
                        goto Answered;
                    }
                    else
                    {
                        convertedValue = input;
                        goto Answered;
                    }
                }
                //From kilograms.
                else if (from.Trim() == "Kilograms")
                {
                    if (to.Trim() == "Pounds")
                    {
                        convertedValue = input * 2.20462F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Tons")
                    {
                        convertedValue = input * 0.00110231F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Grams")
                    {
                        convertedValue = input * 1000F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Milligrams")
                    {
                        convertedValue = input * 1000000F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Ounces")
                    {
                        convertedValue = input * 35.274F;
                        goto Answered;
                    }
                    else
                    {
                        convertedValue = input;
                        goto Answered;
                    }
                }
                //From tons.
                else if (from.Trim() == "Tons")
                {
                    if (to.Trim() == "Pounds")
                    {
                        convertedValue = input * 2000F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Kilograms")
                    {
                        convertedValue = input * 907.185F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Grams")
                    {
                        convertedValue = input * 907185F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Milligrams")
                    {
                        convertedValue = input * 907200000F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Ounces")
                    {
                        convertedValue = input * 32000F;
                        goto Answered;
                    }
                    else
                    {
                        convertedValue = input;
                        goto Answered;
                    }

                }
                //From grams.
                else if (from.Trim() == "Grams")
                {
                    if (to.Trim() == "Pounds")
                    {
                        convertedValue = input * 0.00220462F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Kilograms")
                    {
                        convertedValue = input * 0.001F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Tons")
                    {
                        convertedValue = input * .0000011023F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Milligrams")
                    {
                        convertedValue = input * 1000F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Ounces")
                    {
                        convertedValue = input * 0.035274F;
                        goto Answered;
                    }
                    else
                    {
                        convertedValue = input;
                        goto Answered;
                    }
                }
                //From milligrams.
                else if (from.Trim() == "Milligrams")
                {
                    if (to.Trim() == "Pounds")
                    {
                        convertedValue = input * .0000022046F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Kilograms")
                    {
                        convertedValue = input * .000001F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Tons")
                    {
                        convertedValue = input * .0000000011023F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Grams")
                    {
                        convertedValue = input * .001F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Ounces")
                    {
                        convertedValue = input * .000035274F;
                        goto Answered;
                    }
                    else
                    {
                        convertedValue = input;
                        goto Answered;
                    }
                }
                //From ounces.
                else if (from.Trim() == "Ounces")
                {
                    if (to.Trim() == "Pounds")
                    {
                        convertedValue = input * .0625F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Kilograms")
                    {
                        convertedValue = input * .0283495F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Tons")
                    {
                        convertedValue = input * .00003125F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Milligrams")
                    {
                        convertedValue = input * 28349.5F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Grams")
                    {
                        convertedValue = input * 28.3495F;
                        goto Answered;
                    }
                    else
                    {
                        convertedValue = input;
                        goto Answered;
                    }
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

        //Reset all fields, if requested by user.
        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            weightEntryBox.Text = "0";
            toWeightSelector.SelectedIndex = -1;
            fromWeightSelector.SelectedIndex = -1;
            weightAnswerDisplay.Text = "";
            fromWeight = null;
            toWeight = null;
            numberToConvert = 0F;
        }

        //When unit entry box is selected, highlight any previously entered text.
        private void weightEntryBox_GotFocus(object sender, RoutedEventArgs e)
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
            if (fromWeightSelector.SelectedIndex >= 0 && toWeightSelector.SelectedIndex >= 0)
            {
                int fromSelectedIndex = fromWeightSelector.SelectedIndex;
                int toSelectedIndex = toWeightSelector.SelectedIndex;

                fromWeightSelector.SelectedIndex = toSelectedIndex;
                toWeightSelector.SelectedIndex = fromSelectedIndex;
            }
        }
    }
}
