using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class DbCommand
    {
        public DbConnection DbConnection { get; set; }

        public DbCommand(DbConnection dbConnection)
        {
            DbConnection = dbConnection;
        }

        public void Execute(string command)
        {
            DbConnection.OpenConnection();
            Console.WriteLine(command);
            DbConnection.CloseConnection();
        }
    }
}
