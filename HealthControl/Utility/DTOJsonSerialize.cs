using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class DTOJsonSerialize<T>
    {
        public static T GetDTO(string json)
        {


            T entity = JsonConvert.DeserializeObject<T>(json);


            return entity;
        }
        public static string GetJson(T entity)
        {

            string json = JsonConvert.SerializeObject(entity);
            return json;
        }
    }
}
