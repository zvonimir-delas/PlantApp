﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantApp.Data.Models
{
    public class Plant
    {
        public int Id { get; set; }

        public PlantSpecie PlantSpecie { get; set; }
        public Seedling Seedling { get; set; }
    }
}