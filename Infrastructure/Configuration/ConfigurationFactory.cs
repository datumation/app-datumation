using System.Collections.Generic;

namespace Datumation.Infrastructure.Configuration
{
    public class ConfigurationFactory
    {
        private static IAppConfiguration _config;
        //private static Dictionary<string, IGeoServerConfiguration> _geoConfigs;

        // Private constructor to avoid other instantiation
        // This must be present otherwise the compiler provide
        // a default public constructor
        private ConfigurationFactory()
        {
        }

        public IAppConfiguration Configuration()
        {
            return _config;
        }

        //public IGeoServerConfiguration GeoServerConfig(string baseTab)
        //{
        //    return _geoConfigs[baseTab];
        //} 

        /// <summary>
        /// Return an instance
        /// </summary>
        public static ConfigurationFactory Instance
        {
            // An instance of Singleton wont be created until the very first
            // call to the sealed class. This a CLR optimization that ensure that
            // we have properly lazy-loading singleton.
            get
            {
                return SingletonCreator.CreatorInstance;
            }
        }


        /// <summary>
        /// Sealed class to avoid any heritage from this helper class
        /// </summary>
        private sealed class SingletonCreator
        {
            // Retrieve a single instance of a Singleton
            private static readonly ConfigurationFactory _instance = new ConfigurationFactory();

            /// <summary>
            /// Return an instance of the class
            /// </summary>
            public static ConfigurationFactory CreatorInstance
            {
                get { return _instance; }
            }
        }

        public static void Initialize(IAppConfiguration c)
        {
            _config = c;
        }
    }
}