using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public static class Options
    {
        public static void ShowOptions()
        {
            Console.WriteLine("\nHere are the list of options below: \n");
            Console.WriteLine("create - to create a new connection");
            Console.WriteLine("connect - to open connection to current database");
            Console.WriteLine("disconnect - to close connection to the database");
            Console.WriteLine("instance - to go to database instance choice.");
        }

        public static void InstanceOptions()
        {
            Console.WriteLine("\nPlease choose an instance: \n");
            Console.WriteLine("sql - to choose sql database connection.");
            Console.WriteLine("oracle - to choose oracle database connection.");
            Console.WriteLine("close - to close an application");
            Console.Write("\nInstance: ");
        }

        public static string InstanceLeave()
        {
            System.Threading.Thread.Sleep(500);
            Console.Write(".");
            System.Threading.Thread.Sleep(500);
            Console.Write(".");
            System.Threading.Thread.Sleep(500);

            return "instance-leave";
        }

        public static string UserChoice()
        {
            Console.Write("\nWhat we gonna do? ");
            string input = Console.ReadLine();
            Console.WriteLine();

            return input;
        }
    }
}
