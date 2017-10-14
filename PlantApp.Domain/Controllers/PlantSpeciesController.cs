﻿using System;
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
        public List<PlantSpecies> getAllPlants()
        {
            using (var context = new PlantAppContext())
            {
                return context.PlantSpecies.ToList();
            }
        }

        [HttpGet]
        [Route("getPlant/{id:int}")]
        public PlantSpecies getPlantById(int id)
        {
            using (var context = new PlantAppContext())
            {
                return context.PlantSpecies.Where(x => x.Id == id).FirstOrDefault();
            }
        }

        /*[HttpPost]
        [Route("add")]
        public void AddNewPlant(string name, int wateringFrequencyDays, int minimalAmountOfWatering, int color, string maintenceGuide)
        {
            using (var context = new PlantAppContext())
            {
                var newPlant = new PlantSpecies()
                {
                    Name = name,
                    WateringFrequencyDays = wateringFrequencyDays,
                    MinimalWaterAmountForWatering = minimalAmountOfWatering,
                    Color = (Color)color,
                    MaintenceGuide = maintenceGuide
                };

                context.PlantSpecies.Add(newPlant);

                context.SaveChanges();
            }
        }
        */
        [HttpPost]
        [Route("delete/{id:int}")]
        //POSSIBLE REFACTURING: object as a paramater
        public void DeletePlant(int id)
        {
            using (var context = new PlantAppContext())
            {
                var plant = context.PlantSpecies.Where(x => x.Id == id).FirstOrDefault();

                context.Entry(plant).State = EntityState.Deleted;                
                context.SaveChanges();
            }
        }
    }
}