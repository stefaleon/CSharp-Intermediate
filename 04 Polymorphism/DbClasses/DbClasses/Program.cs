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

        }
    }
}
