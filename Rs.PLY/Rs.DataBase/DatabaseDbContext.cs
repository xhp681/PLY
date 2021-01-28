using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Rs.DataBase
{
    public abstract class DatabaseDbContext: DbContext, IMultipleMigrationDbContext
    {
        protected DatabaseDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var types = modelBuilder.Model.GetEntityTypes().Where(p => typeof(TEntryBase).IsAssignableFrom(p.ClrType));
            foreach(var entityType in types)
            {
                SetGlobalQueryMethodInfo(entityType, modelBuilder);
            }
            base.OnModelCreating(modelBuilder);

        }

        private void SetGlobalQueryMethodInfo(IMutableEntityType entityType, ModelBuilder modelBuilder)
        {
            var dbContextType = this.GetType();
            dbContextType.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Single(t => t.IsGenericMethod && t.Name == "SetGlobalQuery")
                .MakeGenericMethod(entityType.ClrType)
                .Invoke(this, new object[] { modelBuilder });
        }
    }
}
