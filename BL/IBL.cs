using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;

namespace BL
{
    public interface IBL
    {
        #region add element
        void AddGuestRequest(GuestRequest GuestRequest);
        void AddHostingUnit(HostingUnit HostingUnit);
        void AddHost(Host host);
        void AddOrder(Order Order);
        #endregion

        #region update element
        void UpdateGuestRequest(GuestRequest GuestRequest);
        void UpdateHostingUnit(HostingUnit HostingUnit);
        void UpdateOrder(Order Order);
        #endregion

        #region delete object
        void DeleteHostingUnit(HostingUnit HostingUnit);
        void DeleteOrder(Order order);
        #endregion

        #region element list
        List<HostingUnit> GetHostingUnits();
        List<GuestRequest> GetGuestRequests();
        List<Host> getHosts();
        List<Order> GetOrders();
        List<BankBranch> GetBankBranches();
        #endregion

        #region send invitation
        void guestInvitation(Order order);
        void sendInvitationOnGmail(Order order, GuestRequest gr, HostingUnit hu);
        #endregion
        void closeDeal(Order order, MyOrder status);
        void deleteCollectionClearance(Host host);
        void addCollectionClearance(Host host);
        List<HostingUnit> getAvailableHU(DateTime Date, int Length);
        bool isDatesAvailable(HostingUnit hostingUnit, GuestRequest guestRequet);
        List<GuestRequest> getGRsFitToHU(HostingUnit hu);
        List<Order> getOlderThenOrders(int days);
        List<GuestRequest> getGRbyCondition(Predicate<GuestRequest> pred);
        int getNumOfOrdersOfGR(GuestRequest guestRequest);
        int getNumOfTreatedOrders(HostingUnit hostingUnit);
        List<HostingUnit> getHUsOfHost(Host host);
        List<Order> getOrdersOfHost(Host host);

        void loadBankBranches();

        #region get object by name or key
        HostingUnit getHUbyName(String name);
        GuestRequest getGRbyName(String name);
        Host getHostByName(String name);
        Order getOrderByKey(int key);

        #endregion

        #region get object name by key
        String getGRNameByKey(int key);
        String getHUNameByKey(int key);
        String getHostNameByKey(int key);
        #endregion

        #region get DateTime distance
        double distance(DateTime Date1, DateTime Date2);
        double distance(DateTime Date);
        #endregion
        
        #region group by
        
        IEnumerable<IGrouping<Area, GuestRequest>> groupGRByArea();
        IEnumerable<IGrouping<int, GuestRequest>> groupByGuests();
        IEnumerable<IGrouping<int, Host>> groupByHUAmount();
        IEnumerable<IGrouping<Area, HostingUnit>> groupHUByArea();
        #endregion


    }
}
