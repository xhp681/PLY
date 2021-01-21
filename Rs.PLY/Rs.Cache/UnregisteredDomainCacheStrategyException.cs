using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rs.Common;

namespace Rs.Cache
{
    public class UnregisteredDomainCacheStrategyException:CacheException
    {
        public UnregisteredDomainCacheStrategyException(Type domainCacheStrategyType, Type objectCacheStrategyType)
            : base($"当前扩展缓存策略没有进行注册：{domainCacheStrategyType.ToString()}，{objectCacheStrategyType.ToString()}，请联系管理人员527883283@qq.com", null, true)
        {
            Log.Exceptions.Error($"当前扩展缓存策略没有进行注册，CacheStrategyDomain：{domainCacheStrategyType.ToString()}，IBaseObjectCacheStrategy：{objectCacheStrategyType.ToString()}");
        }
    }
}
