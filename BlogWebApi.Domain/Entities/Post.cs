using System;
using BlogWebApi.Domain.Common.Validation;
using BlogWebApi.Domain.Models;

namespace BlogWebApi.Domain.Entities
{
    public class Post : BaseEntity
    {
        protected Post()
        {
        }

        public Post(PostModel postModel)
        {
            ValidateModel(postModel);
            
            this.Title = postModel.Title;
            this.CreationDate = DateTime.Now;
            this.Content = postModel.Content;
            this.Author = postModel.Author;
        }
        
        public string Title { get; private set; }

        public string Content { get; private set; }

        public DateTime CreationDate { get; private set; }

        public Author Author { get; private set; }

        public void UpdatePost(PostModel postModel)
        {
            ValidateModel(postModel);
            
            this.Title = postModel.Title;
            this.Content = postModel.Content;
            this.Author = postModel.Author;
        }

        private void ValidateModel(PostModel postModel)
        {
            ValidationExtensions.NullOrEmpty(postModel.Title, nameof(postModel.Title));
            ValidationExtensions.NullOrEmpty(postModel.Content, nameof(postModel.Content));
            ValidationExtensions.CheckLength(postModel.Title, nameof(postModel.Title), 2, 80);
            ValidationExtensions.CheckLength(postModel.Content, nameof(postModel.Content), 2, 300);
        }
    }
}
