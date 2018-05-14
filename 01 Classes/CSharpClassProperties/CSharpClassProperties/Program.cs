
namespace CSharpClassProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person(new System.DateTime(1977, 9, 9));
            
            System.Console.WriteLine(person.Age);
        }
    }
}
