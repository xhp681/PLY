using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.DataBase
{
    public abstract class DatabaseConfigurationBase<TBuilder, TExtension> : IDatabaseConfiguration<TBuilder, TExtension>
        where TBuilder : RelationalDbContextOptionsBuilder<TBuilder, TExtension>
        where TExtension : RelationalOptionsExtension, new()
    {
        public abstract MultipleDatabaseType MultipleDatabaseType { get; }

        public abstract Action<DbContextOptionsBuilder, string, Action<IRelationalDbContextOptionsBuilderInfrastructure>> SetUseDatabase { get; }

        /// <summary>
        /// 备份数据库方法
        /// <para>如果返回null，则在方法内部完成备份程序</para>
        /// </summary>
        /// <param name="dbConnection"></param>
        /// <param name="backupFilePath"></param>
        /// <returns></returns>
        public abstract string GetBackupDatabaseSql(DbConnection dbConnection, string backupFilePath);
        /// <summary>
        /// 删除指定表Sql
        /// <para>如果返回null，则在方法内部完成删除操作</para>
        /// </summary>
        /// <param name="dbConnection"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public abstract string GetDropTableSql(DbContext dbContext, string tableName);

        public void UseDatabase(DbContextOptionsBuilder builder, string connectionString, Action<IRelationalDbContextOptionsBuilderInfrastructure> dbContextOptionsAction = null)
        {
            SetUseDatabase(builder, connectionString, b => {
                dbContextOptionsAction?.Invoke(b);
            });
        }
    }
}
