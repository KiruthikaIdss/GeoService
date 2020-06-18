using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationService.ViewModel
{
    public class ViewCountry
    {
        public int Countrycode { get; set; }
        public string Countryname { get; set; }
    }
    public class UpdateCountry
    {
        public int CountryId { get; set; }
        public int Countrycode { get; set; }
        public string CountryName { get; set; }
    }
}
