using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.DataBase
{
    public enum MultipleDatabaseType
    {
        SQLite,
        SqlServer,
        MySql,
        InMemory,
        AzureCosmos,
        Oracle,
        PostgreSql,
        Other = 99999,
        Default = SQLite,
    }
}
