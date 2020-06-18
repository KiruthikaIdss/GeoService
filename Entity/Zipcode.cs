using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity
{
    
    public class Zipcode
    {
        [Key]
        public int ZipId { get; set; }
        public City CityId { get; set; }
        public int ZipNumber { get; set; }
      
     }
   
}

