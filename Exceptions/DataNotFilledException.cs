using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class DataNotFilledException : Exception
    {
        /// <summary>
        /// Constractor that creates an exception with a specific error message suited to the specific empty list
        /// </summary>
        /// <param name="field">the field which is empty</param>
        public DataNotFilledException(string field)
            : base(String.Format("data not filled in {0}", field))
        { }
    }
}
