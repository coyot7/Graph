using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Aplikacja
{
    class InvalidOptionException : Exception
    {
        public InvalidOptionException(string message)
            : base("Error: " + message) { }

        public InvalidOptionException(string message, StreamReader sr)
            : base("Error: " + message) { sr.Close(); }
    }
}
