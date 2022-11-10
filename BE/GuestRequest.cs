using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BE
{
    public class GuestRequest 
    {
        private int guestRequestKey;
        private string privateName;
        private string familyName;
        private string mailAddress;
        private RequestStatus status;
        private DateTime registrationDate;
        private DateTime entryDate;
        private DateTime releaseDate;
        private Area area;
        private String subArea;
        private Type type;
        private int adults;
        private int children;
        private Pool pool;
        private Jacuzzi jacuzzi;
        private Garden garden;
        private ChildrenAttractions childrensAttractions;

        public int GuestRequestKey { get => guestRequestKey; set => guestRequestKey = value; }
        public string PrivateName { get => privateName; set => privateName = value; }
        public string FamilyName { get => familyName; set => familyName = value; }
        public string MailAddress { get => mailAddress; set => mailAddress = value; }
        public RequestStatus Status { get => status; set => status = value; }
        public DateTime RegistrationDate { get => registrationDate; set => registrationDate = value; }
        public DateTime EntryDate { get => entryDate; set => entryDate = value; }
        public DateTime ReleaseDate { get => releaseDate; set => releaseDate = value; }
        public Area Area { get => area; set => area = value; }
        public string SubArea { get => subArea; set => subArea = value; }
        public Type Type { get => type; set => type = value; }
        public int Adults { get => adults; set => adults = value; }
        public int Children { get => children; set => children = value; }
        public Pool Pool { get => pool; set => pool = value; }
        public Jacuzzi Jacuzzi { get => jacuzzi; set => jacuzzi = value; }
        public Garden Garden { get => garden; set => garden = value; }
        public ChildrenAttractions ChildrenAttractions { get => childrensAttractions; set => childrensAttractions = value; }

       

      


        public override string ToString()
        {
            string result = "";
            result = "GuestRequestKey: " + GuestRequestKey.ToString()
                + " PrivateName: " + PrivateName
                + " FamilyName: " + FamilyName
                + " MailAddress: " + MailAddress
                + " Status: " + Status.ToString()
                + " RegistrationDate: " + RegistrationDate.ToString()
                + " EntryDate: " + EntryDate.ToString()
                + " ReleaseDate: " + ReleaseDate.ToString()
                + " Area: " + Area.ToString()
                + " SubArea: " + SubArea
                + " Type: " + Type.ToString()
                + " Adults: " + Adults.ToString()
                + " Children: " + Children
                + " pool: " + Pool.ToString()
                + " Jacuzzi: " + Jacuzzi.ToString()
                + " Garden: " + Garden.ToString()
                + " ChildrensAttractions: " + ChildrenAttractions.ToString();
            return result;
        }
    }
}
