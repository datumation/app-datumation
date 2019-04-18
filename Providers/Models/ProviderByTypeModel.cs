using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Datumation.Providers.Models
{
    public class ProviderByTypeModel
    {
        public string Id { get; set; }
        public string SpecialtyType { get; set; }
        public string StateName {get;set;}
        public int RecordCount { get; set; }
    }
}