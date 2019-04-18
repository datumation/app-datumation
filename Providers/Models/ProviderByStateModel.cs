using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app_datumation.Providers.Models
{
    public class ProviderByStateModel
    {
        public string Id {get;set;}
        public string SpecialtyType {get;set;}
        public string StateName { get; set; }
        public int RecordCount { get; set; }
    }
}