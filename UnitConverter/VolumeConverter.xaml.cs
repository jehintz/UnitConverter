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
    public sealed partial class VolumeConverter : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();
        private string toVolume = null;
        private string fromVolume = null;
        private float numberToConvert = 0F;
        internal SharedMethods m = new SharedMethods();

        public VolumeConverter()
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

        //If no input is provided, set user provided volume to 0.
        private void volumeEntryBox_LostFocus(object sender, RoutedEventArgs e)
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
                volumeAnswerDisplay.Text = "";
            }
            //If there is input and it is valid, perform a conversion.
            else
            {
                errorDisplay.Text = "";
                volumeAnswerDisplay.Text = ConvertVolume(fromVolume, toVolume, numberToConvert);
            }
        }

        internal static string ConvertVolume(string from, string to, float input)
        {
            string answer;
            float convertedValue = 0.0F;
            string abbreviatedFromUnit;
            string abbreviatedToUnit;
            SharedMethods sm = new SharedMethods();

            if (from != null && to != null)
            {
                #region Convert from Cups
                //from cups
                if (from.Trim() == "Cups")
                {
                    if (to.Trim() == "Fluid Ounces")
                    {
                        convertedValue = input * 8F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Gallons")
                    {
                        convertedValue = input * 0.0625F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Liters")
                    {
                        convertedValue = input * 0.236588F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Milliliters")
                    {
                        convertedValue = input * 236.588F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Pints")
                    {
                        convertedValue = input * 0.5F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Quarts")
                    {
                        convertedValue = input * 0.25F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Tablespoons")
                    {
                        convertedValue = input * 16F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Teaspoons")
                    {
                        convertedValue = input * 48F;
                        goto Answered;
                    }
                    else
                    {
                        convertedValue = input;
                        goto Answered;
                    }
                }
            #endregion

                #region Convert from Fluid Ounces
                //from fluid ounces
                if (from.Trim() == "Fluid Ounces")
                {
                    if (to.Trim() == "Cups")
                    {
                        convertedValue = input * 0.125F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Gallons")
                    {
                        convertedValue = input * 0.0078125F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Liters")
                    {
                        convertedValue = input * 0.0295735F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Milliliters")
                    {
                        convertedValue = input * 29.5735F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Pints")
                    {
                        convertedValue = input * 0.0625F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Quarts")
                    {
                        convertedValue = input * 0.03125F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Tablespoons")
                    {
                        convertedValue = input * 2F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Teaspoons")
                    {
                        convertedValue = input * 6F;
                        goto Answered;
                    }
                    else
                    {
                        convertedValue = input;
                        goto Answered;
                    }
                }
                #endregion

                #region Convert from Gallons
                //from gallons
                if (from.Trim() == "Gallons")
                {
                    if (to.Trim() == "Cups")
                    {
                        convertedValue = input * 16F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Fluid Ounces")
                    {
                        convertedValue = input * 128F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Liters")
                    {
                        convertedValue = input * 3.78541F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Milliliters")
                    {
                        convertedValue = input * 3785.41F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Pints")
                    {
                        convertedValue = input * 8F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Quarts")
                    {
                        convertedValue = input * 4F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Tablespoons")
                    {
                        convertedValue = input * 256F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Teaspoons")
                    {
                        convertedValue = input * 768F;
                        goto Answered;
                    }
                    else
                    {
                        convertedValue = input;
                        goto Answered;
                    }
                }
                #endregion

                #region Convert from Liters
                //from liters
                if (from.Trim() == "Liters")
                {
                    if (to.Trim() == "Cups")
                    {
                        convertedValue = input * 4.22675F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Fluid Ounces")
                    {
                        convertedValue = input * 33.814F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Gallons")
                    {
                        convertedValue = input * 0.264172F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Milliliters")
                    {
                        convertedValue = input * 1000F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Pints")
                    {
                        convertedValue = input * 2.11338F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Quarts")
                    {
                        convertedValue = input * 1.05669F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Tablespoons")
                    {
                        convertedValue = input * 67.628F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Teaspoons")
                    {
                        convertedValue = input * 202.884F;
                        goto Answered;
                    }
                    else
                    {
                        convertedValue = input;
                        goto Answered;
                    }
                }
                #endregion

                #region Convert from Milliliters
                //from milliliters
                if (from.Trim() == "Milliliters")
                {
                    if (to.Trim() == "Cups")
                    {
                        convertedValue = input * 0.00422675F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Fluid Ounces")
                    {
                        convertedValue = input * 0.033814F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Gallons")
                    {
                        convertedValue = input * 0.000264172F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Liters")
                    {
                        convertedValue = input * 0.001F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Pints")
                    {
                        convertedValue = input * 0.00211338F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Quarts")
                    {
                        convertedValue = input * 0.00105669F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Tablespoons")
                    {
                        convertedValue = input * 0.067628F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Teaspoons")
                    {
                        convertedValue = input * 0.202884F;
                        goto Answered;
                    }
                    else
                    {
                        convertedValue = input;
                        goto Answered;
                    }
                }
                #endregion

                #region Convert from Pints
                if (from.Trim() == "Pints")
                {
                    if (to.Trim() == "Cups")
                    {
                        convertedValue = input * 2F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Fluid Ounces")
                    {
                        convertedValue = input * 16F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Gallons")
                    {
                        convertedValue = input * 0.125F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Liters")
                    {
                        convertedValue = input * 0.473176F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Milliliters")
                    {
                        convertedValue = input * 473.176F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Quarts")
                    {
                        convertedValue = input * 0.5F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Tablespoons")
                    {
                        convertedValue = input * 32F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Teaspoons")
                    {
                        convertedValue = input * 96F;
                        goto Answered;
                    }
                    else
                    {
                        convertedValue = input;
                        goto Answered;
                    }
                }
                #endregion

                #region Convert from Quarts
                if (from.Trim() == "Quarts")
                {
                    if (to.Trim() == "Cups")
                    {
                        convertedValue = input * 4F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Fluid Ounces")
                    {
                        convertedValue = input * 32F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Gallons")
                    {
                        convertedValue = input * 0.25F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Liters")
                    {
                        convertedValue = input * 0.946353F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Milliliters")
                    {
                        convertedValue = input * 946.353F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Pints")
                    {
                        convertedValue = input * 2F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Tablespoons")
                    {
                        convertedValue = input * 64F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Teaspoons")
                    {
                        convertedValue = input * 192F;
                        goto Answered;
                    }
                    else
                    {
                        convertedValue = input;
                        goto Answered;
                    }
                }
                #endregion

                #region Convert from Tablespoons
                if (from.Trim() == "Tablespoons")
                {
                    if (to.Trim() == "Cups")
                    {
                        convertedValue = input * 0.0625F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Fluid Ounces")
                    {
                        convertedValue = input * 0.5F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Gallons")
                    {
                        convertedValue = input * 0.00390625F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Liters")
                    {
                        convertedValue = input * 0.0147868F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Milliliters")
                    {
                        convertedValue = input * 14.7868F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Pints")
                    {
                        convertedValue = input * 0.03125F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Quarts")
                    {
                        convertedValue = input * 0.015625F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Teaspoons")
                    {
                        convertedValue = input * 3F;
                        goto Answered;
                    }
                    else
                    {
                        convertedValue = input;
                        goto Answered;
                    }
                }
                #endregion

                #region Convert from Teaspoons
                if (from.Trim() == "Teaspoons")
                {
                    if (to.Trim() == "Cups")
                    {
                        convertedValue = input * 0.0208333F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Fluid Ounces")
                    {
                        convertedValue = input * 0.5F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Gallons")
                    {
                        convertedValue = input * 0.00130208F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Liters")
                    {
                        convertedValue = input * 0.00492892F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Milliliters")
                    {
                        convertedValue = input * 4.92892F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Pints")
                    {
                        convertedValue = input * 0.0104167F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Quarts")
                    {
                        convertedValue = input * 0.00520833F;
                        goto Answered;
                    }
                    else if (to.Trim() == "Tablespoons")
                    {
                        convertedValue = input * 0.333333F;
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

        private void fromVolumeSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox fromComboBox = (ComboBox)sender;

            if (fromComboBox.SelectedIndex != -1)
            {
                fromVolume = ((ComboBoxItem)fromComboBox.SelectedItem).Content.ToString();
                volumeAnswerDisplay.Text = ConvertVolume(fromVolume, toVolume, numberToConvert);
            }
        }

        private void toVolumeSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox toComboBox = (ComboBox)sender;

            if (toComboBox.SelectedIndex != -1)
            {
                toVolume = ((ComboBoxItem)toComboBox.SelectedItem).Content.ToString();
                volumeAnswerDisplay.Text = ConvertVolume(fromVolume, toVolume, numberToConvert);
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            volumeEntryBox.Text = "0";
            toVolumeSelector.SelectedIndex = -1;
            fromVolumeSelector.SelectedIndex = -1;
            volumeAnswerDisplay.Text = "";
            fromVolume = null;
            toVolume = null;
            numberToConvert = 0F;
        }

        private void volumeEntryBox_GotFocus(object sender, RoutedEventArgs e)
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
