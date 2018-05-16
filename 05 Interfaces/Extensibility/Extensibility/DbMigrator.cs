using System;
using System.Threading;

namespace Extensibility
{
    public class DbMigrator
    {
        private readonly ILogger _logger;
        public DbMigrator(ILogger logger)
        {
            _logger = logger;
        }


        public void Migrate()
        {
            // log start
            _logger.LogInfo($"Migration started at {DateTime.Now}");

            // migrate a db ...
            // simulate with a 3 secs delay
            Console.WriteLine("Migrating... wait 3 secs");
            Thread.Sleep(3000);

            // log finish
            _logger.LogInfo($"Migration finished at {DateTime.Now}");
        }
    }
}
