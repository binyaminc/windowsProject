using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BE
{
    public enum RequestStatus { Active, ClosedByWeb, ClosedBecauseOfTime};
    public enum Area { All, North, South, Center, Jerusalem};
    public enum Type { Zimmer, Hotel, Camping};
    public enum Pool { Necessary, Optional, Disinterested };
    public enum Jacuzzi { Necessary, Optional, Disinterested };
    public enum Garden { Necessary, Optional, Disinterested };
    public enum ChildrenAttractions { Necessary, Optional, Disinterested };
    public enum MyOrder { NotYetTreated, MailHasBeenSent, ClosedCustomerUnavailability, ClosedByCustomer};

    public enum Language { English, עברית };
}
