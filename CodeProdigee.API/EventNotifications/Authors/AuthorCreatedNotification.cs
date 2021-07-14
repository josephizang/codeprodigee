using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeProdigee.API.EventNotifications.Authors
{
    public class AuthorCreatedNotification : INotification
    {
        public Guid AuthorID { get; set; }

    }
}
