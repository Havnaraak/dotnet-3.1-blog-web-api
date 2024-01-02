using System;
using System.Collections.Generic;
using System.Linq;
using BlogWebApi.Domain.Common;
using BlogWebApi.Domain.Common.Validation;
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
            ValidateModel(authorModel);

            this.Name = authorModel.Name;
            this.Photo = authorModel.Photo;
        }

        public string Name { get; private set; }

        public string Photo { get; private set; }

        public IEnumerable<Post> Posts { get; private set; }

        public void UpdateAuthor(AuthorModel authorModel)
        {
            ValidateModel(authorModel);
            
            this.Name = authorModel.Name;
            this.Photo = authorModel.Photo;
        }

        private void ValidateModel(AuthorModel authorModel)
        {
            ValidationExtensions.NullOrEmpty(authorModel.Name, nameof(authorModel.Name));
            ValidationExtensions.NullOrEmpty(authorModel.Photo, nameof(authorModel.Photo));
            ValidationExtensions.CheckLength(authorModel.Name, nameof(authorModel.Name), 2, 100);
            ValidationExtensions.CheckLength(authorModel.Photo, nameof(authorModel.Photo), 2, 300);
        }
    }
}
