using System.Collections.Generic;

namespace BlogWebApi.Domain.Entities
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }

        public string Photo { get; set; }

        public IEnumerable<Post> Posts { get; set; }
    }
}
