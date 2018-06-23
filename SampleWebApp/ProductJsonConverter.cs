using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

            if (IsTypeOf(jObject, typeof(Oil)))
            { 
                return new Oil();
            }
            return new Product();

            //now the base class' code will populate the returned object.
        }

        private bool IsTypeOf(JObject jObject, Type type)
        {
            foreach (var prop in type.GetProperties())
            {
                if (jObject[prop.Name] == null)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
