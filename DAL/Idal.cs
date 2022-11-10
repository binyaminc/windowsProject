using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public interface Idal
    {

        #region add element
        void AddGuestReuest(GuestRequest GuestRequest);
        
        void AddHostingUnit(HostingUnit HostingUnit);

        void AddHost(Host host);
        void AddOrder(Order Order);
        #endregion

        #region update element
        void UpdateGuestRequest(GuestRequest GuestRequest);
        
        void UpdateHostingUnit(HostingUnit HostingUnit);

        void UpdateHost(Host host);

        void UpdateOrder(Order Order);
        #endregion

        #region delete object
        void DeleteHostingUnit(HostingUnit HostingUnit);
        void DeleteOrder(Order order);
        #endregion

        #region get element list
        List<GuestRequest> GetGuestRequests();

        List<HostingUnit> GetHostingUnits();

        List<Host> GetHosts();

        List<Order> GetOrders();
        
        List<BankBranch> GetBankBranches();

        #endregion

        void loadBankBranches();
    }
}
