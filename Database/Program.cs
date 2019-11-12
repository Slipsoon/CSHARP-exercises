using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    class Program
    {
        static void Main(string[] args)
        {
            var oracleDB = new OracleConnection("initialConnection");
            var sqlDB = new SqlConnection("initialConnection");
            var dbCommand = new DbCommand(null);
            string sqlConnectionString = null;
            string oracleConnectionString = null;
            string input = null;
            string instance = null;


            while (instance != "close")
            {
                if (instance == null)
                {
                    Console.Clear();
                    Console.WriteLine("Welcome to Database connection tool!");
                    Options.InstanceOptions();
                    instance = Console.ReadLine();
                }

                switch (instance)
                {
                    case "sql":
                        Console.Clear();
                        Console.WriteLine("Connected to sql instance!");

                        dbCommand = new DbCommand(sqlDB);
                        Options.ShowOptions();
                        input = Options.UserChoice();

                        while (input != "instance-leave")
                        {

                            switch (input)
                            {
                                case "create":
                                    if (sqlConnectionString != null)
                                        sqlDB.CloseConnection();

                                    Console.WriteLine("Creating a new {0} connection: \n", instance);

                                    Console.Write("Please enter the database connection string: ");
                                    sqlConnectionString = Console.ReadLine();

                                    sqlDB = new SqlConnection(sqlConnectionString);
                                    Console.WriteLine("Your database connection has been created!");
                                    input = Options.UserChoice();
                                    break;

                                case "connect":
                                    if (sqlConnectionString == null)
                                        sqlDB = new SqlConnection(null);

                                    sqlDB.OpenConnection();
                                    input = Options.UserChoice();
                                    break;

                                case "disconnect":
                                    sqlDB.CloseConnection();
                                    input = Options.UserChoice();
                                    break;

                                case "instance":
                                    sqlDB.CloseConnection();
                                    Console.Write("Disconnecting {0} instance.",instance);
                                    instance = null;
                                    input = Options.InstanceLeave();
                                    break;

                                case "command":
                                    if (sqlConnectionString == null)
                                        sqlDB = new SqlConnection(null);

                                    instance = "command";
                                    input = "instance-leave";
                                    break;

                                default:
                                    Options.ShowOptions();
                                    input = Options.UserChoice();
                                    break;
                            }
                        }
                        break;

                    case "oracle":
                        Console.Clear();
                        Console.WriteLine("Connected to oracle instance!");
                        dbCommand = new DbCommand(oracleDB);
                        Options.ShowOptions();
                        input = Options.UserChoice();

                        while (input != "instance-leave")
                            switch (input)
                            {
                            case "create":
                                if (oracleConnectionString != null)
                                    oracleDB.CloseConnection();

                                Console.WriteLine("Creating a new {0} connection: \n",instance);

                                Console.Write("Please enter the database connection string: ");
                                oracleConnectionString = Console.ReadLine();

                                oracleDB = new OracleConnection(oracleConnectionString);
                                Console.WriteLine("Your database connection has been created!");
                                input = Options.UserChoice();
                                break;

                            case "connect":
                                if (oracleConnectionString == null)
                                    oracleDB = new OracleConnection(null);

                                oracleDB.OpenConnection();
                                input = Options.UserChoice();
                                break;

                            case "disconnect":
                                oracleDB.CloseConnection();
                                input = Options.UserChoice();
                                break;

                            case "instance":
                                oracleDB.CloseConnection();
                                Console.Write("Disconnecting {0} instance.",instance);
                                instance = null;
                                input = Options.InstanceLeave();
                                break;

                            case "command":
                                 if (oracleConnectionString == null)
                                    oracleDB = new OracleConnection(null);

                                 instance = "command";
                                 input = "instance-leave";
                                 break;

                                default:
                                Options.ShowOptions();
                                input = Options.UserChoice();
                                break;
                            }
                    break;

                    case "command":
                        Console.Clear();
                        Options.CommandOptions();

                        Console.Write("\nCommand option: ");
                        input = Console.ReadLine();

                        while (input != "instance-leave")
                        {
                            switch (input)
                            {
                                case "select":
                                    dbCommand.Command = "\nSelecting data from database... OK!";
                                    dbCommand.Execute();
                                    input = Options.UserChoice();
                                    break;

                                case "delete":
                                    dbCommand.Command = "\nDeleting data from database... OK!";
                                    dbCommand.Execute();
                                    input = Options.UserChoice();
                                    break;

                                case "insert":
                                    dbCommand.Command = "\nInserting some data to database... OK!";
                                    dbCommand.Execute();
                                    input = Options.UserChoice();
                                    break;

                                case "instance":
                                    instance = null;
                                    input = "instance-leave";
                                    break;

                                default:
                                    Options.CommandOptions();
                                    input = Options.UserChoice();
                                    break;
                            }
                        }
                        break;

                    case "close":
                        Console.WriteLine("\nClosing an application..");
                        break;

                    default:
                        Options.InstanceOptions();
                        break;
                }
            }
        }
    }
}
