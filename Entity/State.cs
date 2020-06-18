using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class State
    {
       

        public int StateId { get; set; }
        public string StateName { get; set; }
        public string Statecode { get; set; }
        public   int  CountryId { get; set; }
        public virtual Country Country { get; set; }
        public ICollection<City> Cities { get; set; }

    }
}
