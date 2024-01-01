using BlogWebApi.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace BlogWebApi.Domain.Entities
{
    public partial class Author : BaseEntity
    {
        protected Author()
        {
        }

        public Author(AuthorModel autorModel)
        {
            this.Name = autorModel.Name;
            this.Photo = autorModel.Photo;
        }

        public string Name { get; private set; }

        public string Photo { get; private set; }

        public IEnumerable<Post> Posts { get; set; }

        public void UpdateAuthor(AuthorModel autorModel)
        {
            this.Name = autorModel.Name;
            this.Photo = autorModel.Photo;
        }

        public void AddPost(Post post) => Posts.ToList().Add(post);
    }
}
