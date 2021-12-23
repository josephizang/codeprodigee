using MediatR;
using System;

namespace CodeProdigee.API.EventNotifications.Posts
{
    public class PostCreatedNotification : INotification
    {
        public Guid PostID { get; set; }
        public string PostTitle { get; set; }

        public string AuthorFirstName { get; set; }

        public string AuthorLastName { get; set; }

        public string AuthorId { get; set; }

        public DateTimeOffset PublishedAt { get; set; }

        public string ResourceLink { get; set; }

        public string TagList { get; set; }

        public string PostUrl { get; set; }
    }
}
