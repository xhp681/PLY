﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Rs.Common
{
    public static class ReflectionHelper
    {
        /// <summary>
        /// 创建对象实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fullName">命名空间.类型名</param>
        /// <param name="assemblyName">程序集</param>
        /// <returns></returns>
        public static T CreateInstance<T>(string fullName, string assemblyName)
        {
            string path = fullName + "," + assemblyName;//命名空间.类型名,程序集
            Type o = Type.GetType(path);//加载类型
            object obj = Activator.CreateInstance(o, true);//根据类型创建实例
            return (T)obj;//类型转换并返回
        }

        /// <summary>
        /// 创建对象实例
        /// </summary>
        /// <typeparam name="T">要创建对象的类型</typeparam>
        /// <param name="assemblyName">类型所在程序集名称</param>
        /// <param name="nameSpace">类型所在命名空间</param>
        /// <param name="className">类型名</param>
        /// <param name="recordLog">是否记录日志</param>
        /// <returns></returns>
        public static T CreateInstance<T>(string assemblyName, string nameSpace, string className, bool recordLog = false)
        {
            try
            {
                string fullName = nameSpace + "." + className;//命名空间.类型名
                object ect = Assembly.Load(assemblyName).CreateInstance(fullName);//加载程序集，创建程序集里面的 命名空间.类型名 实例
                return (T)ect;//类型转换并返回
            }
            catch (Exception ex)
            {
                if (recordLog)
                {
                    Log.Exceptions.Error(ex.Message);
                }                
                return default(T);
            }
        }

        /// <summary>
        /// 获取静态类属性
        /// </summary>
        /// <param name="assemblyName">类型所在程序集名称</param>
        /// <param name="nameSpace">类型所在命名空间</param>
        /// <param name="className">类型名</param>
        /// <param name="memberName">属性名称（忽略大小写）</param>
        /// <param name="recordLog">是否记录日志</param>
        /// <returns></returns>
        public static object GetStaticMember(string assemblyName, string nameSpace, string className, string memberName, bool recordLog = false)
        {
            try
            {
                string fullName = nameSpace + "." + className;//命名空间.类型名
                string path = fullName + "," + assemblyName;//命名空间.类型名,程序集
                var type = Type.GetType(path);
                PropertyInfo[] props = type.GetProperties();
                var prop = props.FirstOrDefault(z => z.Name.Equals(memberName, StringComparison.OrdinalIgnoreCase));
                return prop.GetValue(null, null);
            }
            catch (Exception ex)
            {
                if (recordLog)
                {
                    Log.Exceptions.Error(ex.Message);
                }
                return null;
            }
        }

        /// <summary>
        /// 获取静态类属性
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="memberName">属性名称（忽略大小写）</param>
        /// <param name="recordLog">是否记录日志</param>
        /// <returns></returns>
        public static object GetStaticMember(Type type, string memberName, bool recordLog = false)
        {
            try
            {
                PropertyInfo[] props = type.GetProperties();
                var prop = props.FirstOrDefault(z => z.Name.Equals(memberName, StringComparison.OrdinalIgnoreCase));
                return prop.GetValue(null, null);
            }
            catch (Exception ex)
            {
                if (recordLog)
                {
                    Log.Exceptions.Error(ex.Message);
                }
                return null;
            }
        }
    }
}
