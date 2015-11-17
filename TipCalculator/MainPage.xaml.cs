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
using Windows.ApplicationModel.Email;
using Windows.System;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace TipCalculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Tip tip;


        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            tip = new Tip();

        }
        public ApplicationTheme RequestedTheme { get; set; }
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void amountTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            billAmountTextBox.Text = tip.BillAmount;
        }

        private void billAmountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            performCalculation();
        }

        private void amountTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            billAmountTextBox.Text = "";
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            performCalculation();
        }

        private void performCalculation()
        {
            var SelectedRadio = kStackPanel.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked == true);

            tip.CalculateTip(billAmountTextBox.Text, double.Parse(SelectedRadio.Tag.ToString()));

            amountToTipTextBlock.Text = tip.TipAmount;
            totalTextBlock.Text = tip.TotalAmount;
        }

        private async void EmailK_OnClick(object sender, RoutedEventArgs e)
        {
            var emailMessage = new EmailMessage();

            emailMessage.To.Add(new EmailRecipient("aaron@kshatriya.co.uk"));
            emailMessage.Subject = "Feedback";
            emailMessage.Body = "Please Provide your Feedback.";

            // call EmailManager to show the compose UI in the screen
            await EmailManager.ShowComposeNewEmailAsync(emailMessage);


        }

        private async void WebK_OnClick(object sender, RoutedEventArgs e)
        {
            //Going to Kshatriya.co.uk

            await Launcher.LaunchUriAsync(new Uri("http://www.kshatriya.co.uk"));

        }

        private void performCustomCalculation()
        {

            tip.CalculateTip(tip.BillAmount, tip.MyPercentage);

            amountToTip2TextBlock.Text = tip.TipAmount;
            total2TextBlock.Text = tip.TotalAmount;

        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            performCustomCalculation();
        }

        private void percentTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            percentToTipTextBox.Text = tip.myPercentage;
        }

        private void percentTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            percentToTipTextBox.Text = "";
        }

        private void amountTextBox2_LostFocus(object sender, RoutedEventArgs e)
        {
            billAmount2TextBox.Text = tip.BillAmount;
        }

        private void amountTextBox2_GotFocus(object sender, RoutedEventArgs e)
        {
            billAmount2TextBox.Text = "";
        }
        private void billAmount2TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            tip.BillAmount = billAmount2TextBox.Text;
            performCustomCalculation();
        }

        private void percentTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            tip.CalculatePercent(percentToTipTextBox.Text);
            performCustomCalculation();
        }


    }
}
