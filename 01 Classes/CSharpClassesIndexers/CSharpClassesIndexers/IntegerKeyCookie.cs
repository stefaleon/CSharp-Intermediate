using System.Collections.Generic;

namespace CSharpClassesIndexers
{
    public class IntegerKeyCookie
    // here the key is an int instead of a string
    {
        private readonly Dictionary<int, string> _dictionary
            = new Dictionary<int, string>();
                
        // declare an indexer, using the "this" keyword        
        public string this[int key]
        {
            get { return _dictionary[key]; }
            set { _dictionary[key] = value; }
        }

    }
}
