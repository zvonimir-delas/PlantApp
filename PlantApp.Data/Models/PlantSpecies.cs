using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantApp.Data.Models
{
    public enum Color { Blue, Green, Red, Pink}

    public class PlantSpecies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int WateringFrequencyDays { get; set; }
        public int MinimalWaterAmountForWatering { get; set; }
        public Color Color { get; set; }
        public List<int> MonthsOfFlowering { get; set; }
        public string MaintenceGuide { get; set; }

        public Seedling Seedling { get; set; }
    }
}
