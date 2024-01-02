using BlogWebApi.Domain.Models;
using Bogus;
using Xunit;

namespace BlogWebApi.DomainTests.Author
{
    public class AuthorTest
    {
        [Fact]
        public void DeveCriarAuthor()
        {
            var fakerAuthorModel = new Faker<AuthorModel>();
        }
    }
}