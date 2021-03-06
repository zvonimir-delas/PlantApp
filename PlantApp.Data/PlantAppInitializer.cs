﻿using System;
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
            var plantSpecie1 = new PlantSpecie()
            {
                Name = "prva vrsta",
                WateringFrequencyDays = 3000,
                MinimalWaterAmountForWatering = 10,
                Color = "Blue",
                MonthsOfFlowering = "12,3,4,5",
                MaintenceGuide = "ne gaziti"
            };

            var plantSpecie2 = new PlantSpecie()
            {
                Name = "druga vrsta",
                WateringFrequencyDays = 50,
                MinimalWaterAmountForWatering = 20,
                Color = "Red",
                MonthsOfFlowering = "1,2,3,4,5",
                MaintenceGuide = "nista posebno"
            };

            var seedling1 = new Seedling()
            {
                Name = "prva sadnica",
                Plants = new List<Plant> {}
            };

            var seedling2 = new Seedling()
            {
                Name = "druga sadnica"
            };

            var plant1 = new Plant()
            {
                PlantSpecie = plantSpecie1,
                Seedling = seedling1,
                TimeAndDateLastWatered = DateTime.Now,
            };

            var plant2 = new Plant()
            {
                PlantSpecie = plantSpecie2,
                Seedling = seedling1,
                TimeAndDateLastWatered = DateTime.Now
            };

            var plant3 = new Plant()
            {
                PlantSpecie = plantSpecie1,
                Seedling = seedling2,
                TimeAndDateLastWatered = DateTime.Now
            };

            seedling1.Plants = new List<Plant>{ plant1, plant2 };
            seedling2.Plants = new List<Plant>() { plant3 };

            context.PlantSpecies.Add(plantSpecie1);
            context.PlantSpecies.Add(plantSpecie2);

            context.Plants.Add(plant1);
            context.Plants.Add(plant2);
            context.Plants.Add(plant3);


            context.Seedlings.Add(seedling1);
            context.Seedlings.Add(seedling2);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}