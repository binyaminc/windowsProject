using BE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Exceptions;
using System.Xml.Serialization;
using System.Net;

namespace DAL
{
    class Dal_XML_imp : Idal
    {
        // path of current file: "D:\visual_studio projects\C#_windowsProject_finalVersion\DAL\Dal_XML_imp.cs"

        XElement guestRequestRoot = new XElement("guestRequests");
        const string guestRequestPath = @"..\..\..\XML\GuestRequestXml.xml";  // "D:\visual_studio_projects\C#_windowsProject_finalVersion\XML\GuestRequestXml.xml"

        XElement hostingUnitRoot = new XElement("hostingUnits");
        const string hostingUnitPath = @"..\..\..\XML\HostingUnitXml.xml";  // "D:\visual_studio_projects\C#_windowsProject_finalVersion\XML\HostingUnitXml.xml"

        XElement hostRoot = new XElement("hosts");
        const string hostPath = @"..\..\..\XML\HostXml.xml";  // "D:\visual_studio_projects\C#_windowsProject_finalVersion\XML\HostXml.xml"

        XElement orderRoot = new XElement("orders");
        const string orderPath = @"..\..\..\XML\OrderXml.xml";  // "D:\visual_studio_projects\C#_windowsProject_finalVersion\XML\OrderXml.xml"

        XElement configurationRoot = new XElement("keys");
        const string configurationPath = @"..\..\..\XML\ConfigurationXml.xml";  // "D:\visual_studio_projects\C#_windowsProject_finalVersion\XML\ConfigurationXml.xml"

        XElement atmRoot = new XElement("atms");
        const string xmlLocalPath = @"..\..\..\XML\atm.xml";  // "D:\visual_studio_projects\C#_windowsProject_finalVersion\XML\atm.xml"
        List<BankBranch> bankBranches = new List<BankBranch>();

        public Dal_XML_imp()
        {
            if (!File.Exists(orderPath))
                CreateOrderFile();
            else
            {
                try
                {
                    LoadOrderData();
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                
            }

            if (!File.Exists(configurationPath))
                CreateConfigurationFile();
            else
            {
                try
                {
                    LoadConfigurationData();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            

            loadBankBranches();
        }

        #region add element

        /// <summary>
        /// this function add a guest request to the Xml
        /// </summary>
        /// <param name="GuestRequest"></param>
        public void AddGuestReuest(GuestRequest GuestRequest)
        {
            List<GuestRequest> guestRequests = LoadFromXML<List<GuestRequest>>(guestRequestPath); // create an empty list and initializing it with the list of guest requests from the Xml
            if (!guestRequests.Exists(gr => gr.GuestRequestKey == GuestRequest.GuestRequestKey)) // checks using lambda and the function:"Exists", if there is no guest request with the same key in the new list 
            {
                guestRequests.Add(GuestRequest); // adding the new guest request to the new list of guest request
                SaveToXML<List<GuestRequest>>(guestRequests, guestRequestPath); // load the new list back to the Xml by using the function:"SaveToXML"

                int guestRequestKey = GuestRequest.GuestRequestKey + 1;//+1 because we want to enter the next value to the next GR, not to enter the same key
                updateElementKeyInConfiguration("GuestRequestKey", guestRequestKey); // load the new key to the configuration in Xml
            }
            else
                throw new AlreadyExistsException(GuestRequest.PrivateName, "GuestRequest");

        }
        /// <summary>
        /// this function add a hosting unit to the Xml
        /// </summary>
        /// <param name="HostingUnit"></param>
        public void AddHostingUnit(HostingUnit HostingUnit)
        {
            List<HostingUnit> hostingUnits = LoadFromXML<List<HostingUnit>>(hostingUnitPath);
            if (!hostingUnits.Exists(hu => hu.HostingUnitKey == HostingUnit.HostingUnitKey))// checks using lambda and the function:"Exists", if there is no hosting unit with the same key in the new list
            {
                hostingUnits.Add(HostingUnit);
                SaveToXML<List<HostingUnit>>(hostingUnits, hostingUnitPath); //load the new list back to the Xml by using the function:"SaveToXML"

                int hostingUnitKey = HostingUnit.HostingUnitKey + 1;//+1 because we want to enter the next value to the next HU, not to enter the same key
                updateElementKeyInConfiguration("HostingUnitKey", hostingUnitKey);
            }
            else
                throw new AlreadyExistsException(HostingUnit.HostingUnitName, "HostingUnit");
        }
        /// <summary>
        /// this function add a host to the Xml
        /// </summary>
        /// <param name="Host"></param>
        public void AddHost(Host host)
        {
            List<Host> hosts = LoadFromXML<List<Host>>(hostPath);
            if (!hosts.Exists(h => h.HostKey == host.HostKey)) //checks using lambda and the function:"Exists", if there is no host with the same key in the new list
            {
                hosts.Add(host);
                SaveToXML<List<Host>>(hosts, hostPath); //load the new list back to the Xml by using the function:"SaveToXML"

                int hostKey = host.HostKey + 1;//+1 because we want to enter the next value to the next HU, not to enter the same key
                updateElementKeyInConfiguration("HostKey", hostKey);
            }
            else
                throw new AlreadyExistsException(host.PrivateName, "Host");
        }

        /// <summary>
        /// this function add a order to the Xml
        /// </summary>
        /// <param name="Order"></param>
        public void AddOrder(Order Order)
        {
            if (GetOrders().Exists(o => o.OrderKey == Order.OrderKey)) //checks using lambda and the function:"Exists", if there is no order with the same key in the new list
                throw new AlreadyExistsException(Order.OrderKey.ToString(), "Order");
            else//order does not exist
            {
                XElement GuestRequestKey = new XElement("GuestRequestKey", Order.GuestRequestKey);//initializing the GuestRequestKey with the name and with our key, and doing the same for all the others
                XElement HostingUnitKey = new XElement("HostingUnitKey", Order.HostingUnitKey);
                XElement OrderKey = new XElement("OrderKey", Order.OrderKey);
                XElement Status = new XElement("Status", Order.Status);
                XElement CreateDate = new XElement("CreateDate", Order.CreateDate);
                XElement Commission = new XElement("Commission", Order.Commission);
                XElement SentMailDate = new XElement("SentMailDate", Order.SentMailDate);
                orderRoot.Add(new XElement("order", GuestRequestKey, HostingUnitKey, OrderKey, Status, CreateDate, Commission, SentMailDate));// creates a new Order element and initializing it with the values above
                orderRoot.Save(orderPath);// save the element to the Xml

                int orderKey = Order.OrderKey + 1;//+1 because we want to enter the next value to the next HU, not to enter the same key
                updateElementKeyInConfiguration("OrderKey", orderKey);
            }
        }
        #endregion

        #region delete object
        /// <summary>
        /// this function serching for a HostingUnite, if it existe, the function will delete it from the list of HostingUnits in the Xml
        /// </summary>
        /// <param name="HostingUnit"></param>
        public void DeleteHostingUnit(HostingUnit HostingUnit)
        {
            List<HostingUnit> hostingUnits = LoadFromXML<List<HostingUnit>>(hostingUnitPath);
            if (hostingUnits.Exists(hu => hu.HostingUnitKey == HostingUnit.HostingUnitKey))// checks using lambda and the function:"Exists", if there is hosting unite with the same key in the new list 
            {
                hostingUnits.RemoveAll(hu => hu.HostingUnitKey == HostingUnit.HostingUnitKey);
                SaveToXML<List<HostingUnit>>(hostingUnits, hostingUnitPath);//load the new list back to the Xml by using the function:"SaveToXML"
            }
            else //hostingUnit does not exist
                throw new ObjectNotFoundExcetion(HostingUnit.HostingUnitName, "HostingUnit");
        }

        public void DeleteOrder(Order order)
        {
            IEnumerable<XElement> XElements = (from o in orderRoot.Elements() // Serching using linq the Order that we need to delete
                                               where int.Parse(o.Element("OrderKey").Value) == order.OrderKey
                                               select o);
            //make sure Order exists in file
            if (XElements.ToList<XElement>().Count == 0) // if we didnt find the Order we were serching for...
                throw new ObjectNotFoundExcetion(order.OrderKey.ToString(), "Order");

            XElement orderElement = XElements.FirstOrDefault();// creating new element and initializing it with the Order that we want to remove
            orderElement.Remove();// removing it
            orderRoot.Save(orderPath);
        }

        #endregion

        #region update elements

        /// <summary>
        /// this function update a guest request in the Xml
        /// </summary>
        /// <param name="GuestRequest"></param>
        public void UpdateGuestRequest(GuestRequest GuestRequest)
        {
            List<GuestRequest> guestRequests = GetGuestRequests();
            if (!guestRequests.Exists(gr => gr.GuestRequestKey == GuestRequest.GuestRequestKey))//checks using lambda and the function:"Exists", if there is no guest request with the same key in the new list
                throw new ObjectNotFoundExcetion(GuestRequest.PrivateName, "GuestRequet");
            else
            {
                guestRequests.RemoveAll(gr => gr.GuestRequestKey == GuestRequest.GuestRequestKey); // removing from the list the elements with the same key of our GuestRequest
                guestRequests.Add(GuestRequest);// adding the updating GuestRequest to the list
                SaveToXML<List<GuestRequest>>(guestRequests, guestRequestPath);// load the new list back to the Xml by using the function:"SaveToXML"
            }
        }

        /// <summary>
        /// this function update a hosting unit in the Xml
        /// </summary>
        /// <param name="HostingUnit"></param>
        public void UpdateHostingUnit(HostingUnit HostingUnit)
        {
            List<HostingUnit> hostingUnits = GetHostingUnits();
            if (!hostingUnits.Exists(hu => hu.HostingUnitKey == HostingUnit.HostingUnitKey))//checks using lambda and the function:"Exists", if there is no hosting unit with the same key in the new list
                throw new ObjectNotFoundExcetion(HostingUnit.HostingUnitName, "HostingUnit");
            else
            {
                hostingUnits.RemoveAll(hu => hu.HostingUnitKey == HostingUnit.HostingUnitKey);// removing from the list the elements with the same key of our HostingUnit
                hostingUnits.Add(HostingUnit);// adding the updating HostingUnit to the list
                SaveToXML<List<HostingUnit>>(hostingUnits, hostingUnitPath);// load the new list back to the Xml by using the function:"SaveToXML"
            }
        }

        /// <summary>
        /// this function update a host in the Xml
        /// </summary>
        /// <param name="host"></param>
        public void UpdateHost(Host host)
        {
            List<Host> hosts = GetHosts();
            if (!hosts.Exists(h => h.HostKey == host.HostKey))//checks using lambda and the function:"Exists", if there is no host with the same key in the new list
                throw new ObjectNotFoundExcetion(host.PrivateName, "Host");
            else
            {
                hosts.RemoveAll(h => h.HostKey == host.HostKey);// removing from the list the elements with the same key of our Host
                hosts.Add(host);// adding the updating Host to the list
                SaveToXML<List<Host>>(hosts, hostPath);// load the new list back to the Xml by using the function:"SaveToXML"
            }
        }

        /// <summary>
        /// we are finding the Order that we need to update, removing it from the list and entring insted the updating Order
        /// </summary>
        /// <param name="Order"></param>
        public void UpdateOrder(Order Order)
        {

            IEnumerable<XElement> XElements = (from order in orderRoot.Elements() // Serching using linq the Order that we need to update
                                               where int.Parse(order.Element("OrderKey").Value) == Order.OrderKey
                                               select order);
            //make sure Order exists in file
            if (XElements.ToList<XElement>().Count == 0) // if we didnt find the Order we were serching for...
                throw new ObjectNotFoundExcetion(Order.OrderKey.ToString(), "Order");

            XElement orderElement = XElements.FirstOrDefault();// creating new element and initializing it with the Order that we want to remove
            orderElement.Remove();// removing it
            orderRoot.Save(orderPath);
            AddOrder(Order); // instead of the Order we erased we adding the updating Order 
            orderRoot.Save(orderPath);// saving to Xml
        }
        #endregion

        #region get element list

        /// <summary>
        /// using the function: "LoadFromXML", this function gives the list of all the guest requests
        /// </summary>
        /// <returns>list of all the guest requests</returns>
        public List<GuestRequest> GetGuestRequests()
        {
            return LoadFromXML<List<GuestRequest>>(guestRequestPath);
        }

        /// <summary>
        /// using the function: "LoadFromXML", this function gives the list of all the hosting units
        /// </summary>
        /// <returns>list of all the hosting units</returns>
        public List<HostingUnit> GetHostingUnits()
        {
            return LoadFromXML<List<HostingUnit>>(hostingUnitPath);
        }

        /// <summary>
        /// using the function: "LoadFromXML", this function gives the list of all the hosts
        /// </summary>
        /// <returns>list of all the hosts</returns>
        public List<Host> GetHosts()
        {
            return LoadFromXML<List<Host>>(hostPath);
        }

        /// <summary>
        /// returns the bank branch
        /// </summary>
        /// <returns>BankBranch</returns>
        public List<BankBranch> GetBankBranches()
        {
            return bankBranches;
        }
        /// <summary>
        /// this function returns a list with all the orders
        /// </summary>
        /// <returns>list with all the orders</returns>
        public List<Order> GetOrders()
        {
            try
            {
                LoadOrderData();// loading from the Xml the orderRoot
            }
            catch(Exception ex)
            {
                throw ex;
            }
                List<Order> orders = new List<Order>();
            try
            {
                var x = orderRoot;
                orders = (from order in orderRoot.Elements()//go throw all the orders with linq
                          select new Order()
                          {
                              HostingUnitKey = int.Parse(order.Element("HostingUnitKey").Value),//initializing all the orders sons with the valus from the Xml
                              GuestRequestKey = int.Parse(order.Element("GuestRequestKey").Value),
                              OrderKey = int.Parse(order.Element("OrderKey").Value),
                              Status = (MyOrder)Enum.Parse(typeof(MyOrder), order.Element("Status").Value),
                              CreateDate = DateTime.Parse(order.Element("CreateDate").Value),
                              Commission = int.Parse(order.Element("Commission").Value),
                              SentMailDate = DateTime.Parse(order.Element("SentMailDate").Value)
                          }).ToList();//converting the iEnumrble list to a order list
            }
            catch
            {
                orders = null;
            }
            return orders;
        }
        #endregion

        #region create file

        /// <summary>
        /// this function save the orderRoot to the Xml by deleting the privius orderRoot if it was exist 
        /// </summary>
        private void CreateOrderFile()
        {
            orderRoot.Save(orderPath);
        }

        /// <summary>
        /// save the configurationRoot to the Xml by deleting the privius configurationRoot if it was exist 
        /// </summary>
        private void CreateConfigurationFile()
        {
            configurationRoot.Save(configurationPath);
        }
        #endregion

        #region load data

        /// <summary>
        /// initializing the orderRoot with the elements from the Xml
        /// </summary>
        private void LoadOrderData()
        {
            try
            {
                orderRoot = XElement.Load(orderPath);
            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }

        /// <summary>
        /// initializing the BE.Configuration with the configurationRoot from the Xml
        /// </summary>
        private void LoadConfigurationData()
        {
            try
            {
                configurationRoot = XElement.Load(configurationPath);
                if (configurationRoot.Element("IdalKey") != null)
                    Configuration.IdalKey = int.Parse(configurationRoot.Element("IdalKey").Value);

                if (configurationRoot.Element("HostingUnitKey") != null)
                    Configuration.HostingUnitKey = int.Parse(configurationRoot.Element("HostingUnitKey").Value);

                if (configurationRoot.Element("GuestRequestKey") != null)
                    Configuration.GuestRequestKey = int.Parse(configurationRoot.Element("GuestRequestKey").Value);

                if (configurationRoot.Element("OrderKey") != null)
                    Configuration.OrderKey = int.Parse(configurationRoot.Element("OrderKey").Value);

                if (configurationRoot.Element("HostKey") != null)
                    Configuration.HostKey = int.Parse(configurationRoot.Element("HostKey").Value);

            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }

        /// <summary>
        /// load the bank branchs using Oshris server
        /// </summary>
        public void loadBankBranches()
        {

            WebClient wc = new WebClient();
            try
            {
                throw new Exception();
                string xmlServerPath = @"http://www.boi.org.il/he/BankingSupervision/BanksAndBranchLocations/Lists/BoiBankBranchesDocs/atm.xml";
                wc.DownloadFile(xmlServerPath, xmlLocalPath);
            }
            catch (Exception)
            {
                string xmlServerPath = @"http://www.jct.ac.il/~coshri/atm.xml";
                wc.DownloadFile(xmlServerPath, xmlLocalPath);
            }
            finally
            {
                wc.Dispose();
            }
            atmRoot = XElement.Load(xmlLocalPath);
            List<BankBranch> duplicatedBankBranches = (from bb in atmRoot.Elements() // going throw all the bank branchs using linq
                                                       select new BankBranch()
                                                       {
                                                           BankNumber = int.Parse(bb.Element("קוד_בנק").Value),
                                                           BankName = bb.Element("שם_בנק").Value,
                                                           BranchNumber = int.Parse(bb.Element("קוד_סניף").Value),
                                                           BranchAddress = bb.Element("כתובת_ה-ATM").Value,
                                                           BranchCity = bb.Element("ישוב").Value
                                                       }).ToList();

            var groupsOfSameBranch = duplicatedBankBranches.GroupBy(bb => new { bb.BankNumber, bb.BranchNumber });
            bankBranches = (from x in groupsOfSameBranch
                            select x.FirstOrDefault<BankBranch>()).ToList();

            //bankBranches = new List<BankBranch>();
        }

        #endregion

        /// <summary>
        /// this function uploading all the configuration to the Xml 
        /// </summary>
        /// <param name="elementName"></param>
        /// <param name="key"></param>
        private void updateElementKeyInConfiguration(string elementName, int key)
        {
            if (configurationRoot.Element(elementName) != null)
            {
                XElement xElement = configurationRoot.Element(elementName);
                if (int.Parse(xElement.Value) <= key)        //if the "new" key is bigger than the value of the conf element
                    xElement.Value = key.ToString();    //update the conf element
            }
            else
                configurationRoot.Add(new XElement(elementName, key));//if the file not exist- it's Pshita we should enter the key
            configurationRoot.Save(configurationPath);
        }

        #region Xml serialize

        /// <summary>
        /// upload the elements to the Xml
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="path"></param>
        public static void SaveToXML<T>(T source, string path)
        {
            FileStream file = new FileStream(path, FileMode.Create);
            XmlSerializer xmlSerializer = new XmlSerializer(source.GetType());
            xmlSerializer.Serialize(file, source);
            file.Close();
        }

        /// <summary>
        /// load from Xml to our program
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public static T LoadFromXML<T>(string path) where T : new()
        {
            try
            {
                FileStream file = new FileStream(path, FileMode.Open);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                T result = (T)xmlSerializer.Deserialize(file);
                file.Close();
                return result;
            }
            catch (FileNotFoundException)
            {
                return new T();
            }
        }

        #endregion

    }
}
