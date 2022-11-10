using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Configuration
    {
        private static int idalKey = 0;
        private static int hostingUnitKey = 0;
        private static int guestRequestKey = 0;
        private static int orderKey = 0;
        private static int hostKey = 0;
        private static double commission = 10;

        public static int IdalKey { get => idalKey++; set => idalKey = value; }
        public static int HostingUnitKey { get => hostingUnitKey++; set => hostingUnitKey = value; }
        public static int GuestRequestKey { get => guestRequestKey++; set => guestRequestKey = value; }
        //public static int ReadGuestRequestKey { get => guestRequestKey; set => guestRequestKey = value; }

        public static int OrderKey { get => orderKey++; set => orderKey = value; }
        public static int HostKey { get => hostKey++; set => hostKey = value; }
        public static double Commission { get => commission; set => commission = value; }
    }
}
