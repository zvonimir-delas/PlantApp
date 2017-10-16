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
    }
}
