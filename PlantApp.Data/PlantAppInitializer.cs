using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PlantApp.Data.Models;

namespace PlantApp.Data
{
    public class PlantAppInitializer : DropCreateDatabaseIfModelChanges<PlantAppContext>
    {
        protected override void Seed(PlantAppContext context)
       {
            var plantSpecies3 = new PlantSpecies()
            {
                Name = "prva biljka",
                WateringFrequencyDays = 3000,
                MinimalWaterAmountForWatering = 10,
                Color = "Blue",
                MonthsOfFlowering = "12345",
                MaintenceGuide = "ne gaziti",
                Seedling = null
            };

            context.PlantSpecies.Add(plantSpecies3);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}