using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantApp.Data.Models
{
    public class Seedling
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Plant> Plants { get; set; }
    }
}
