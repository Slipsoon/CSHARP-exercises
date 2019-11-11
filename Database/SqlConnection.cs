using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class SqlConnection : DbConnection
    {
        private bool _connectionStatus;

        public SqlConnection(string dbConnection)
            : base(dbConnection)
        {

        }

        public override void OpenConnection()
        {
            Console.WriteLine("\nConnecting... ");

            if (_connectionStatus)
            {
                Console.Write("Could not connect to database. There is another opened connection!\n");
            }
            else
            {
                _connectionStatus = !_connectionStatus;
                Console.Write("Database connection successfuly!\n");
            }
        }

        public override void CloseConnection()
        {
            if (_connectionStatus)
            {
                _connectionStatus = !_connectionStatus;
                Console.WriteLine("Disconnecting...\n You have been disconnected from database!\n");
            }
            else
            {
                Console.WriteLine("There is no open connection need to be closed.");
            }
        }
    }
}
