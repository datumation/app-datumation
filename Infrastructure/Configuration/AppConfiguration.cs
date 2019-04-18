using System;
using System.Configuration;
using System.Net;
using System.Collections.Generic;
using System.Net.Http;
using app_datumation.Infrastructure.Caching;
using System.Linq;

using app_datumation.Infrastructure.Configuration;
using Microsoft.Extensions.Configuration;

namespace app_datumation.Infrastructure.Configuration
{
    public class AppConfiguration : IAppConfiguration
    {
        private IConfiguration _config;
        public AppConfiguration(IConfiguration config)
        {
            _config = config;
        }
        public string RootUrl
        {
            get
            {
                return _config.GetSection("AppSettings").GetValue<string>("RootUrl");
            }
        }


        public string SqlConnection
        {
            get
            {
                return _config.GetSection("ConnectionStrings").GetValue<string>("SqlConnection");
            }
        }
        public ICacheProvider MemoryCacheConfig
        {
            get
            {
                return new MemoryCacheProvider();
            }
        }
        public string SpecialtyQueryView
        {
            get
            {
                return _config.GetSection("DataRepository").GetValue<string>("SpecialtyQueryView");
            }
        }
        public string SpecialtyQueryCols
        {
            get
            {
                return _config.GetSection("DataRepository").GetValue<string>("SpecialtyQueryCols");
            }
        }
    }
}