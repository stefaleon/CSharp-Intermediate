using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositionExample
{
    partial class Program
    {
        static void Main(string[] args)
        {
            //The Logger class is the related class in this example
            //It is given as a parameter to the constructors of both composite classes, DbMigrator and Installer
            //so we need to give a new Logger object as a parameter on each of the object instantiations here as well 
            var dbMigrator = new DbMigrator(new Logger());
            var installer = new Installer(new Logger());

            dbMigrator.Migrate(); // logs a message from dbMigrator
            installer.Install(); // logs a message from installer
        }
    }
}
