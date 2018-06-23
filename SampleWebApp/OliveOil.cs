using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebApp
{
    [JsonConverter(typeof(ProductJsonConverter))]
    public class OliveOil: Oil
    {
        public string Color { get; set; }
    }
}
