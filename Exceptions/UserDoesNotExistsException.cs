using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class UserDoesNotExistsException : Exception
    {

        public UserDoesNotExistsException(string user)
             : base(String.Format("the user {0} does not exist", user))
        { }

    }
}
