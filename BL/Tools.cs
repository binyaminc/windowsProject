using System;
using System.Collections.Generic;
using System.Text;
using BE;
using DAL;
using Exceptions;

namespace BL
{

    public static class Tools
    {
        /// <summary>
        /// Extention method to GuestRequest, determines if a date is in the GR range
        /// </summary>
        /// <param name="gr">the gusetRequst to check on</param>
        /// <param name="month">the checked month</param>
        /// <param name="day">the checked day</param>
        /// <returns>if the month and day are in the GR range</returns>
        public static bool inRange(this GuestRequest gr, int month, int day)
        {
            month++; day++;//to make the range of the days and months as same as the range of dateTime

            if (((month - gr.EntryDate.Month) < 0) || ((month - gr.ReleaseDate.Month) > 0))//if our month isn't in the range of the dateTimes
                return false;
            if (((month - gr.EntryDate.Month) == 0) && ((day - gr.EntryDate.Day) < 0))//if the month is the first and the day is earlier
                return false;
            if (((month - gr.ReleaseDate.Month) == 0) && ((day - gr.ReleaseDate.Day) > 0))//if the month is the last and the day is later
                return false;

            return true;
        }
        
        
        /// <summary>
        /// get the GR of the order, using the GuestRequestKey
        /// </summary>
        /// <param name="order">the order to get the GR from</param>
        /// <returns>the GR of the order</returns>
        public static GuestRequest getGuestRequest(this Order order)
        {
            GuestRequest guestRequest = null;
            /*
            foreach (GuestRequest gr in (DalSingletonFactory.getDal_imp()).GetGuestRequests())
            {
                if (gr.GuestRequestKey == order.GuestRequestKey)
                    guestRequest = gr;
            }*/
            guestRequest = (DalSingletonFactory.getDal_imp()).GetGuestRequests().Find(gr => gr.GuestRequestKey == order.GuestRequestKey);

            return guestRequest;
        }
        
        
        /// <summary>
        /// get the HU of the order, using the HostingUnitKey
        /// </summary>
        /// <param name="order">the order to get the HU from</param>
        /// <returns>the HU of the order</returns>
        public static HostingUnit GetHostingUnit(this Order order)
        {
            HostingUnit hostingUnit = null;
            /*foreach (HostingUnit hu in (DalSingletonFactory.getDal_imp()).GetHostingUnits())
            {
                if (hu.HostingUnitKey == order.HostingUnitKey)
                    hostingUnit = hu;
            }*/
            hostingUnit = (DalSingletonFactory.getDal_imp()).GetHostingUnits().Find(hu => hu.HostingUnitKey == order.HostingUnitKey);
            return hostingUnit;
        }
       
        
        /// <summary>
        /// get the owner of the hostingUnit of the order
        /// </summary>
        /// <param name="order">the order to get the data from</param>
        /// <returns>the owner of the HU</returns>
        public static Host getHost(this Order order)
        {
            return order.GetHostingUnit().Owner;
        }
        
        
        /// <summary>
        /// find the HU amount of a host
        /// </summary>
        /// <param name="host">the host to check</param>
        /// <returns>the HU amount of a host</returns>
        public static int getHUAmount(this Host host)
        {
            /*
            int i = 0;
            foreach (HostingUnit hu in (DalSingletonFactory.getDal_imp()).GetHostingUnits())
                if (hu.Owner.HostKey == host.HostKey)
                    i++;
           return i;
           */

            return (DalSingletonFactory.getDal_imp()).GetHostingUnits().FindAll(hu => hu.Owner.HostKey == host.HostKey).Count;
        }
        
        
        /// <summary>
        /// change the order status only if not closed
        /// </summary>
        /// <param name="order">the order to change</param>
        /// <param name="status">the status to set</param>
        public static void setStatus(this Order order, MyOrder status)
        {
            if (order.Status != MyOrder.ClosedByCustomer && order.Status != MyOrder.ClosedCustomerUnavailability)
            {
                order.Status = status;
                try
                {
                    (DalSingletonFactory.getDal_imp()).UpdateOrder(order);
                }
                catch (ObjectNotFoundExcetion onfe)
                {
                    throw onfe;
                }
            }
            else
                throw new InvalidOperationException("can't change status of closed deal");
        }
    }
}
