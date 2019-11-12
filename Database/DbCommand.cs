using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class DbCommand
    {
        public string Command { get; set; }
        private DbConnection _dbConnection;

        public DbCommand(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void Execute()
        {
            _dbConnection.OpenConnection();
            Console.WriteLine(Command);
            _dbConnection.CloseConnection();
        }
    }
}
