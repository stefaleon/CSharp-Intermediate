using System;

namespace DbClasses
{
    public class DbCommand
    {
        private readonly DbConnection _connection;
        private readonly string _instruction;
        public DbCommand(DbConnection connection, string instruction)
        {
            _connection = connection ?? throw new InvalidOperationException("DbConnection string is null.");
            _instruction = instruction;
        }

        public void Execute()
        {
            _connection.Open();
            Console.WriteLine($"Executing...{_instruction}");
            _connection.Close();
        }
    }
}
