using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2_OOP
{
    class DuplicateObjectException : Exception
    {
        private string name;
        public DuplicateObjectException (string message, string _name) : base(message)
        {
            Name = _name;
        }
        public string Name { get => name; private set => name = value; }
    }
}
