using System;

namespace CSharpClassesIndexers
{
    class Program
    {
        static void Main(string[] args)
        {
            var myCookie = new CustomCookie();
            myCookie["name"] = "Nikos Koukos";
            myCookie.Expiry = DateTime.Now.AddDays(5);
            Console.WriteLine(myCookie["name"]);
            Console.WriteLine(myCookie.Expiry.Date);

            var myIntKeyCookie = new IntegerKeyCookie();
            myIntKeyCookie[123] = "EkatonEikosiTria";
            Console.WriteLine(myIntKeyCookie[123]);
        }
    }
}
