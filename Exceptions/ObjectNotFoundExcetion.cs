using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class ObjectNotFoundExcetion : Exception
    {
        public ObjectNotFoundExcetion(String name, String type)
            : base(String.Format("the name {0} is already exists as a {1}", name, type)) { }
        public ObjectNotFoundExcetion(String message) : base(message) { }
    }
}
