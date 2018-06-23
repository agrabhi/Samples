using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebApp
{
    [JsonConverter(typeof(ProductJsonConverter))]
    public class Oil: Product
    {
        public int Price { get; set; }
    }
}
