using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.Common
{
    public class Utils
    {
        private static string _rootDictionaryPath = null;
        /// <summary>
        /// 项目根目录
        /// </summary>
        public static string AppDomainAppPath { get; set; }
        /// <summary>
        /// 网站根目录绝对路径
        /// </summary>
        public static string RootDictionaryPath {
            get { 
                if(_rootDictionaryPath==null)
                    _rootDictionaryPath= AppContext.BaseDirectory;
                return _rootDictionaryPath;
            } 
            set { _rootDictionaryPath = value;  }
        }
        public static string ContentRootMapPath(string virtualPath)
        {
            if (virtualPath == null)
            {
                return "";
            }
            else
            {
                var path = Path.DirectorySeparatorChar.ToString();
                var altPath = Path.AltDirectorySeparatorChar.ToString();
                if (!RootDictionaryPath.EndsWith(path) && !RootDictionaryPath.EndsWith(altPath))
                {
                    RootDictionaryPath += path;
                }

                if (virtualPath.StartsWith("~/"))
                {
                    return virtualPath.Replace("~/", RootDictionaryPath).Replace("/", path);
                }
                else
                {
                    return Path.Combine(RootDictionaryPath, virtualPath);
                }
            }
        }
        public static string DllMapPath(string virtualPath)
        {
            if (virtualPath == null)
            {
                return "";
            }
            else if (virtualPath.StartsWith("~/"))
            {
                var pathSeparator = Path.DirectorySeparatorChar.ToString();
                return virtualPath.Replace("~/", AppDomainAppPath).Replace("/", pathSeparator);
            }
            else
            {
                return Path.Combine(AppDomainAppPath, virtualPath);
            }
        }
    }
}
