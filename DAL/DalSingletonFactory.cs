using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// class of singelton and factory, own one instance of Idal and can return it 
    /// </summary>
    public class DalSingletonFactory
    {
        private DalSingletonFactory() { }

        private static Idal dal = null;
        /// <summary>
        /// return the instance of Idal, if doesn't exist create one and return it
        /// </summary>
        /// <returns></returns>
        public static Idal getDal_imp()
        {
            if (dal == null)
                dal = new Dal_XML_imp();
            return dal;
        }

    }
}
