using Rs.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.Config
{
    /// <summary>
    /// 系统全局变量配置
    /// </summary>
    public class SiteSetting
    {
        /// <summary>
        /// 是否预览系统
        /// </summary>
        public bool IsRcSite { get; set; }
        /// <summary>
        /// 连接数据库名称
        /// </summary>
        public string DatabaseName { get; set; }
        /// <summary>
        /// 缓存类型
        /// </summary>
        public CacheType CacheType { get; set; }
        public string MemcachedAddresses { get; set; }
    }
}
