using System;

namespace Rs.Cache
{
    /// <summary>
    /// 缓存类型
    /// </summary>
    public enum CacheType
    {
        /// <summary>
        /// 本地运行时缓存
        /// </summary>
        Local=0,
        /// <summary>
        /// Rddis缓存，支持分布式
        /// </summary>
        Redis=1,
        /// <summary>
        /// Memcached缓存，支持分布式
        /// </summary>
        Memcached=2
    }
}
