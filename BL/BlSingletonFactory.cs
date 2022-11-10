using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class BlSingletonFactory
    {
        /// <summary>
        /// class of singelton and factory, own one instance of IBL and can return it 
        /// </summary>
        private BlSingletonFactory() { }

        private static IBL bl = null;

        public static IBL getBl_imp()
        {
            if (bl == null)
                bl = new Bl_imp();
            return bl;
        }

    }
}
