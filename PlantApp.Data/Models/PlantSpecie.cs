using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantApp.Data.Models
{

    public class PlantSpecie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int WateringFrequencyDays { get; set; }
        public int MinimalWaterAmountForWatering { get; set; }
        public string Color { get; set; }
        public string MonthsOfFlowering { get; set; }
        public string MaintenceGuide { get; set; }

        public ICollection<Plant> Plants { get; set; }
    }
}
