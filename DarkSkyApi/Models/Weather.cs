﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarkSkyApi.Models
{
    public class Weather
    {
        public double Latitude { get; set; }

        public double Longitutde { get; set; }

        //object we want
        public Currently Currently { get; set; }
    }

    public class Currently
    {
        public string Summary { get; set; }

        public decimal Temperature { get; set; }
    }
}
