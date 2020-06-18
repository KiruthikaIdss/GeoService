using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationService.ViewModel
{
    public class CityReadModel
    {
        public string Citycode { get; set; }
        public string Cityname { get; set; }
        public int StateId { get; set; }
    }
    public class CityModel
    {
        public int CityId { get; set; }
        public string Citycode { get; set; }
        public string Cityname { get; set; }
        public int StateId { get; set; }
    }
}
