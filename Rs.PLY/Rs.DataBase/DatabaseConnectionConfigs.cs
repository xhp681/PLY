using System;
using System.Collections.Concurrent;
using Rs.Config;

namespace Rs.DataBase
{
    static public class DatabaseConnectionConfigs
    {
        public const string CONFIG_KEY = "_DATABASE_CONNECTION_CONFIG_KEY";
        static public ConcurrentDictionary<string, RsConfig> Configs
        {
            get
            {
                Func<ConcurrentDictionary<string, RsConfig>> func = () =>
                 {
                     ConcurrentDictionary<string, RsConfig> configs = new ConcurrentDictionary<string, RsConfig>();
                     try
                     {

                     }
                     catch (Exception e)
                     {

                         throw;
                     }
                     return configs;
                 };
                //暂时先返回null值，待补充
                return null;
            }
        }
    }
}
