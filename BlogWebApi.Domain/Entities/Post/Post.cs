using System;

namespace BlogWebApi.Domain.Entities
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreationDate { get; set; }

        public Author Author { get; set; }
    }
}
