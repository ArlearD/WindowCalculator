using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WindowCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ValidateNumberTypeAndRange(int minValue, int maxValue, TextBlock errorBox, TextBox targetField)
        {
            int fieldValue;
            if (int.TryParse(targetField.Text, out fieldValue))
            {
                if (errorBox != null)
                {
                    if (fieldValue < minValue || fieldValue > maxValue)
                        errorBox.Visibility = Visibility.Visible;
                    else
                        errorBox.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                errorBox.Visibility = Visibility.Visible;
            }
        }

        private void CalculateWindowCost()
        {
            if (windowCostResult != null)
            {
                try
                {
                    windowCostResult.Text = (int.Parse(windowSize.Text) * int.Parse(frameType.Text)).ToString();
                }
                catch
                {
                    windowCostResult.Text = string.Empty;
                }
            }
        }

        private void CalculateInstallationCost()
        {
            if (installationCostResult != null)
            {
                try
                {
                    var difDaysCost = 7 - int.Parse(urgency.Text);
                    if (difDaysCost <= 0)
                    {
                        difDaysCost = 1;
                    }
                    installationCostResult.Text = (int.Parse(floorHeight.Text) * difDaysCost).ToString();
                }
                catch
                {
                    installationCostResult.Text = string.Empty;
                }
            }
        }

        private void WindowSizeValidator(object sender, TextChangedEventArgs e)
        {
            ValidateNumberTypeAndRange(10, 50, windowSizeErrorMessage, windowSize);
            CalculateWindowCost();
        }

        private void FrameTypeValidator(object sender, TextChangedEventArgs e)
        {
            ValidateNumberTypeAndRange(1, 3, frameTypeErrorMessage, frameType);
            CalculateWindowCost();
        }

        private void FloorHeightValidator(object sender, TextChangedEventArgs e)
        {
            ValidateNumberTypeAndRange(1, 19, floorHeightErrorMessage, floorHeight);
            CalculateInstallationCost();
        }

        private void DateChangedController(object sender, MouseButtonEventArgs e)
        {
            ValidateNumberTypeAndRange(1, 19, floorHeightErrorMessage, floorHeight);
            CalculateInstallationCost();
        }

        private void UrgencyValidator(object sender, TextChangedEventArgs e)
        {
            ValidateNumberTypeAndRange(0, 7, urgencyErrorMessage, urgency);
            CalculateInstallationCost();
        }
    }
}
