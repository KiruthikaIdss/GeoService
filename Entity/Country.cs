using System;
using System.Collections.Generic;

namespace Entity
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Countrycode { get; set; }
        public string CountryName { get; set; }
        public ICollection<State> States { get; set; }

    }
  
   
    
}
