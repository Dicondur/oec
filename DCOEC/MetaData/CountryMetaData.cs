using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DCOEC.Models
{

    [ModelMetadataType(typeof(CountryMetaData))]
    public partial class Country
    {
    }
    public class CountryMetaData
    {
        public string CountryCode { get; set; }
        public string Name { get; set; }
        public string PostalPattern { get; set; }
        public string PhonePattern { get; set; }

        public ICollection<Province> Province { get; set; }

    }
   
    
}
