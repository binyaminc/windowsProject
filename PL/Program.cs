using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BL;
using BE;

namespace PL
{
    class Program
    {
        static void Main(string[] args)
        {
            //IBL bl = BlSingletonFactory.getBl_imp();
            //Idal dal = DalSingletonFactory.getDal_imp();
            Idal dal_Xml = DalSingletonFactory.getDal_imp();
            
            BankBranch bankBranch1 = createBB(1, "Hapoalin", 111, "Sha'ari Hyir", "Jerusalem");
            Host host1 = createH("plony", "almony1", 0524685501, "plony@gmail.com", bankBranch1, 11111, true);
            Host host2 = createH("plony", "almony2", 0524685501, "plony@gmail.com", bankBranch1, 11111, true);
            Host host3 = createH("plony", "almony3", 0524685501, "plony@gmail.com", bankBranch1, 11111, true);

            HostingUnit hu1 = createHU(Area.Center, "hu1", host1);
            HostingUnit hu2 = createHU(Area.Jerusalem, "hu2", host2);
            HostingUnit hu3 = createHU(Area.Jerusalem, "hu3", host2);

            GuestRequest gr1 = createGR("ely", "cohen", "ely@gmail.com", RequestStatus.Active, new DateTime(2019, 3, 1), new DateTime(2019, 4, 6), new DateTime(2019, 4, 10), Area.Center, "revava", BE.Type.Hotel, 2, 8, Pool.Disinterested, Jacuzzi.Disinterested, Garden.Disinterested, ChildrenAttractions.Necessary);
            GuestRequest gr2 = createGR("yosef", "levi", "ely@gmail.com", RequestStatus.Active, new DateTime(2019, 1, 1), new DateTime(2019, 4, 6), new DateTime(2019, 4, 10), Area.Jerusalem, "revava", BE.Type.Hotel, 2, 8, Pool.Disinterested, Jacuzzi.Disinterested, Garden.Disinterested, ChildrenAttractions.Necessary);
            GuestRequest gr3 = createGR("yosef2", "levi3", "ely@gmail.com", RequestStatus.Active, new DateTime(2019, 1, 1), new DateTime(2019, 4, 6), new DateTime(2019, 4, 10), Area.Jerusalem, "revava", BE.Type.Hotel, 2, 5, Pool.Disinterested, Jacuzzi.Disinterested, Garden.Disinterested, ChildrenAttractions.Necessary);

            Order o1 = createO(hu1.HostingUnitKey, gr1.GuestRequestKey, MyOrder.NotYetTreated, new DateTime(2019, 3, 5), new DateTime(2019, 3, 26), Configuration.Commission, new DateTime(2019, 3, 1));
            Order o2 = createO(hu2.HostingUnitKey, gr2.GuestRequestKey, MyOrder.NotYetTreated, new DateTime(2019, 1, 5), new DateTime(2019, 1, 26), Configuration.Commission, new DateTime(2019, 3, 1));
            Order o3 = createO(hu3.HostingUnitKey, gr2.GuestRequestKey, MyOrder.NotYetTreated, new DateTime(2019, 1, 5), new DateTime(2019, 1, 26), Configuration.Commission, new DateTime(2019, 3, 1));


            /*
            bl.AddGuestReuest(gr1);
            bl.AddGuestReuest(gr2);
            bl.AddGuestReuest(gr3);

            bl.AddHostingUnit(hu1);
            bl.AddHostingUnit(hu2);
            bl.AddHostingUnit(hu3);

            bl.AddOrder(o1);
            bl.AddOrder(o2);
            */

            //bl.AddOrder(o3);
            o3.HostingUnitKey = 125;
            dal_Xml.UpdateOrder(o3);
            List<Order> orTest = dal_Xml.GetOrders();
            
            
            /*
            foreach (GuestRequest gr in bl.GetGuestRequests())
            {
                Console.WriteLine(gr.ToString());
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
            */
            /*
            foreach (IGrouping<int, Host> g in bl.groupByHUAmount())
            {
                foreach(var v in g)
                {
                    Console.WriteLine(v.ToString());
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            */
            /*

            
            foreach (HostingUnit hu in dal.GetHostingUnits())
            {
                Console.WriteLine(hu.ToString());
                Console.WriteLine();
            }
            foreach (Order o in dal.GetOrders())
            {
                Console.WriteLine(o.ToString());
                Console.WriteLine();
            }
            foreach (BankBranch bb in dal.GetBankBranches())
            {
                Console.WriteLine(bb.ToString());
                Console.WriteLine();
            }*/

            
            Console.ReadKey();
        }

        #region semi constractors
        public static HostingUnit createHU(Area area, string name, Host owner)
        {
            HostingUnit hu = new HostingUnit();
            hu.Area = area;
            hu.HostingUnitKey = Configuration.HostingUnitKey;
            hu.HostingUnitName = name;
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    hu.Diary[i, j] = false;
                }
            }
            hu.Owner = owner;
            return hu;
        }
        public static Host createH(string privateName, string familyName, int fhoneNumber, string mailAdderss, BankBranch bankBranch, int bankAccountNumber, bool collectionClearance)
        {
            Host host = new Host();
            host.HostKey = Configuration.HostKey;
            host.PrivateName = privateName;
            host.FamilyName = familyName;
            host.PhoneNumber = fhoneNumber;
            host.MailAddress = mailAdderss;
            host.BankBranchDetails = bankBranch;
            host.BankAccountNumber = bankAccountNumber;
            host.CollectionClearance = collectionClearance;
            return host;
        }
        public static BankBranch createBB(int bankNumber, string bankName, int branchNumber, string branchAdderss, string branchCity)
        {
            BankBranch bb = new BankBranch();
            bb.BankNumber = bankNumber;
            bb.BankName = bankName;
            bb.BranchNumber = branchNumber;
            bb.BranchAddress = branchAdderss;
            bb.BranchCity = branchCity;
            return bb;
        }
        public static GuestRequest createGR(string privateName, string familyName, string mailAdderss, RequestStatus status, DateTime registrationDate, DateTime entryDate, DateTime releaseDate, Area area, string subArea, BE.Type type, int adults, int children, Pool pool, Jacuzzi jacuzzi, Garden garden, ChildrenAttractions ca)
        {
            GuestRequest gr = new GuestRequest();
            gr.GuestRequestKey = Configuration.GuestRequestKey;
            gr.PrivateName = privateName;
            gr.FamilyName = familyName;
            gr.MailAddress = mailAdderss;
            gr.Status = status;
            gr.RegistrationDate = registrationDate;
            gr.EntryDate = entryDate;
            gr.ReleaseDate = releaseDate;
            gr.Area = area;
            gr.SubArea = subArea;
            gr.Type = type;
            gr.Adults = adults;
            gr.Children = children;
            gr.Pool = pool;
            gr.Jacuzzi = jacuzzi;
            gr.ChildrenAttractions = ca;
            return gr;
        }
        public static Order createO(int hostingUnitKey, int guestRequestKey, MyOrder status, DateTime createDate, DateTime orderDate, double commission, DateTime sentMailDate)
        {
            Order o = new Order();
            o.HostingUnitKey = hostingUnitKey;
            o.GuestRequestKey = guestRequestKey;
            o.OrderKey = Configuration.OrderKey;
            o.Status = status;
            o.CreateDate = createDate;
            //o.OrderDate = orderDate;
            o.Commission = commission;
            o.SentMailDate = sentMailDate;
            return o;
        }
        #endregion
    }
}
