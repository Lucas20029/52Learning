using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _52Learning.Helper
{
    public static class JsonHelper
    {
        public static T Deserialize<T>(this string str)
        {
			try
			{
                return JsonConvert.DeserializeObject<T>(str);
			}
			catch (Exception ex)
			{
                Console.WriteLine(ex.Message + ", content" + str);
                return default(T);
			}
        }
        public static string Serialize(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
