using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.DataBase
{
    public class SQLServerDatabaseConfiguration: DatabaseConfigurationBase<SqlServerDbContextOptionsBuilder, SqlServerOptionsExtension>
    {
        public SQLServerDatabaseConfiguration() { }
        /// <summary>
        /// 指定连接SqlServer数据库
        /// </summary>
        public override MultipleDatabaseType MultipleDatabaseType => MultipleDatabaseType.SqlServer;

        public override string GetBackupDatabaseSql(DbConnection dbConnection, string backupFilePath)
        {
            return $@"Backup Database {dbConnection.Database} To disk='{backupFilePath}'";
        }

        public override string GetDropTableSql(DbContext dbContext, string tableName)
        {
            return $"DROP TABLE {tableName}";
        }
    }
}
