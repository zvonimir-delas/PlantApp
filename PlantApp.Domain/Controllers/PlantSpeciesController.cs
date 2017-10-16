using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlantApp.Data;
using PlantApp.Data.Models;
using System.Data.Entity;
using PlantApp.Domain.DTOs;

namespace PlantApp.Domain.Controllers
{
    [RoutePrefix("api/plantSpecie")]
    public class PlantSpeciesController : ApiController
    {

        [HttpGet]
        [Route("getAll")]
        public List<PlantSpecieDTO> GetAllPlantSpecies()
        {
            using (var context = new PlantAppContext())
            {
                return context.PlantSpecies.ToList().Select(x => PlantSpecieDTO.FromEntity(x)).ToList();
            }
        }

        [HttpGet]
        [Route("getPlantSpecie/{id:int}")]
        public PlantSpecieDTO GetPlantSpecieById(int id)
        {
            using (var context = new PlantAppContext())
            {
                return context.PlantSpecies.Where(x => x.Id == id).ToList().Select(x => PlantSpecieDTO.FromEntity(x)).FirstOrDefault();
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
        [Route("delete")]
        public void DeletePlant(HttpRequestMessage request,
            [FromBody] PlantSpecie plantSpecie)
        {
            using (var context = new PlantAppContext())
            {
                context.Entry(plantSpecie).State = EntityState.Deleted;                
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
