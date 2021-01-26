using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Data.Common;

namespace Rs.DataBase
{
    public interface IDatabaseConfiguration<TBuilder, TExtension> : IDatabaseConfiguration
        where TBuilder : RelationalDbContextOptionsBuilder<TBuilder, TExtension>
        where TExtension : RelationalOptionsExtension, new()
    {

    }

    public interface IDatabaseConfiguration
    {
        /// <summary>
        /// 数据库类型
        /// </summary>
        MultipleDatabaseType MultipleDatabaseType { get; }
        /// <summary>
        /// 备份数据库方法
        /// <para>如果返回null，则在方法内部完成备份程序</para>
        /// </summary>
        /// <param name="dbConnection"></param>
        /// <param name="backupFilePath"></param>
        string GetBackupDatabaseSql(DbConnection dbConnection, string backupFilePath);

        /// <summary>
        /// 删除指定表Sql
        /// <para>如果返回null，则在方法内部完成删除操作</para>
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        string GetDropTableSql(DbContext dbContext, string tableName);
    }
}