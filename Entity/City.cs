using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string Citycode { get; set; }
        public int  StateId { get; set; }
        public  virtual State State { get; set; }
    }
}
