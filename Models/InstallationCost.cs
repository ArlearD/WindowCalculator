namespace WindowCalculator.Models
{
    public class InstallationCost
    {
        public InstallationCost()
        {
        }

        public InstallationCost(int urgency, int floorHeight)
        {
            Urgency = urgency;
            FloorHeight = floorHeight;
        }

        /// <summary>
        /// Срочность
        /// </summary>
        public int Urgency { get; set; }

        /// <summary>
        /// Высота этажа
        /// </summary>
        public int FloorHeight { get; set; }
    }
}
