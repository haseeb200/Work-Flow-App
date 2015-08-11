using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterDetail.Enums
{
    public enum WidgetStatus
    {
        Created = 10,
        Integrating = 15,
        Integrated = 20,
        Approving = 25,
        Approved = 30,
        Canceled = -10
    }
}