using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class IncorrectUserNameOrPassword : Exception
    {
        public IncorrectUserNameOrPassword()
            : base("Incorrect user name or password")
        { }
    }
}
