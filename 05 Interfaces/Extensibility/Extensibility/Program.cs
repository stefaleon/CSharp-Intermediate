namespace Extensibility
{
    class Program
    {
        static void Main(string[] args)
        {            
            var migrator1 = new DbMigrator(new ConsoleLogger());
            migrator1.Migrate();

            var migrator2 = new DbMigrator(new FileLogger(@"C:\test\log.txt"));
            migrator2.Migrate();
        }
    }
}
