using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PlantApp.Data.Models;

namespace PlantApp.Data
{
    public class PlantAppContext : DbContext
    {
        public PlantAppContext() : base()
        {
            Database.SetInitializer(new PlantAppInitializer());
        }

        public virtual DbSet<PlantSpecie> PlantSpecies { get; set; }
        public virtual DbSet<Seedling> Seedlings { get; set; }
        public virtual DbSet<Plant> Plants { get; set; }
    }
}
