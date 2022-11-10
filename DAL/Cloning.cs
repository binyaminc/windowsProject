using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    /// <summary>
    /// It protects the data of the DAL from mistaken changings by cloning every instance that DAL gets of sets (the copying done with deep copy)
    /// </summary>
    public static class Cloning
    {
        /// <summary>
        /// implement deap copy to BankBranch
        /// </summary>
        /// <param name="bankBranch">the bankBranch to copy</param>
        /// <returns>a copy of the original bankBranch</returns>
        public static BankBranch Clone(this BankBranch bankBranch)
        {
            BankBranch target = new BankBranch();
            target.BankNumber = bankBranch.BankNumber;
            target.BankName = bankBranch.BankName;
            target.BranchNumber = bankBranch.BranchNumber;
            target.BranchAddress = bankBranch.BranchAddress;
            target.BranchCity = bankBranch.BranchCity;
            return target;
        }
        /// <summary>
        /// implement deap copy to GuestRequest
        /// </summary>
        /// <param name="guestRequest">the guestRequest to copy</param>
        /// <returns>a copy of the original guestRequest</returns>
        public static GuestRequest Clone(this GuestRequest guestRequest)
        {
            GuestRequest target = new GuestRequest();
            target.GuestRequestKey = guestRequest.GuestRequestKey;
            target.PrivateName = guestRequest.PrivateName;
            target.FamilyName = guestRequest.FamilyName;
            target.MailAddress = guestRequest.MailAddress;
            target.Status = guestRequest.Status;
            target.RegistrationDate = guestRequest.RegistrationDate;
            target.EntryDate = guestRequest.EntryDate;
            target.ReleaseDate = guestRequest.ReleaseDate;
            target.SubArea = guestRequest.SubArea;
            target.Area = guestRequest.Area;
            target.Type = guestRequest.Type;
            target.Adults = guestRequest.Adults;
            target.Children = guestRequest.Children;
            target.Pool = guestRequest.Pool;
            target.Jacuzzi = guestRequest.Jacuzzi;
            target.Garden = guestRequest.Garden;
            target.ChildrenAttractions = guestRequest.ChildrenAttractions;


            return target;
        }
        /// <summary>
        /// implement deap copy to Host
        /// </summary>
        /// <param name="host">the host to copy</param>
        /// <returns>a copy of the original host</returns>
        public static Host Clone(this Host host)
        {
            Host target = new Host();
            target.HostKey = host.HostKey;
            target.PrivateName = host.PrivateName;
            target.FamilyName = host.FamilyName;
            target.PhoneNumber = host.PhoneNumber;
            target.MailAddress = host.MailAddress;
            target.BankBranchDetails = host.BankBranchDetails;
            target.BankAccountNumber = host.BankAccountNumber;
            target.CollectionClearance = host.CollectionClearance;
            target.Password = host.Password;
            return target;
        }
        /// <summary>
        /// implement deap copy to HostingUnit
        /// </summary>
        /// <param name="hostingUnit">the hostingUnit to copy</param>
        /// <returns>a copy of the original hostingUnit</returns>
        public static HostingUnit Clone(this HostingUnit hostingUnit)
        {
            HostingUnit target = new HostingUnit();
            target.Owner = hostingUnit.Owner;
            target.HostingUnitName = hostingUnit.HostingUnitName;
            target.Diary = hostingUnit.Diary;
            target.HostingUnitKey = hostingUnit.HostingUnitKey;
            target.Area = hostingUnit.Area;
            target.SubArea = hostingUnit.SubArea;
            target.Type = hostingUnit.Type;
            target.Capacity = hostingUnit.Capacity;
            target.Address = hostingUnit.Address;
            target.Pool = hostingUnit.Pool;
            target.Jacuzzi = hostingUnit.Jacuzzi;
            target.Garden = hostingUnit.Garden;
            target.ChildrenAttractions = hostingUnit.ChildrenAttractions;

            return target;
        }
        /// <summary>
        /// implement deap copy to Order
        /// </summary>
        /// <param name="order">the order to copy</param>
        /// <returns>a copy of the original order</returns>
        public static Order Clone(this Order order)
        {
            Order target = new Order();
            target.HostingUnitKey = order.HostingUnitKey;
            target.GuestRequestKey = order.GuestRequestKey;
            target.OrderKey = order.OrderKey;
            target.Commission = order.Commission;
            target.Status = order.Status;
            target.CreateDate = order.CreateDate;
            //target.OrderDate = order.OrderDate;
            target.SentMailDate = order.SentMailDate;
            return target;
        }

        //TODO: make sure all the fields are here
    }
}
