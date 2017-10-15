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
    [RoutePrefix("api/plantSpecie")]
    public class PlantSpeciesController : ApiController
    {

        [HttpGet]
        [Route("getAll")]
        public List<PlantSpecie> GetAllPlantSpecies()
        {
            using (var context = new PlantAppContext())
            {
                return context.PlantSpecies.ToList();
            }
        }

        [HttpGet]
        [Route("getPlantSpecie/{id:int}")]
        public PlantSpecie GetPlantSpecieById(int id)
        {
            using (var context = new PlantAppContext())
            {
                return context.PlantSpecies.Where(x => x.Id == id).FirstOrDefault();
            }
        }

        [HttpPost]
        [Route("add")]
        public string AddNewPlantSpecie(HttpRequestMessage request,
            [FromBody] PlantSpecie newPlantSpecie)
        {
            using (var context = new PlantAppContext())
            {
                context.PlantSpecies.Add(newPlantSpecie);
                context.SaveChanges();

                return "Added new plant specie";
            }
        }

        [HttpPost]
        [Route("delete/{id:int}")]
        public void DeletePlantSpecie(int id)
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
            [FromBody] PlantSpecie plantSpecie)
        {
            using (var context = new PlantAppContext())
            {
                context.Entry(plantSpecie).State = EntityState.Modified;
                context.SaveChanges();
            }

            return "Changes have been saved";
        }
    }
}
