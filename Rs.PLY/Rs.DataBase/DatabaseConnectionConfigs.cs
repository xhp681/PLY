using System;
using System.Collections.Concurrent;
using Rs.Cache;
using Rs.Common;
using Rs.Config;

namespace Rs.DataBase
{
    static public class DatabaseConnectionConfigs
    {
        //public const string CONFIG_KEY = "_DATABASE_CONNECTION_CONFIG_KEY";
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

        public static string ClientConnectionString
        {
            get
            {
                var databaseName = GetFullDatabaseName(SiteConfig.SiteSetting.DatabaseName ?? "Client");

                if (DatabaseConnectionConfigs.Configs != null && DatabaseConnectionConfigs.Configs.ContainsKey(databaseName))
                {
                    return DatabaseConnectionConfigs.Configs[databaseName].ConnectionStringFull;
                }
                else
                {
                    throw new Exception($"无法找到数据库配置：{databaseName}，请在 RsConfig.config 中进行配置");
                }
            }
        }

        /// <summary>
        /// 获取完整名称
        /// </summary>
        /// <param name="databaseName"></param>
        /// <returns></returns>
        public static string GetFullDatabaseName(string databaseName)
        {
            var currentDatabaseType = DatabaseConfigurationFactory.Instance.Current.MultipleDatabaseType;
            var fullDatabaseName = $"{databaseName}-{currentDatabaseType}";
            return fullDatabaseName;
        }
    }
}
