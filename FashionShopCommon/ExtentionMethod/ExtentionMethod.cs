using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FashionShopCommon.ExtentionMethod
{
    public static class ExtentionMethod
    {
        public static object GetValue(this Dictionary<string, object> keyValuePairs, string key)
        {
            if (keyValuePairs != null)
            {
                if (keyValuePairs.ContainsKey(key))
                {
                    return keyValuePairs[key];
                }
            }
            return "";
        }
        public static JObject ToCamelCaseProperties(this object obj)
        {
            var jObject = JObject.FromObject(obj);

            foreach (var property in jObject.Properties().ToList())
            {
                property.Replace(new JProperty(Char.ToUpper(property.Name[0]) + property.Name.Substring(1), property.Value));
            }

            return jObject;
    }
    }

}
