using System;
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
            this.Title = postModel.Title;
            this.Content = postModel.Content;
            this.Author = postModel.Author;
        }
    }
}
