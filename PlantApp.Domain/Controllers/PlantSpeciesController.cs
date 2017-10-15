using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlantApp.Data;
using PlantApp.Data.Models;
using System.Data.Entity;

namespace PlantApp.Domain.Controllers
{
    [RoutePrefix("api/plant")]
    public class PlantSpeciesController : ApiController
    {

        [HttpGet]
        [Route("getAll")]
        public List<PlantSpecies> GetAllPlants()
        {
            using (var context = new PlantAppContext())
            {
                return context.PlantSpecies.ToList();
            }
        }

        [HttpGet]
        [Route("getPlant/{id:int}")]
        public PlantSpecies GetPlantById(int id)
        {
            using (var context = new PlantAppContext())
            {
                return context.PlantSpecies.Where(x => x.Id == id).FirstOrDefault();
            }
        }

        [HttpPost]
        [Route("add")]
        public string AddNewPlant(HttpRequestMessage request,
            [FromBody] PlantSpecies newPlant)
        {
            using (var context = new PlantAppContext())
            {
                /*var newPlant = new PlantSpecies()
                {
                    Name = name,
                    WateringFrequencyDays = wateringFrequencyDays,
                    MinimalWaterAmountForWatering = minimalAmountOfWatering,
                    Color = (Color)color,
                    MaintenceGuide = maintenceGuide
                };*/

                context.PlantSpecies.Add(newPlant);
                context.SaveChanges();

                return "Added new plant";
            }
        }

        [HttpPost]
        [Route("delete/{id:int}")]
        public void DeletePlant(int id)
        {
            using (var context = new PlantAppContext())
            {
                var plant = context.PlantSpecies.Where(x => x.Id == id).FirstOrDefault();

                context.Entry(plant).State = EntityState.Deleted;                
                context.SaveChanges();
            }
        }

        [HttpPost]
        [Route("update/")]
        // syntax to receive a complex object:
        public string UpdatePlant(HttpRequestMessage request,
            [FromBody] PlantSpecies plant)
        {
            using (var context = new PlantAppContext())
            {
                context.Entry(plant).State = EntityState.Modified;
                context.SaveChanges();
            }

            return "Changes have been saved";
        }
    }
}
