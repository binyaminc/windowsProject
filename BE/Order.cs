using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BE
{
     public class Order
    {
        private int hostingUnitKey;
        private int guestRequestKey;
        private int orderKey;
        private MyOrder status;
        private DateTime createDate;
        //private DateTime orderDate;
        private double commission;
        private DateTime sentMailDate;


        public int HostingUnitKey { get => hostingUnitKey; set => hostingUnitKey = value; }
        public int GuestRequestKey { get => guestRequestKey; set => guestRequestKey = value; }
        public int OrderKey { get => orderKey; set => orderKey = value; }
        public MyOrder Status { get => status; set => status = value; }
        public DateTime CreateDate { get => createDate; set => createDate = value; }
        //public DateTime OrderDate { get => orderDate; set => orderDate = value; }
        public double Commission { get => commission; set => commission = value; }
        public DateTime SentMailDate { get => sentMailDate; set => sentMailDate = value; }

        public override string ToString()
        {
            string result = "HostingUnitKey: " + HostingUnitKey.ToString()
                + " GuestRequestKey: " + GuestRequestKey.ToString()
                + " OrderKey: " + OrderKey.ToString()
                + " Status: " + Status.ToString()
                + " CreateDate: " + CreateDate.ToString();
//                + " OrderDate: " + OrderDate.ToString();
            return result;


        }

    }
}
