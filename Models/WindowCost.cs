using WindowCalculator.Models.Enums;

namespace WindowCalculator.Models
{
    public class WindowCost
    {
        public WindowCost()
        {
        }

        public WindowCost(int windowSize, FrameType frameType)
        {
            WindowSize = windowSize;
            FrameType = frameType;
        }

        /// <summary>
        /// Размер окна   
        /// </summary>
        public int WindowSize { get; set; }

        /// <summary>
        /// Тип рамы
        /// </summary>
        public FrameType FrameType { get; set; }
    }
}
