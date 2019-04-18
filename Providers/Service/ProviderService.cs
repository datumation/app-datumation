using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datumation.Providers.Models;
using Datumation.Providers.Repo;
using Microsoft.Extensions.Caching.Memory;

namespace Datumation.Providers.Service
{


    public interface IProviderService
    {
        Task<List<ProviderByTypeModel>> GetProviderTypes();
        Task<List<ProviderByTypeModel>> GetStatesBySpecialty(string specialty);
        Task<List<ProviderByStateModel>> GetStateData();
 Task<List<ProviderByStateModel>> GetStateDataByState(string stateName);
    }
    public class ProviderCacheService : IProviderService
    {
        private Repo.IProviderRepo _repo;
        public ProviderCacheService(Repo.IProviderRepo repo)
        {
            _repo = repo;
        }

        public async Task<List<ProviderByTypeModel>> GetProviderTypes()
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("CACHE_KEY").Append("GetProviderTypes");
            var items = Infrastructure.Configuration.ConfigurationFactory.Instance.Configuration().MemoryCacheConfig.Retrieve<List<ProviderByTypeModel>>(sb.ToString());
            if (items == null)
            {
                items = await _repo.GetProviderTypes();
                if (items != null)
                {
                    Infrastructure.Configuration.ConfigurationFactory.Instance.Configuration().MemoryCacheConfig.Store(sb.ToString(), items);
                }
            }

            return items;
        }
         public async Task<List<ProviderByTypeModel>> GetStatesBySpecialty(string specialty)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("CACHE_KEY").Append("GETSPECIALTYBYSTATE_").Append(specialty);
            var items = Infrastructure.Configuration.ConfigurationFactory.Instance.Configuration().MemoryCacheConfig.Retrieve<List<ProviderByTypeModel>>(sb.ToString());
            if (items == null)
            {
                items = await _repo.GetStatesBySpecialty(specialty);
                if (items != null)
                {
                    Infrastructure.Configuration.ConfigurationFactory.Instance.Configuration().MemoryCacheConfig.Store(sb.ToString(), items);
                }
            }

            return items;
        }
                 public async Task<List<ProviderByStateModel>> GetStateData()
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("CACHE_KEY").Append("GETSTATEDATA_");
            var items = Infrastructure.Configuration.ConfigurationFactory.Instance.Configuration().MemoryCacheConfig.Retrieve<List<ProviderByStateModel>>(sb.ToString());
            if (items == null)
            {
                items = await _repo.GetStateData();
                if (items != null)
                {
                    Infrastructure.Configuration.ConfigurationFactory.Instance.Configuration().MemoryCacheConfig.Store(sb.ToString(), items);
                }
            }

            return items;
        }
                public async Task<List<ProviderByStateModel>> GetStateDataByState(string stateName)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("CACHE_KEY").Append("GETSTATEDATA_").Append(stateName);
            var items = Infrastructure.Configuration.ConfigurationFactory.Instance.Configuration().MemoryCacheConfig.Retrieve<List<ProviderByStateModel>>(sb.ToString());
            if (items == null)
            {
                items = await _repo.GetStateDataByState(stateName);
                if (items != null)
                {
                    Infrastructure.Configuration.ConfigurationFactory.Instance.Configuration().MemoryCacheConfig.Store(sb.ToString(), items);
                }
            }

            return items;
        }
    }

    public class ProviderService : IProviderService
    {
        private IProviderRepo _repo;

        public ProviderService(IProviderRepo repo)
        {
            _repo = repo;
        }
        public async Task<List<ProviderByTypeModel>> GetProviderTypes()
        {

            return await _repo.GetProviderTypes();

        }
            public async Task<List<ProviderByTypeModel>> GetStatesBySpecialty(string specialty)
        {

            return await _repo.GetStatesBySpecialty(specialty);

        }

        public async Task<List<ProviderByStateModel>> GetStateData()
        {
         return await _repo.GetStateData();
        }

        public async Task<List<ProviderByStateModel>> GetStateDataByState(string stateName)
        {
            return await _repo.GetStateDataByState(stateName);
        }
    }
}