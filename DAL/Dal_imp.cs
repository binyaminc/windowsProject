using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;
using Exceptions;

namespace DAL
{
    class Dal_imp : Idal
    {
        #region add element
        
        /// <summary>
        /// Add GuestReuest to the database
        /// </summary>
        /// <param name="GuestRequest"> the GR to add</param>
        public void AddGuestReuest(GuestRequest GuestRequest)
        {
            if (!(DataSource.guestRequests.Contains(GuestRequest)))
                DataSource.guestRequests.Add(GuestRequest.Clone());
            else
                throw new AlreadyExistsException(GuestRequest.PrivateName, "GuestRequest");
        }

        /// <summary>
        /// Add HostingUnit to the database
        /// </summary>
        /// <param name="HostingUnit">the HU to add</param>
        public void AddHostingUnit(HostingUnit HostingUnit)
        {
            if (!(DataSource.hostingUnits.Contains(HostingUnit)))
                DataSource.hostingUnits.Add(HostingUnit.Clone());
            else
                throw new AlreadyExistsException(HostingUnit.HostingUnitName, "HostingUnit");
        }

        /// <summary>
        /// Add Host to the database
        /// </summary>
        /// <param name="Host">the Host to add</param>
        public void AddHost(Host host)
        {
            if (!(DataSource.hosts.Contains(host)))
                DataSource.hosts.Add(host.Clone());
            else
                throw new AlreadyExistsException(host.PrivateName, "Host");
        }

        /// <summary>
        /// Add order to the database
        /// </summary>
        /// <param name="Order">The order to add</param>
        public void AddOrder(Order Order)
        {
            if (!(DataSource.orders.Contains(Order)))
                DataSource.orders.Add(Order.Clone());
            else
                throw new AlreadyExistsException((Order.OrderKey).ToString(), "Order");
        }
        #endregion

        #region update element

        /// <summary>
        /// Update GuestReuest in the database
        /// </summary>
        /// <param name="GuestRequest">the GR to update</param>
        public void UpdateGuestRequest(GuestRequest GuestRequest)
        {
            var v = from gr in DataSource.guestRequests
                      where gr.GuestRequestKey != GuestRequest.GuestRequestKey
                      select gr;
            List<GuestRequest> list = new List<GuestRequest>();
            foreach(GuestRequest gr in v)
            {
                list.Add(gr);
            }
            if (list.Count == DataSource.guestRequests.Count)//there is no such GR in the DataSource
                throw new ObjectNotFoundExcetion(GuestRequest.PrivateName, "GuestRequest");

            list.Add(GuestRequest.Clone());
            DataSource.guestRequests = list;
        }

        /// <summary>
        /// Update HostingUnit in the database
        /// </summary>
        /// <param name="HostingUnit">The HU to update</param>
        public void UpdateHostingUnit(HostingUnit HostingUnit)
        {
            var v = from hu in DataSource.hostingUnits
                      where hu.HostingUnitKey != HostingUnit.HostingUnitKey
                      select hu;
            List<HostingUnit> list = new List<HostingUnit>();
            foreach(HostingUnit hu in v)
            {
                list.Add(hu);
            }

            if (list.Count == DataSource.hostingUnits.Count)//there is no such HU in the DataSource
                throw new ObjectNotFoundExcetion(HostingUnit.HostingUnitName, "HostingUnit");

            list.Add(HostingUnit.Clone());
            DataSource.hostingUnits = list;
        }

        /// <summary>
        /// Update Host in the database
        /// </summary>
        /// <param name="HostingUnit">The host to update</param>
        public void UpdateHost(Host host)
        {
            var v = from h in DataSource.hosts
                    where h.HostKey != host.HostKey
                    select h;
            List<Host> list = new List<Host>();
            foreach (Host h in v)
            {
                list.Add(h);
            }

            if (list.Count == DataSource.hosts.Count)//there is no such Host in the DataSource
                throw new ObjectNotFoundExcetion(host.PrivateName, "Host");

            list.Add(host.Clone());
            DataSource.hosts = list;
        }

        /// <summary>
        /// Update order in the database
        /// </summary>
        /// <param name="Order">The order to update</param>
        public void UpdateOrder(Order Order)
        {
            var v = from or in DataSource.orders
                      where or.OrderKey != Order.OrderKey
                      select or;
            List<Order> list = new List<Order>();
            foreach (Order or in v)
            {
                list.Add(or);
            }

            if (list.Count == DataSource.orders.Count)//there is no such order in the DataSource
                throw new ObjectNotFoundExcetion((Order.OrderKey).ToString(), "Order");

            list.Add(Order.Clone());
            DataSource.orders = list;
        }
        #endregion

        #region delete object
        
        /// <summary>
        /// Delete HostingUnit frome the database
        /// </summary>
        /// <param name="HostingUnit">the HU to delete</param>
        public void DeleteHostingUnit(HostingUnit HostingUnit)
        {
            var v = from hu in DataSource.hostingUnits
                    let key = HostingUnit.HostingUnitKey
                    where hu.HostingUnitKey != key
                    select hu;

            if (v.ToList().Count == DataSource.hostingUnits.Count)//there is no such HU in the DataSource
                throw new ObjectNotFoundExcetion(HostingUnit.HostingUnitName, "HostingUnit");

            DataSource.hostingUnits = v.ToList();
        }
        public void DeleteOrder(Order order)
        {
            var v = (from o in DataSource.orders
                     let key = order.OrderKey
                     where o.OrderKey != key
                     select o).ToList();

            if (v.Count == DataSource.orders.Count)//there is no such HU in the DataSource
                throw new ObjectNotFoundExcetion((order.OrderKey).ToString(), "order");

            DataSource.orders = v;
        }

        //optional- add delete to others alse
        #endregion

        #region get element list

        /// <summary>
        /// get the GuestRequest list
        /// </summary>
        /// <returns>the GuestRequest list</returns>
        public List<GuestRequest> GetGuestRequests()
        {
            var v = from gr in DataSource.guestRequests
                    select gr.Clone();
            return v.ToList();
        }

        /// <summary>
        /// Bring the HostingUnit list
        /// </summary>
        /// <returns>the HostingUnit list</returns>
        public List<HostingUnit> GetHostingUnits()
        {
            var v = from hu in DataSource.hostingUnits
                    select hu.Clone();
            return v.ToList();
        }

        /// <summary>
        ///  Bring the Host list
        /// </summary>
        /// <returns>the Host list</returns>
        public List<Host> GetHosts()
        {
            var v = from host in DataSource.hosts
                    select host.Clone();
            return v.ToList();
        }

        /// <summary>
        /// Bring the Order list
        /// </summary>
        /// <returns>the Order list</returns>
        public List<Order> GetOrders()
        {
            var v = from o in DataSource.orders
                    select o.Clone();
            return v.ToList();
        }

        /// <summary>
        /// Bring the BankBranches list
        /// </summary>
        /// <returns>the BankBranches list</returns>
        public List<BankBranch> GetBankBranches()
        {
            List<BankBranch> BankBranchs = new List<BankBranch>();
            BankBranch bb = new BankBranch();
            for (int i = 0; i < 5; i++)
            {
                bb.BankNumber = i;
                bb.BankName = (i + 65).ToString();
                bb.BranchAddress = (i + 65).ToString();
                bb.BranchCity = (i + 65).ToString();
                bb.BranchNumber = i;

                BankBranchs.Add(bb.Clone());
            }
            return BankBranchs;
        }
        #endregion

        public void loadBankBranches()
        {
            //does nothing, since the BB are locally created
        }
    }
}
