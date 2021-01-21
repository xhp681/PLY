using System;
using Rs.Common;

namespace Rs.Cache
{
    public class BaseException:Exception
    {
        /// <summary>
        /// BaseException 构造函数
        /// </summary>
        /// <param name="message"></param>
        /// <param name="logged"></param>
        public BaseException(string message, bool logged = false)
            : this(message, null, logged)
        {
        }

        /// <summary>
        /// BaseException
        /// </summary>
        /// <param name="message">异常消息</param>
        /// <param name="inner">内部异常信息</param>
        /// <param name="logged">是否已经使用WeixinTrace记录日志，如果没有，BaseException会进行概要记录</param>
        public BaseException(string message, Exception inner, bool logged = false)
            : base(message, inner)
        {
            if (!logged)
            {
                Log.Exceptions.Error(this);
            }
        }
    }
}