using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeProdigee.API.EventNotifications.Posts
{
    public class PostCreatedNotification : INotification
    {
        public Guid PostID { get; set; }
        public string PostTitle { get; set; }

        public string AuthorName { get; set; }

        public DateTimeOffset PublishedAt { get; set; }

        public string ResourceLink { get; set; }

        public string TagList { get; set; }

        public string PostUrl { get; set; }
    }
}
