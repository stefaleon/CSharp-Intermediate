using System;
using System.Collections.Generic;

namespace CSharpClassesIndexers
{
    public class CustomCookie
    // set the CustomCookie class to have the indexer functionality
    // it is actually a wrapper to the dictionary functionality
    // with the ability to have additional properties such as Expiry
    {
        private readonly Dictionary<string, string> _dictionary;
        public DateTime Expiry { get; set; }

        //initialize _dictionary in a constructor
        public CustomCookie()
        {
            _dictionary = new Dictionary<string, string>();              
        }

        //the above could also be initialized directly upon declaration, like
        // private Dictionary<string, string> _dictionary = new Dictionary<string, string>();

        // declare an indexer, using the "this" keyword        
        public string this[string key]
        {
            get { return _dictionary[key]; }
            set { _dictionary[key] = value; }
        }

    }
}
