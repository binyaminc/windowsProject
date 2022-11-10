using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Host
    {
        private int hostKey;
        private string privateName;
        private string familyName;
        private int phoneNumber;
        private string mailAddress;
        private BankBranch bankBranchDetails;
        private int bankAccountNumber;
        private bool collectionClearance;
        private string password;

        public int HostKey { get => hostKey; set => hostKey = value; }
        public string PrivateName { get => privateName; set => privateName = value; }
        public string FamilyName { get => familyName; set => familyName = value; }
        public int PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string MailAddress { get => mailAddress; set => mailAddress = value; }
        public BankBranch BankBranchDetails { get => bankBranchDetails; set => bankBranchDetails = value; }
        public int BankAccountNumber { get => bankAccountNumber; set => bankAccountNumber = value; }
        public bool CollectionClearance { get => collectionClearance; set => collectionClearance = value; }
        public string Password { get => password; set => password = value; }

        public override string ToString()
        {
            string result = "HostKey: " + HostKey.ToString()
                + " PrivateName: " + PrivateName
                + " FamilyName: " + FamilyName
                + " FhoneNumber: " + PhoneNumber.ToString()
                + " MailAddress: " + MailAddress
                + " BankBranchDetails: " + BankBranchDetails.ToString()
                + " BankAccountNumber: " + BankAccountNumber.ToString()
                + " CollectionClearance: " + CollectionClearance;
            return result;




        }
    }
}
