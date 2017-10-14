using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlantApp.Data;

namespace PlantApp.Domain.Controllers
{
    [RoutePrefix("api/test")]
    public class TESTController : ApiController
    {
        [HttpGet]
        [Route("testFunction")]
        public string Test()
        {
            using (var context = new PlantAppContext())
            {
                return context.PlantSpecies.Where(x => x.Name == "prva biljka").FirstOrDefault().Name;
            }
        }
    }
}
