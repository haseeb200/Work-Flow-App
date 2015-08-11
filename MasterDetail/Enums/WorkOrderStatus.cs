using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterDetail.Enums
{
    public enum WorkOrderStatus
    {
        Creating = 5,
        Created = 10,
        Processing = 15,
        Processed = 20,
        Certifying = 25,
        Certified = 30,
        Approving = 35,
        Approved = 40,
        Rejected = -10,
        Canceled = -20
    }
}