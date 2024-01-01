using System.Collections.Generic;
using BlogWebApi.Domain.Models;

namespace BlogWebApi.Domain.Entities
{
    public class Author : BaseEntity
    {
        protected Author()
        {
        }

        public Author(AuthorModel authorModel)
        {
            this.Name = authorModel.Name;
            this.Photo = authorModel.Photo;
        }

        public string Name { get; private set; }

        public string Photo { get; private set; }

        public IEnumerable<Post> Posts { get; private set; }

        public void UpdateAuthor(AuthorModel authorModel)
        {
            this.Name = authorModel.Name;
            this.Photo = authorModel.Photo;
        }
    }
}
