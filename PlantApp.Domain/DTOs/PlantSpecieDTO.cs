using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlantApp.Data.Models;

namespace PlantApp.Domain.DTOs
{
    // this class represents PlantSpecie with a list of Plant that do not have a reference back to the PlantSpecie
    // without this DTO, a circular reference error would be encountered on the Web API
    public class PlantSpecieDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int WateringFrequencyDays { get; set; }
        public int MinimalWaterAmountForWatering { get; set; }
        public string Color { get; set; }
        public string MonthsOfFlowering { get; set; }
        public string MaintenceGuide { get; set; }

        public List<Plant> Plants { get; set; }

        public static PlantSpecieDTO FromEntity(PlantSpecie plantSpecie)
        {
            return new PlantSpecieDTO
            {
                Id = plantSpecie.Id,
                Name = plantSpecie.Name,
                WateringFrequencyDays = plantSpecie.WateringFrequencyDays,
                MinimalWaterAmountForWatering = plantSpecie.MinimalWaterAmountForWatering,
                Color = plantSpecie.Color,
                MonthsOfFlowering = plantSpecie.MonthsOfFlowering,
                MaintenceGuide = plantSpecie.MaintenceGuide,
                Plants = plantSpecie.Plants.ToList().Select(x => x = new Plant() { Id = x.Id, PlantSpecie = null, Seedling = null }).ToList()
            };

        }

        // This piece of code I would like to discuss in the interview
        /*public static List<Plant> RemoveSpecieReference(List<Plant> plants)
        {
            foreach (Plant plant in plants)
            {
                plant = new Plant() { Id = plant.Id, PlantSpecie = null, Seedling = null };
                plant.Seedling = null;
                plant.PlantSpecie = null;
            }

            return plants;
        }*/
    }
}