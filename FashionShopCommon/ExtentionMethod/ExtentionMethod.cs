using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
