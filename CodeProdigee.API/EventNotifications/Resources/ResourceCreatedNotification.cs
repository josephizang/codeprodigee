using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeProdigee.API.EventNotifications.Resources
{
    public class ResourceCreatedNotification
    {
        public Guid ResourceID { get; set; }

        public string ResourceUrl { get; set; }

        public DateTimeOffset DateAdded { get; set; }

    }
}
