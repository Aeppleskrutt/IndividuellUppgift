using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividuellUppgift.Models
{
    public class CityEntrySingleton
    {
        
        private static readonly CityEntrySingleton instance = new CityEntrySingleton();

        public string SearchCity { get; set; }

        private CityEntrySingleton()
        {
            
        }
        public static CityEntrySingleton GetCityAsync()
        {
            return instance;
        }


    }
}
