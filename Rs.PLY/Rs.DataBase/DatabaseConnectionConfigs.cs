using System;
using System.Collections.Concurrent;
using Rs.Cache;
using Rs.Common;
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
                ConcurrentDictionary<string, RsConfig> configs = new ConcurrentDictionary<string, RsConfig>();
                try
                {
                    XmlDataContext xmlCtx = new XmlDataContext(SiteConfig.ConfigDirctor);
                    var list = xmlCtx.GetXmlList<RsConfig>();
                    list.ForEach(p => configs[p.Name] = p);
                }
                catch (Exception e)
                {
                    Log.WebLogger.Error($"Rs.Config读取错误:{e.Message}", e);
                }
                return configs;
            }
        }
    }
}
