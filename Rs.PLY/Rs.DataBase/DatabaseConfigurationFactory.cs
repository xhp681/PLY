using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.DataBase
{
    public class DatabaseConfigurationFactory
    {
        #region 单例

        DatabaseConfigurationFactory() { }

        /// <summary>
        /// DatabaseConfigurationFactory 的全局单例
        /// </summary>
        public static DatabaseConfigurationFactory Instance
        {
            get
            {
                return Nested.instance;
            }
        }

        class Nested
        {
            static Nested() { }

            internal static readonly DatabaseConfigurationFactory instance = new DatabaseConfigurationFactory();
        }

        #endregion

        //TODO:如果是分布式，需要存储到缓存中

        private IDatabaseConfiguration _currentDatabaseConfiguration;

        public IDatabaseConfiguration Current
        {
            get
            {
                if (_currentDatabaseConfiguration == null)
                {
                    throw new Exception("未指定 DatabaseConfiguration！");
                }
                return _currentDatabaseConfiguration;
            }
            set
            {
                _currentDatabaseConfiguration = value;
            }
        }
    }
}
