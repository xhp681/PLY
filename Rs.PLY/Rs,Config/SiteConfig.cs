using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Rs.Cache;

namespace Rs.Config
{
    public static partial class SiteConfig
    {
        public static string ApplicationPath { get; set; }
        public static string WebRootPath { get; set; }
        /// <summary>
        /// 在系统启动时注入的配置
        /// </summary>
        public static SiteSetting SiteSetting { get; set; } = new SiteSetting();
        /// <summary>
        /// 缓存类型
        /// </summary>
        public static CacheType CacheType
        {
            get => SiteSetting.CacheType;
            set => SiteSetting.CacheType = value;
        }
        public const string VERSION = "0.0.1";
        public static string ConfigDirctor = "~/App_Data/DataBase";
        public const int DEFAULT_MEMCACHED_PORT = 1120;
        /// <summary>
        /// 网站启动后前台页面浏览器
        /// </summary>
        public static int PageViewCount { get; set; }
        /// <summary>
        /// 异步线程（后台运行线程）
        /// </summary>
        public static Dictionary<string, Thread> AsynThread = new Dictionary<string, Thread>();
    }
}
