using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace Datumation.Controllers
{
    
 
    [Route("api/[controller]")]
    public class ProviderController : Controller
    {

       public Providers.Service.IProviderService _provider
        = new Providers.Service.ProviderCacheService(new Providers.Repo.ProviderRepo());


        private Providers.Repo.IProviderRepo _providerRepo;

        public ProviderController(Providers.Repo.IProviderRepo repo)
        {
            _providerRepo = repo;

        }
        private static string[] Specialties = new[]
        {
            "Chiropractor",
"Dentist",
"Dietician",
"Nurse",
"Pharmacist",
"Physical Therapist",
"Physician",
"Student",
"Therapist"
        };

        
        private Task<IEnumerable<Providers.Models.ProviderByStateModel>> AllProviderStates()
        {

            var rng = new Random();
            var states = new Models.UsState();
            return Task.Run(() => Enumerable.Range(0, states.States.Count).Select(index => new Providers.Models.ProviderByStateModel()
            {
                Id = index.ToString(),
                RecordCount = rng.Next(0, 100000),
                StateName = states.States[index].StateName,
                SpecialtyType = Specialties[rng.Next(Specialties.Length)]
            })
            );
        }
        [Route("ProviderStates")]
        public async Task<List<Providers.Models.ProviderByStateModel>> ProviderStates()
        {
            return await _provider.GetStateData();
        }

        public class StateName 
        {
            public string stateName {get;set;}
        }
        [HttpPost]
        [Route("ProviderByState")]
        public async Task<List<Providers.Models.ProviderByStateModel>> ProviderByState([FromBody] StateName stateName)
        {
            return await _provider.GetStateDataByState(stateName.stateName);
        }
        [HttpGet]
        [Route("ProviderSpecialties")]
        public async Task<List<Providers.Models.ProviderByTypeModel>> ProviderSpecialties()
        {
            return await _provider.GetProviderTypes();
        }

        public class Specialty
        {
            public string specialty {get;set;}
        }
        [HttpPost]
        [Route("ProviderStatesBySpecialty")]
        public async Task<List<Providers.Models.ProviderByTypeModel>> ProviderStatesBySpecialty([FromBody] Specialty specialty)
        {
            return await _provider.GetStatesBySpecialty(specialty.specialty);
        }


    }
}
