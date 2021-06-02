using WindowCalculator.Models;

namespace WindowCalculator.Services
{
    public class CalculatorService
    {
        public int CalculateWindowCost(WindowCost windowCost)
        {
            return windowCost.WindowSize * ((int)windowCost.FrameType);
        }

        public int CalculateInstallationCost(InstallationCost installationCost)
        {
            var difDaysCost = 7 - installationCost.Urgency;
            if (difDaysCost <= 0)
            {
                difDaysCost = 1;
            }
            return installationCost.FloorHeight * difDaysCost;
        }
    }
}
