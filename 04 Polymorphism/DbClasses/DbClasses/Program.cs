using System;

namespace DbClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            //var conn0 = new SqlConnection(""); // throws empty exception
            //Console.WriteLine(conn0.ConnectionString);

            var conn = new SqlConnection("server: test; password: 1234");
            Console.WriteLine($"The connection string is: \"{conn.ConnectionString}\"");
            conn.Open();
            conn.Close();

            var command = new DbCommand(conn, "query the db");
            command.Execute();

            var conn2 = new OracleConnection("server: OracleTest; password: 3456!@#A");
            Console.WriteLine($"The connection string for Oracle is: \"{conn2.ConnectionString}\"");

            var command2 = new DbCommand(conn2, "query the db");
            command2.Execute();


        }
    }
}
