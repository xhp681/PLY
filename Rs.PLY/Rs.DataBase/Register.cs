﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Rs.DataBase
{
    public static class Register
    {
        /// <summary>
        /// 使用指定数据库
        /// </summary>
        /// <typeparam name="TDatabaseConfiguration"></typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddDatabase<TDatabaseConfiguration>(this IServiceCollection services)
                where TDatabaseConfiguration : IDatabaseConfiguration, new()
        {
            DatabaseConfigurationFactory.Instance.Current = new TDatabaseConfiguration();
            return services;
        }

        /// <summary>
        /// 使用指定数据库
        /// </summary>
        /// <param name="services"></param>
        /// <param name="databaseConfigurationType"></param>
        /// <returns></returns>
        public static IServiceCollection AddDatabase(this IServiceCollection services, Type databaseConfigurationType)
        {
            //必须实现 IDatabaseConfiguration 接口的类型才能进行下一步配置
            if (typeof(IDatabaseConfiguration).IsAssignableFrom(databaseConfigurationType))
            {
                throw new Exception($"类型{databaseConfigurationType.Name} 必须实现接口：IDatabaseConfiguration");
            }

            var databaseConfiguration = Activator.CreateInstance(databaseConfigurationType, true) as IDatabaseConfiguration;

            DatabaseConfigurationFactory.Instance.Current = databaseConfiguration;
            return services;
        }

        /// <summary>
        /// 使用指定数据库
        /// </summary>
        /// <param name="services"></param>
        /// <param name="databaseConfiguration"></param>
        /// <returns></returns>
        public static IServiceCollection AddDatabase(this IServiceCollection services, IDatabaseConfiguration databaseConfiguration)
        {
            //必须实现 IDatabaseConfiguration 接口的类型才能进行下一步配置
            if (databaseConfiguration == null)
            {
                throw new Exception($"{nameof(databaseConfiguration)} 参数不能为 null");
            }

            DatabaseConfigurationFactory.Instance.Current = databaseConfiguration;
            return services;
        }

        /// <summary>
        /// 使用指定数据库
        /// </summary>
        /// <param name="services"></param>
        /// <param name="assemblyName">DatabaseConfiguration 程序集名称</param>
        /// <param name="nameSpace">DatabaseConfiguration 命名空间</param>
        /// <param name="className">DatabaseConfiguration 类名</param>
        /// <returns></returns>
        public static IServiceCollection AddDatabase(this IServiceCollection services, string assemblyName, string nameSpace, string className)
        {
            //TODO:集成到 CO2NET
            string fullName = nameSpace + "." + className;//命名空间.类型名
            var databaseConfiguration = Assembly.Load(assemblyName).CreateInstance(fullName) as IDatabaseConfiguration;//加载程序集，创建程序集里面的 命名空间.类型名 实例
            return services.AddDatabase(databaseConfiguration);
        }
    }
}
