using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class AlreadyExistsException : Exception
    {
        /// <summary>
        /// Constractor that creates an exception with a specific error message suited to the key that exists and type stored in the list
        /// </summary>
        /// <param name="val">key that already exists</param>
        /// <param name="type">Data type the stored in the list</param>
        public AlreadyExistsException(string val, string type)
            : base(String.Format("The key {0} is already exists as a {1}", val, type))
        { }

        /// <summary>
        /// Constractor that creates an exception with a specific error message
        /// </summary>
        /// <param name="massege">the specific error message</param>
        public AlreadyExistsException(string massege) : base(massege) { }
    }
}
