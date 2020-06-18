using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationService.ViewModel
{
    public class StateReadModel
    {
        public string Statecode { get; set; }
        public string Statename { get; set; }
        public int CountryId { get; set; }
    }
    public class StateModel
    {
        public int StateId { get; set; }
        public string Statecode { get; set; }
        public string Statename { get; set; }
        public int CountryId { get; set; }
    }
}
