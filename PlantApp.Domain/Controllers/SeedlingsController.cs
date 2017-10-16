using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Web.Http;
using PlantApp.Data.Models;
using PlantApp.Data;
using PlantApp.Domain.DTOs;

namespace PlantApp.Domain.Controllers
{
    [RoutePrefix("api/seedling")]
    public class SeedlingsController : ApiController
    {
        [HttpGet]
        [Route("getAll")]
        public List<SeedlingDTO> GetAllSeedlings()
        {
            using (var context = new PlantAppContext())
            {
                var seedlings = context.Seedlings.ToList().Select(x => SeedlingDTO.FromEntity(x)).ToList();
                return seedlings;
            }
        }

        [HttpGet]
        [Route("get/{id:int}")]
        public SeedlingDTO GetSeedlingById(int id)
        {
            using (var context = new PlantAppContext())
            {
                return context.Seedlings.Where(x => x.Id == id).ToList().Select(x => SeedlingDTO.FromEntity(x)).FirstOrDefault();
            }
        }

        [HttpPost]
        [Route("water/{id:int}")]
        public string WaterPlants(int id)
        {
            using (var context = new PlantAppContext())
            {
                var plants = context.Seedlings.Where(x => x.Id == id).FirstOrDefault().Plants;

                foreach (var plant in plants)
                {
                    plant.TimeAndDateLastWatered = DateTime.Now;
                    context.Entry(plant).State = EntityState.Modified;
                    context.SaveChanges();
                }
                
            }

            return "Plants have been watered";
        }

        [HttpGet]
        [Route("calculateWater/{id:int}")]
        public int CalculateWaterVolume(int id)
        {
            int totalVolume = 0;

            using (var context = new PlantAppContext())
            {
                var seedling = context.Seedlings.Where(x => x.Id == id).FirstOrDefault();

                foreach (var plant in seedling.Plants)
                {
                    totalVolume += DateTime.Now.Subtract((DateTime)plant.TimeAndDateLastWatered).TotalDays > plant.PlantSpecie.WateringFrequencyDays ? plant.PlantSpecie.MinimalWaterAmountForWatering : 0;
                }

                return totalVolume;
            }
        }

        [HttpPost]
        [Route("deletePlant/{id:int}")]
        public void DeletePlant(int id)
        {
            using (var context = new PlantAppContext())
            {
                var plant = context.Plants.Where(x => x.Id == id).FirstOrDefault();

                    context.Entry(plant).State = EntityState.Deleted;
                    context.SaveChanges();
            }
        }

        [HttpPost]
        [Route("addPlant/{newName}/{id:int}")]
        public void AddPlant(string newName, int id)
        {
            using (var context = new PlantAppContext())
            {
                var seedling = context.Seedlings.Where(x => x.Id == id).FirstOrDefault();

                Plant plant = new Plant()
                {
                    PlantSpecie = context.PlantSpecies.Where(x => x.Name == newName).FirstOrDefault(),
                    Seedling = seedling,
                    TimeAndDateLastWatered = DateTime.Now
                };

                context.Plants.Add(plant);
                context.SaveChanges();
            }
        }

        [HttpPost]
        [Route("deleteSeedling/{id:int}")]
        public void DeleteSeedling(int id)
        {
            using (var context = new PlantAppContext())
            {
                var seedling = context.Seedlings.Where(x => x.Id == id).FirstOrDefault();

                for (int i = 0; i < seedling.Plants.ToList().Count(); i++)
                {
                    context.Entry(seedling.Plants.ToList()[i]).State = EntityState.Deleted;
                }

                context.Entry(seedling).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        [HttpPost]
        [Route("addSeedling/")]
        public void AddSeedling(HttpRequestMessage request,
            [FromBody] Seedling seedling)
        {
            using (var context = new PlantAppContext())
            {
                context.Seedlings.Add(seedling);
                context.SaveChanges();
            }
        }
    }
}
