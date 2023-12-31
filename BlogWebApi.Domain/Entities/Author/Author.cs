using BlogWebApi.Domain.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace BlogWebApi.Domain.Entities
{
    public partial class Author : BaseEntity
    {
        public string Name { get; set; }

        public string Photo { get; set; }

        public IEnumerable<Post> Posts { get; set; }

        public Author()
        {
        }

        public Author(NewAuthorDTO dto)
        {
            this.Name = dto.Name;
            this.Photo = dto.Photo;
        }

        protected void AddPost(Post post) => Posts.ToList().Add(post);
    }
}
