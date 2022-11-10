using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using BE;
using DAL;
using Exceptions;

namespace BL
{
    class Bl_imp : IBL//need to update everything to the dal
    {
        Idal dal = DalSingletonFactory.getDal_imp();

        public Bl_imp()
        {
            new Thread(updateExpiredOrders).Start();
        }
        /// <summary>
        /// change the status of the orders that the costumer didn't answer to, to "ClosedCustomerUnavailability"
        /// </summary>
        private void updateExpiredOrders()
        {
            while (true)
            {
                foreach (Order o in dal.GetOrders())
                {
                    if (distance(o.SentMailDate) > 30 && o.Status == MyOrder.MailHasBeenSent)
                    {
                        o.Status = MyOrder.ClosedCustomerUnavailability;
                        dal.UpdateOrder(o);
                    }
                }
                Thread.Sleep(1000 * 60 * 60 * 24);//makes an update once a day
            }
        }

        #region add element
        /// <summary>
        /// Add GuestReuest to the database
        /// </summary>
        /// <param name="GuestRequest"> the GR to add</param>
        public void AddGuestRequest(GuestRequest GuestRequest)
        {
            try
            {
                checkDate(GuestRequest);
            }
            catch (ArgumentException ae)
            {
                throw ae;
            }
            try
            {
                dal.AddGuestReuest(GuestRequest);
            }
            catch (AlreadyExistsException aee)
            {
                throw aee;
            }
        }

        /// <summary>
        /// Add HostingUnit to the database
        /// </summary>
        /// <param name="HostingUnit">the HU to add</param>
        public void AddHostingUnit(HostingUnit HostingUnit)
        {
            try
            {
                dal.AddHostingUnit(HostingUnit);
            }
            catch (AlreadyExistsException aee)
            {
                throw aee;
            }
        }

        /// <summary>
        /// Add Host to the database
        /// </summary>
        /// <param name="Host">the host to add</param>
        public void AddHost(Host host)
        {
            try
            {
                dal.AddHost(host);
            }
            catch (AlreadyExistsException aee)
            {
                throw aee;
            }
        }

        /// <summary>
        /// Add order to the database, if the date is available
        /// </summary>
        /// <param name="Order">The order to add</param>
        public void AddOrder(Order Order)
        {
            GuestRequest guestRequest = Order.getGuestRequest();
            HostingUnit hostingUnit = Order.GetHostingUnit();
            if (guestRequest == null || hostingUnit == null)//make sure both GR and HU exist
                throw new ArgumentNullException("guest request or hosting unit");

            bool available = true;
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    if (hostingUnit.Diary[i, j] == true && guestRequest.inRange(i, j))
                        available = false;
                }
            }
            if (available)// == true
            {
                try
                {
                    dal.AddOrder(Order);
                }
                catch (AlreadyExistsException aee)
                {
                    throw aee;
                }
            }
            else
                throw new InvalidOperationException("can't create order to guest whose requested dates are not available in the HU");
        }
        #endregion

        #region update element

        /// <summary>
        /// Update GuestReuest in the database
        /// </summary>
        /// <param name="GuestRequest">the GR to update</param>
        public void UpdateGuestRequest(GuestRequest GuestRequest)
        {
            try
            {
                checkDate(GuestRequest);
            }
            catch (ArgumentException ae)
            {
                throw ae;
            }
            try
            {
                dal.UpdateGuestRequest(GuestRequest);
            }
            catch (ObjectNotFoundExcetion onfe)
            {
                throw onfe;
            }
        }
        /// <summary>
        /// check if guest request dates are valid
        /// </summary>
        /// <param name="GuestRequest">the GR to check</param>
        private static void checkDate(GuestRequest GuestRequest)
        {
            if (GuestRequest.ReleaseDate.CompareTo(GuestRequest.EntryDate) <= 0)//we don't deal with hours, the assumption is that there is no difference in hours
            {
                throw new ArgumentException(String.Format("the dates of guestRequest {0} ane not valid", GuestRequest.PrivateName));
            }
        }

        /// <summary>
        /// Update HostingUnit in the database
        /// </summary>
        /// <param name="HostingUnit">The HU to update</param>
        public void UpdateHostingUnit(HostingUnit HostingUnit)
        {
            try
            {
                dal.UpdateHostingUnit(HostingUnit);
            }
            catch (ObjectNotFoundExcetion onfe)
            {
                throw onfe;
            }
        }

        /// <summary>
        /// Update Order in the database
        /// </summary>
        /// <param name="HostingUnit">The Order to update</param>
        public void UpdateOrder(Order Order)
        {
            try
            {
                dal.UpdateOrder(Order);
            }
            catch (ObjectNotFoundExcetion onfe)
            {
                throw onfe;
            }
        }

        #endregion

        #region delete object
        /// <summary>
        /// Delete HostingUnit from the database, if nobody needs it
        /// </summary>
        /// <param name="HostingUnit">the HU to delete</param>
        public void DeleteHostingUnit(HostingUnit HostingUnit)
        {
            var v = from order in dal.GetOrders()
                    let HostingUnitKey = order.HostingUnitKey
                    where HostingUnit.HostingUnitKey == HostingUnitKey
                    select new { gr = order.getGuestRequest(), isActive = (order.getGuestRequest().Status == RequestStatus.Active) };

            bool deleteable = true;
            foreach (var gr in v)
            {
                if (gr.isActive)
                    deleteable = false;
            }

            if (deleteable == true)
            {
                try
                {
                    dal.DeleteHostingUnit(HostingUnit);
                }
                catch (ObjectNotFoundExcetion onfe)
                {
                    throw onfe;
                }
            }
            else
                throw new InvalidOperationException(String.Format("The hostingUnit {0} can't be deleted because there are guestRequest connected to this hostingUnit", HostingUnit.HostingUnitName));

        }

        public void DeleteOrder(Order order)
        {
            if (order.Status == MyOrder.NotYetTreated || order.Status == MyOrder.ClosedCustomerUnavailability)
            {
                dal.DeleteOrder(order);
            }
            if (order.Status == MyOrder.MailHasBeenSent)
            {
                throw new InvalidOperationException("can't delete order that was sent to costumer");
            }
            if (order.Status == MyOrder.ClosedByCustomer)
            {
                if (order.getGuestRequest().ReleaseDate <= DateTime.Now)
                    dal.DeleteOrder(order);
                else
                    throw new InvalidOperationException("can't delete 'closed by customer' order when the release date did't pass yet");
            }
        }
        #endregion

        #region get element list
        /// <summary>
        /// get the GuestRequest list
        /// </summary>
        /// <returns>the GuestRequest list</returns>
        public List<GuestRequest> GetGuestRequests()
        {
            return dal.GetGuestRequests();
        }

        /// <summary>
        /// get the HostingUnit list
        /// </summary>
        /// <returns>the HostingUnit list</returns>
        public List<HostingUnit> GetHostingUnits()
        {
            return dal.GetHostingUnits();
        }

        /// <summary>
        /// get the Host list
        /// </summary>
        /// <returns>the Host list</returns>
        public List<Host> getHosts()
        {
            return dal.GetHosts();
        }

        /// <summary>
        /// get the Order list
        /// </summary>
        /// <returns>the Order list</returns>
        public List<Order> GetOrders()
        {
            return dal.GetOrders();
        }

        /// <summary>
        /// get the BankBranch list
        /// </summary>
        /// <returns>the BankBranch list</returns>
        public List<BankBranch> GetBankBranches()
        {
            return dal.GetBankBranches();
        }
        #endregion

        #region send invitation and change status

        /// <summary>
        /// change status of order to sentMail and determines the time it was changed
        /// </summary>
        /// <param name="order">the order to make the changes on</param>
        public void guestInvitation(Order order)
        {
            if (order.GetHostingUnit().Owner.CollectionClearance == true)
            {
                order.setStatus(MyOrder.MailHasBeenSent);

                order.SentMailDate = DateTime.Now;
                try
                {
                    dal.UpdateOrder(order);
                }
                catch (ObjectNotFoundExcetion onfe)
                {
                    throw onfe;
                }
            }
            else
                throw new InvalidOperationException("sending invitation to guests is illigal without collection clearance");
        }

        public void sendInvitationOnGmail(Order order, GuestRequest gr, HostingUnit hu)
        {
            //MailMessage   יצירת אובייקט            
            MailMessage mail = new MailMessage();

            //(כתובת הנמען(ניתן להוסיף יותר מאחד              
            mail.To.Add(String.Format("{0}", gr.MailAddress));
            
            //הכתובת ממנה נשלח המייל                          
            mail.From = new MailAddress(hu.Owner.MailAddress);

            //  נושא ההודע ה                        
            mail.Subject = "Hosting invitation";

            //( HTML תוכן ההודעה (נניח שתוכן ההודעה בפורמט              

            mail.Body = String.Format("Hellow, you are invaited to {0}", hu.HostingUnitName);

            // HTML  הגדרה שתוכן ההודעה בפורמט             
            mail.IsBodyHtml = true;

            // Smtp   יצירת עצם מסוג            
            SmtpClient smtp = new SmtpClient();

            // gmail הגדרת השרת של              
            smtp.Host = "smtp.gmail.com";

            // gmail הגדרת פרטי הכניסה (שם משתמש וסיסמה) לחשבון ה              
            smtp.Credentials = new System.Net.NetworkCredential("minipwindows2020@gmail.com", "minip2020");
            // SSL ע"פ דרישת השר, חובה לאפשר במקרה זה              
            smtp.EnableSsl = true;
            try
            {
                // שליחת ההודעה                             
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                //   טיפול בשגיאות ותפיסת חריגות       
                //throw new Exception(ex.ToString());
            }
        }

        #endregion


        /// <summary>
        /// close the deal- change the order and GR status
        /// </summary>
        /// <param name="order">the order to change status</param>
        /// <param name="status">the specific status to change</param>
        public void closeDeal(Order order, MyOrder status)
        {
            order.setStatus(status);
            if (status == MyOrder.ClosedByCustomer)
            {
                GuestRequest thisGR = order.getGuestRequest();
                thisGR.Status = RequestStatus.ClosedByWeb;
                try
                {
                    dal.UpdateGuestRequest(thisGR);
                }
                catch (ObjectNotFoundExcetion onfe)
                {
                    throw onfe;
                }
                //order.Status = MyOrder.MailHasBeenSent;
            }
            else if (status == MyOrder.ClosedCustomerUnavailability)
            {
                GuestRequest thisGR = order.getGuestRequest();
                thisGR.Status = RequestStatus.ClosedBecauseOfTime;
                try
                {
                    dal.UpdateGuestRequest(thisGR);
                }
                catch (ObjectNotFoundExcetion onfe)
                {
                    throw onfe;
                }
            }
            else
                throw new ArgumentException(String.Format("can't close deal of order {0} with non-closing status", order.OrderKey));


            //update the other orders related to the specific GR
            var v = from tempOrder in dal.GetOrders()
                    where (order.GuestRequestKey == tempOrder.GuestRequestKey) && (tempOrder.OrderKey != order.OrderKey) && (tempOrder.Status != MyOrder.ClosedByCustomer) && (tempOrder.Status != MyOrder.ClosedCustomerUnavailability)
                    select tempOrder;
            v.ToList().ForEach(tOrder => tOrder.setStatus(MyOrder.ClosedByCustomer));//update into dal inside the function setStatus

            //calculate the commission
            double commission = 0;
            if (status == MyOrder.ClosedByCustomer)//commision is not 0 only if the customer answered. if "ClosedCustomerUnavailability" the commision is 0
            {
                for (int i = 0; i < 12; i++)
                {
                    for (int j = 0; j < 31; j++)
                    {
                        if (order.getGuestRequest().inRange(i, j))
                        {
                            commission += Configuration.Commission;
                            order.GetHostingUnit().Diary[i, j] = true;
                        }
                    }
                }
            }
            order.Commission = commission;
            try
            {
                dal.UpdateOrder(order);
            }
            catch (ObjectNotFoundExcetion onfe)
            {
                throw onfe;
            }
        }
        #region collection clearance

        /// <summary>
        /// delete collectionClearance of specific host
        /// </summary>
        /// <param name="host">the host to change</param>
        public void deleteCollectionClearance(Host host)
        {
            var v = from Order order in dal.GetOrders()
                    where order.getHost().HostKey == host.HostKey
                    select order.getGuestRequest();

            bool deleteable = true;
            foreach (GuestRequest gr in v)
            {
                if (gr.Status == RequestStatus.Active)
                    deleteable = false;
            }

            if (deleteable)
            {
                host.CollectionClearance = false;
                try
                {
                    dal.UpdateHost(host);
                }
                catch (ObjectNotFoundExcetion onfe)
                {
                    throw onfe;
                }
                var var = from hu in dal.GetHostingUnits()
                          where hu.Owner.HostKey == host.HostKey
                          select hu;
                foreach (HostingUnit hu in var)
                {
                    hu.Owner = host;
                    dal.UpdateHostingUnit(hu);
                }

            }
            else
                throw new ArgumentException("can't delete CC because there are GRs related to this HU");
        }

        /// <summary>
        /// add collectionClearance of specific host
        /// </summary>
        /// <param name="host">the host to change</param>
        public void addCollectionClearance(Host host)
        {
            host.CollectionClearance = true;
            try
            {
                dal.UpdateHost(host);
            }
            catch (ObjectNotFoundExcetion onfe)
            {
                throw onfe;
            }
            var var = from hu in dal.GetHostingUnits()
                      where hu.Owner.HostKey == host.HostKey
                      select hu;
            foreach (HostingUnit hu in var)
            {
                hu.Owner = host;
                dal.UpdateHostingUnit(hu);
            }
        }

        #endregion 
        /// <summary>
        /// return the HUs who are empty in these days
        /// </summary>
        /// <param name="Date">beggining date</param>
        /// <param name="Length">amount of dates</param>
        /// <returns>list of available HU</returns>
        public List<HostingUnit> getAvailableHU(DateTime Date, int Length)
        {
            GuestRequest guestRequest = new GuestRequest();
            guestRequest.EntryDate = Date;
            guestRequest.ReleaseDate = Date.AddDays(Length);
            var v = from HostingUnit hu in dal.GetHostingUnits()
                    where isDatesAvailable(hu, guestRequest)
                    select hu;
            return v.ToList();
        }

        /// <summary>
        /// return if a GR is available in this HU
        /// </summary>
        /// <param name="hostingUnit"></param>
        /// <param name="guestRequet"></param>
        /// <returns>bool value if available</returns>
        public bool isDatesAvailable(HostingUnit hostingUnit, GuestRequest guestRequet)
        {
            bool available = true;
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    if (hostingUnit.Diary[i, j] == true && guestRequet.inRange(i, j))
                        available = false;
                }
            }
            return available;
        }
        /// <summary>
        /// return all the GRs who fits to the hu
        /// </summary>
        /// <param name="hu">the hu to check</param>
        /// <returns>list of fit GR</returns>
        public List<GuestRequest> getGRsFitToHU(HostingUnit hu)
        {
            List<GuestRequest> guestRequests = new List<GuestRequest>();
            foreach (GuestRequest gr in dal.GetGuestRequests())
            {
                if (isDatesAvailable(hu, gr) && boolAdditionsFit(hu, gr) && (gr.Area == hu.Area || gr.Area == Area.All) && (gr.SubArea == hu.SubArea) && (gr.Type == hu.Type) && (gr.Adults + gr.Children <= hu.Capacity))
                    guestRequests.Add(gr);
            }
            return guestRequests;
        }
        public bool boolAdditionsFit(HostingUnit hu, GuestRequest gr)
        {
            if ((gr.Pool == Pool.Necessary && hu.Pool == false) ||
                (gr.Pool == Pool.Disinterested && hu.Pool == true) ||
                (gr.Jacuzzi == Jacuzzi.Necessary && hu.Jacuzzi == false) ||
                (gr.Jacuzzi == Jacuzzi.Disinterested && hu.Jacuzzi == true) ||
                (gr.Garden == Garden.Necessary && hu.Garden == false) ||
                (gr.Garden == Garden.Disinterested && hu.Garden == true) ||
                (gr.ChildrenAttractions == ChildrenAttractions.Necessary && hu.ChildrenAttractions == false) ||
                (gr.Jacuzzi == Jacuzzi.Disinterested && hu.Jacuzzi == true))
                return false;
            return true;
        }

        #region distance between dates
        public double distance(DateTime Date1, DateTime Date2)
        {
            return (Date2.Subtract(Date1)).TotalDays;
        }
        public double distance(DateTime Date)
        {
            return Math.Abs(((DateTime.Now).Subtract(Date)).TotalDays);
        }
        #endregion


        /// <summary>
        /// return a list of all the order that the time that passed since they were created is bigger or equeal to the parameter
        /// </summary>
        /// <param name="days">amount of days</param>
        /// <returns>look up!</returns>
        public List<Order> getOlderThenOrders(int days)
        {
            var v = from order in dal.GetOrders()
                    let condition = ((distance(order.CreateDate) >= days) || (distance(order.SentMailDate) >= days))
                    where condition
                    select order;
            return v.ToList();
        }


        /// <summary>
        /// get list of GuestRequests by condition
        /// </summary>
        /// <param name="pred">predicate function</param>
        /// <returns></returns>
        public List<GuestRequest> getGRbyCondition(Predicate<GuestRequest> pred)
        {
            var v = from guestRequest in dal.GetGuestRequests()
                    where pred(guestRequest)
                    select guestRequest;
            return v.ToList();
        }


        /// <summary>
        /// returns amount of orders related to spesific GR
        /// </summary>
        /// <param name="guestRequest">the Gr to check</param>
        /// <returns>amount of orders related to this spesific GR</returns>
        public int getNumOfOrdersOfGR(GuestRequest guestRequest)
        {
            var v = from order in dal.GetOrders()
                    where order.GuestRequestKey == guestRequest.GuestRequestKey
                    select order;
            return v.Count();
        }


        /// <summary>
        /// returns the number of orders that closed by the customer or by the web
        /// </summary>
        /// <param name="hostingUnit">to check on</param>
        /// <returns>the number of orders that closed by the customer or by the web</returns>
        public int getNumOfTreatedOrders(HostingUnit hostingUnit)//TODO: check if the condition is right
        {
            int i = 0;
            foreach (Order order in dal.GetOrders())
            {
                if ((order.HostingUnitKey == hostingUnit.HostingUnitKey) && ((order.Status == MyOrder.ClosedByCustomer) || (order.Status == MyOrder.MailHasBeenSent)))
                {
                    i++;
                }
            }
            return i;
        }

        /// <summary>
        /// returns the HU list of specific host
        /// </summary>
        /// <param name="host">the host to take the HUs</param>
        /// <returns>list of HUs</returns>
        public List<HostingUnit> getHUsOfHost(Host host)
        {
            var v = from hu in dal.GetHostingUnits()
                    where hu.Owner.HostKey == host.HostKey
                    select hu;
            return v.ToList();
        }
        /// <summary>
        /// returns the orders of all HUs of specific host
        /// </summary>
        /// <param name="host">the host to take the orders</param>
        /// <returns>list of orders</returns>
        public List<Order> getOrdersOfHost(Host host)
        {
            var v = from o in dal.GetOrders()
                    where getHUbyName(getHUNameByKey(o.HostingUnitKey)).Owner.HostKey == host.HostKey
                    select o;
            return v.ToList();
        }

        public void loadBankBranches()
        {
            dal.loadBankBranches();
        }

        #region get object by name or key

        /// <summary>
        /// return the HU whose name is the parameter
        /// </summary>
        /// <param name="name">the name to check</param>
        /// <returns>the HU whose name is the parameter</returns>
        public HostingUnit getHUbyName(String name)
        {
            return (dal.GetHostingUnits()).Find(x => x.HostingUnitName == name);
        }
        /// <summary>
        /// return the GR whose name is the parameter
        /// </summary>
        /// <param name="name">the name to check</param>
        /// <returns>the GR whose name is the parameter</returns>
        public GuestRequest getGRbyName(String name)
        {
            return (dal.GetGuestRequests()).Find(x => x.PrivateName == name);
        }
        public Host getHostByName(String name)
        {
            return (dal.GetHosts()).Find(x => x.PrivateName == name);
        }
        public Order getOrderByKey(int key)
        {
            return (dal.GetOrders()).Find(order => order.OrderKey == key);
        }
        #endregion

        #region get object name by key
        public String getGRNameByKey(int key)
        {
            if (dal.GetGuestRequests().Find(gr => gr.GuestRequestKey == key) != null)
                return (dal.GetGuestRequests().Find(gr => gr.GuestRequestKey == key)).PrivateName;
            return "";
        }
        public String getHUNameByKey(int key)
        {
            if (dal.GetHostingUnits().Find(hu => hu.HostingUnitKey == key) != null)
                return (dal.GetHostingUnits().Find(hu => hu.HostingUnitKey == key)).HostingUnitName;
            return "";
        }
        public String getHostNameByKey(int key)
        {
            if (dal.GetHosts().Find(host => host.HostKey == key) != null)
                return (dal.GetHosts().Find(host => host.HostKey == key)).PrivateName;
            return "";
        }
        #endregion

        #region group by

        /// <summary>
        /// return groups of GuestRequests sorted by area
        /// </summary>
        /// <returns>groups of GuestRequests sorted by area</returns>
        public IEnumerable<IGrouping<Area, GuestRequest>> groupGRByArea()
        {
            var result = from gr in dal.GetGuestRequests()
                         group gr by gr.Area;
            return result;
        }


        /// <summary>
        /// return groups of GuestRequests sorted by family size
        /// </summary>
        /// <returns>groups of GuestRequests sorted by family size</returns>
        public IEnumerable<IGrouping<int, GuestRequest>> groupByGuests()
        {
            var result = from gr in dal.GetGuestRequests()
                         group gr by (gr.Adults + gr.Children);
            return result;
        }

        /// <summary>
        /// return groups of Hosts sorted by amount of HU they own
        /// </summary>
        /// <returns>groups of Hosts sorted by amount of HU they own</returns>
        public IEnumerable<IGrouping<int, Host>> groupByHUAmount()
        {
            List<Host> hosts = new List<Host>();
            foreach (Order order in dal.GetOrders())
            {
                if (!hosts.Contains(order.getHost()))
                    hosts.Add(order.getHost());
            }

            var result = from host in hosts
                         group host by host.getHUAmount();
            return result;
        }

        /// <summary>
        /// return groups of HostingUnits sorted by area
        /// </summary>
        /// <returns>groups of HostingUnits sorted by area</returns>
        public IEnumerable<IGrouping<Area, HostingUnit>> groupHUByArea()
        {
            var result = from hu in dal.GetHostingUnits()
                         group hu by hu.Area;
            return result;
        }
        #endregion

    }
}
