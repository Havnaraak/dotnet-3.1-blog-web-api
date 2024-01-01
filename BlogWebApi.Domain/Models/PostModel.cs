using BlogWebApi.Domain.Entities;

namespace BlogWebApi.Domain.Models
{
    public class PostModel
    {
        public string Title { get; set; }
        
        public string Content { get; set; }
        
        public Author Author { get; set; }
    }
}
