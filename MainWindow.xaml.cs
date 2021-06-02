using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WindowCalculator.Models;
using WindowCalculator.Models.Enums;
using WindowCalculator.Services;

namespace WindowCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CalculatorService _calculatorService;
        public MainWindow()
        {
            InitializeComponent();
            _calculatorService = new CalculatorService();
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

        private void UpdateWindowCostResult()
        {
            if (windowCostResult == null)
                return;

            var windowCost = new WindowCost();

            try
            {
                windowCost = new WindowCost(int.Parse(windowSize.Text), (FrameType)int.Parse(frameType.Text));
            }
            catch
            {
                windowCostResult.Text = string.Empty;
            }

            windowCostResult.Text = _calculatorService.CalculateWindowCost(windowCost)
                .ToString();
        }

        private void UpdateInstallationCostResult()
        {
            if (installationCostResult == null)
                return;

            var installationCost = new InstallationCost();

            try
            {
                installationCost = new InstallationCost(int.Parse(urgency.Text), int.Parse(floorHeight.Text));
            }
            catch
            {
                installationCostResult.Text = string.Empty;
            }
            
            installationCostResult.Text = _calculatorService.CalculateInstallationCost(installationCost)
                .ToString();
        }

        private void WindowSizeValidator(object sender, TextChangedEventArgs e)
        {
            ValidateNumberTypeAndRange(10, 50, windowSizeErrorMessage, windowSize);
            UpdateWindowCostResult();
        }

        private void FrameTypeValidator(object sender, TextChangedEventArgs e)
        {
            ValidateNumberTypeAndRange(1, 3, frameTypeErrorMessage, frameType);
            UpdateWindowCostResult();
        }

        private void FloorHeightValidator(object sender, TextChangedEventArgs e)
        {
            ValidateNumberTypeAndRange(1, 19, floorHeightErrorMessage, floorHeight);
            UpdateInstallationCostResult();
        }

        private void DateChangedController(object sender, MouseButtonEventArgs e)
        {
            ValidateNumberTypeAndRange(1, 19, floorHeightErrorMessage, floorHeight);
            UpdateInstallationCostResult();
        }

        private void UrgencyValidator(object sender, TextChangedEventArgs e)
        {
            ValidateNumberTypeAndRange(0, 7, urgencyErrorMessage, urgency);
            UpdateInstallationCostResult();
        }
    }
}
