using app_datumation.Infrastructure.Caching;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;


namespace app_datumation.Infrastructure.Configuration
{
    /// <summary>
    /// app settings models
    /// </summary>
    public class DataRepositoryConfig
    {
        public ViewConfig Views { get; set; }
    }
    public class ViewConfig
    {
        public string CodePurpose { get; set; }
        public string Name { get; set; }
        public string Columns { get; set; }
        public string ViewName { get; set; }

    }
    public interface IAppConfiguration
    {

        string RootUrl { get; }
        string SqlConnection { get; }
        ICacheProvider MemoryCacheConfig { get; }
        string SpecialtyQueryView { get; }
        string SpecialtyQueryCols { get; }
    }
}