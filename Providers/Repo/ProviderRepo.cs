using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DapperExtensions;
using app_datumation.Providers.Models;
using Microsoft.Extensions.Caching.Memory;

namespace app_datumation.Providers.Repo
{
    public interface IProviderRepo
    {
        Task<List<Models.ProviderByTypeModel>> GetProviderTypes();
        Task<List<Models.ProviderByTypeModel>> GetStatesBySpecialty(string specialty);
        Task<List<ProviderByStateModel>> GetStateData();
        Task<List<ProviderByStateModel>> GetStateDataByState(string stateName);

    }



    public static class BaseProviderRepo
    {

        // click state see specialties
        public static string SpecialtyByState()
        {
            return @"SELECT Id, StateName, SpecialtyType, 2999 AS RecordCount FROM (
            select ROW_NUMBER() OVER(ORDER BY providerType ASC) AS Id, ROW_NUMBER() OVER(PARTITION BY providerType ORDER BY stateName ASC) AS rn,
            stateName AS StateName, providerType AS SpecialtyType,providerTypeAbbreviation
            from dbo.DatumationFiles
            where providerType IS NOT NULL AND stateName IS NOT NULL
            ) t
            WHERE SpecialtyType = @specialtyType";
        }
        public static string SpecialtiesQuery()
        {
            return @"SELECT Id, StateName, SpecialtyType, 2999 AS RecordCount FROM (
            select ROW_NUMBER() OVER(ORDER BY providerType ASC) AS Id, ROW_NUMBER() OVER(PARTITION BY providerType ORDER BY stateName ASC) AS rn,
            stateName AS StateName, providerType AS SpecialtyType,providerTypeAbbreviation
            from dbo.DatumationFiles
            where providerType IS NOT NULL AND stateName IS NOT NULL
            ) t";
        }
        public static string QuerySpecialty()
        {
            StringBuilder sb = new StringBuilder();
            try
            {

                Infrastructure.Logging.LogFactory
                .Instance.Log()
                .WriteMessage("VIEW MODEL: " + Infrastructure.Configuration.ConfigurationFactory.Instance.Configuration()
                .SpecialtyQueryView);

                sb.Append("SELECT ").Append(Infrastructure.Configuration.ConfigurationFactory.Instance.Configuration()
                .SpecialtyQueryCols)
                .Append(" ").Append(" FROM ").Append(Infrastructure.Configuration.ConfigurationFactory.Instance.Configuration()
                .SpecialtyQueryView);

            }
            catch (System.Exception e)
            {

                Infrastructure.Logging.LogFactory.Instance.Log().WriteMessage(string.Format("ERROR QUERY SPEC: {0}", e.Message));
            }

            return sb.ToString();
        }
    }

    public class ProviderRepo : app_datumation.Data.BaseRepo, IProviderRepo
    {

        private Task<List<Models.ProviderByTypeModel>> GetListAsync()
        {
            return Task.Run(() => new List<Models.ProviderByTypeModel>(){
        new ProviderByTypeModel()
        {
            Id = "1",
            SpecialtyType = "Dentist",
            RecordCount = 111111
        },
          new ProviderByTypeModel()
        {
            Id = "2",
            SpecialtyType = "Podiatrist",
            RecordCount = 23441
        },
          new ProviderByTypeModel()
        {
            Id = "2",
            SpecialtyType = "Podiatrist",
            RecordCount = 23441
        }
    });
        }



        public async Task<List<Models.ProviderByTypeModel>> GetStatesBySpecialty(string specialty)
        {


            using (var con = base.GetSql(Infrastructure.Configuration.ConfigurationFactory.Instance.Configuration().SqlConnection))
            {
                con.Open();
                return (await con.QueryAsync<Models.ProviderByTypeModel>(BaseProviderRepo.SpecialtyByState(), new
                {
                    specialtyType = specialty
                })).ToList();
            }

        }
        public async Task<List<Models.ProviderByTypeModel>> GetProviderTypes()
        {


            using (var con = base.GetSql(Infrastructure.Configuration.ConfigurationFactory.Instance.Configuration().SqlConnection))
            {

                con.Open();
                var result = (await con.QueryAsync<Models.ProviderByTypeModel>("SELECT * FROM dbo.ProviderStateFilesView")).ToList();
                var query =
                      from provider in result
                      group provider by provider.SpecialtyType into providerlist
                      select providerlist.AsList().FirstOrDefault();

                return query.ToList();

            }

        }
        public async Task<List<ProviderByStateModel>> GetStateData()
        {
            using (var con = base.GetSql(Infrastructure.Configuration.ConfigurationFactory.Instance.Configuration().SqlConnection))
            {
                con.Open();
                var result = (await con.QueryAsync<Models.ProviderByStateModel>("SELECT * FROM dbo.ProviderStateFilesView ORDER BY StateName ASC")).ToList();
                var query =
                  from state in result
                  group state by state.StateName into stateList
                  select stateList.AsList().FirstOrDefault();

                return query.ToList();
            }
        }
        public async Task<List<ProviderByStateModel>> GetStateDataByState(string stateName)
        {
            using (var con = base.GetSql(Infrastructure.Configuration.ConfigurationFactory.Instance.Configuration().SqlConnection))
            {
                con.Open();
                var result = (await con.QueryAsync<Models.ProviderByStateModel>("SELECT * FROM dbo.ProviderStateFilesView WHERE StateName = @stateName", new
                {
                    stateName = stateName
                })).ToList();
                var query = result.OrderBy(s => s.SpecialtyType).ToList();

                return query.ToList();
            }
        }
        
    }
}
