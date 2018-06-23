using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebApp
{
    public class ProductJsonConverter : JsonCreationConverter<Product>
    {
        protected override Product Create(Type objectType, JObject jObject)
        {
            //TODO: read the raw JSON object through jObject to identify the type
            //e.g. here I'm reading a 'typename' property:

            if (IsTypeOf(jObject, new OliveOil()))
            {
                return new OliveOil();
            }

            if (IsTypeOf(jObject, new Oil()))
            { 
                return new Oil();
            }

            if (IsTypeOf(jObject, new Paper()))
            {
                return new Paper();
            }

            return new Product();

            //now the base class' code will populate the returned object.
        }

        private JObject GetJObject(Product obj)
        {
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var interimStr = JsonConvert.SerializeObject(obj, jsonSerializerSettings);

            return JObject.Parse(interimStr);            
        }

        private bool IsTypeOf(JObject jObject, Product prod)
        {
            JObject typeJObject = this.GetJObject(prod);
            foreach (var kv in typeJObject)
            {
                if (jObject[kv.Key] == null)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
