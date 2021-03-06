﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiInheritance;

namespace SampleWebApp
{
    [JsonConverter(typeof(ProductJsonConverter))]
    public class Product
    {
        public string Id { get; set; }

        public ProductConfig Config { get; set; }
    }
}
