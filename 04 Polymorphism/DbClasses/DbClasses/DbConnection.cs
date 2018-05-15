using System;

namespace DbClasses
{
    public abstract class DbConnection
    {
        public string ConnectionString { get; set; }
        public TimeSpan TimeOut { get; set; }

        public DbConnection(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("Connection string is null or empty.");
            }

            ConnectionString = connectionString;
        }

        public abstract void Open();
        public abstract void Close();
    }
}
