using System;

namespace Rs.Cache
{
    public interface IDomainExtensionCacheStrategy
    {
        /// <summary>
        /// 领域缓存定义
        /// </summary>
        ICacheStrategyDomain CacheStrategyDomain { get; }

        /// <summary>
        /// 使用的基础缓存策略
        /// </summary>
        Func<IBaseObjectCacheStrategy> BaseCacheStrategy { get; }

        /// <summary>
        /// 向底层缓存注册当前缓存策略
        /// </summary>
        /// <param name="extensionCacheStrategy">扩展缓存策略实例</param>
        void RegisterCacheStrategyDomain(IDomainExtensionCacheStrategy extensionCacheStrategy);
    }
}