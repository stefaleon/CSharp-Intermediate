using System;
using System.Collections.Generic;

namespace Stack
{
    public class Stack
    {
        //private ArrayList _storedObjects = new ArrayList(); // ArrayList works but it is becoming deprecated
        private List<object> _storedObjects = new List<object>();               

        public void Push(object obj)
        {
            if (obj == null)
            {
                throw new InvalidOperationException("Cannot add a null object.");
            }
            
             _storedObjects.Add(obj);
                        
        }

        public object Pop()
        {
            if (_storedObjects.Count == 0)
            {
                throw new InvalidOperationException("Cannot pop from empty.");               
            }

            int lastIndex = _storedObjects.Count - 1;
            object obj = _storedObjects[lastIndex];
            _storedObjects.RemoveAt(lastIndex);

            return obj;
        }

        public void Clear()
        {
            _storedObjects.Clear();
        }
    }
}
