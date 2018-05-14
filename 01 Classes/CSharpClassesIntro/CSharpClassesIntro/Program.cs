using System;

namespace CSharpClassesIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Person();
            p1.Name = "Peter";
            p1.Introduce("John");

            var p2 = Person.Parse("Paul");
            p2.Introduce("Mary");

        }
    }

    public class Person {
        public string Name { get; set; }

        public void Introduce(string to) {
            Console.WriteLine($"Hi {to}, I 'm {Name}.");
        }

        // The "Parse" class member is method that returns a Person object with a Name of str
        // It is declared static so that it can be used without instantiating a Person in advance 
        // (otherwise it makes no sense)
        public static Person Parse(string str)
        {
            var person = new Person();
            person.Name = str;
            return person;
        }
    }

    
}
