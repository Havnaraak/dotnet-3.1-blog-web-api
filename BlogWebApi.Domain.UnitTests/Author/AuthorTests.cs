using System;
using BlogWebApi.Domain.Models;
using BlogWebApi.Domain.UnitTests.Common;
using Bogus;
using Xunit;

namespace BlogWebApi.Domain.UnitTests.Author
{
    public class AuthorTests
    {
        private Faker<AuthorModel> _authorModelFaker;
        
        [Fact]
        public void MustCreateAuthor()
        {
            _authorModelFaker = new Faker<AuthorModel>();
            
            var authorModel = _authorModelFaker
                .RuleFor(m => m.Name, faker => faker.Name.FirstName())
                .RuleFor(m => m.Photo, faker => faker.Image.ToString())
                .Generate();
            
            var author = new Entities.Author(authorModel);
            
            Assert.Equal(author.Name, authorModel.Name);
            Assert.Equal(author.Photo, authorModel.Photo);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void MustFailWithNullOrEmptyName(string value)
        {
            _authorModelFaker = new Faker<AuthorModel>();

            _authorModelFaker
                .RuleFor(m => m.Name, value);

            Assert.Throws<ArgumentException>(() =>
            {
                var author = new Entities.Author(_authorModelFaker.Generate());
            }).WithValidationProperty(nameof(Entities.Author.Name));
        }
        
        [Theory]
        [InlineData(1)]
        [InlineData(200)]
        public void MustFailWithOutOfRangeName(int range)
        {
            _authorModelFaker = new Faker<AuthorModel>();

            _authorModelFaker
                .RuleFor(m => m.Name, faker => faker.Random.String2(range))
                .RuleFor(m => m.Photo, faker => faker.Image.ToString());

            var authorModel = _authorModelFaker.Generate();

            Assert.Throws<ArgumentException>(() =>
            {
                var author = new Entities.Author(authorModel);
            }).WithValidationProperty(nameof(Entities.Author.Name));
        }
        
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void MustFailWithNullOrEmptyPhoto(string value)
        {
            _authorModelFaker = new Faker<AuthorModel>();

            _authorModelFaker
                .RuleFor(m => m.Name, value)
                .RuleFor(m => m.Name, faker => faker.Name.FirstName());

            Assert.Throws<ArgumentException>(() =>
            {
                var author = new Entities.Author(_authorModelFaker.Generate());
            }).WithValidationProperty(nameof(Entities.Author.Photo));
        }
        
        [Theory]
        [InlineData(1)]
        [InlineData(301)]
        public void MustFailWithOutOfRangePhoto(int range)
        {
            _authorModelFaker = new Faker<AuthorModel>();

            _authorModelFaker
                .RuleFor(m => m.Photo, faker => faker.Random.String2(range))
                .RuleFor(m => m.Name, faker => faker.Name.FirstName());

            var authorModel = _authorModelFaker.Generate();

            Assert.Throws<ArgumentException>(() =>
            {
                var author = new Entities.Author(authorModel);
            }).WithValidationProperty(nameof(Entities.Author.Photo));
        }
    }
}