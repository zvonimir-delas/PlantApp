using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlantApp.Data.Models;

namespace PlantApp.Domain.DTOs
{
    public class SeedlingDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Plant> Plants { get; set; }

        public static SeedlingDTO FromEntity(Seedling seedling)
        {
            return new SeedlingDTO
            {
                Id = seedling.Id,
                Name = seedling.Name,
                Plants = seedling.Plants.ToList().Select(x => new Plant() { Id = x.Id, PlantSpecie = new PlantSpecie() { Id = x.PlantSpecie.Id, Color = x.PlantSpecie.Color, MaintenceGuide = x.PlantSpecie.MaintenceGuide, MinimalWaterAmountForWatering = x.PlantSpecie.MinimalWaterAmountForWatering, MonthsOfFlowering = x.PlantSpecie.MonthsOfFlowering, Name = x.PlantSpecie.Name, Plants = null, WateringFrequencyDays = x.PlantSpecie.WateringFrequencyDays}, Seedling = null }).ToList()
            };

        }

        // This piece of code I would like to discuss in the interview
        /*
        public static List<Plant> RemoveSeedlingReference(List<Plant> plants)
        {
            foreach (Plant plant in plants)
            {
                plant.Seedling = null;
                plant.PlantSpecie.Plants = null;
            }

            return plants;
        }
        */
    }
}