using System;
using Xunit;

namespace BlogWebApi.Domain.UnitTests.Common
{
    public static class AssertExtension
    {
        public static void WithValidationProperty(this ArgumentException exception, string property)
        {
            if (exception.Message.Contains(property))
                Assert.True(true);
            else
                Assert.False(true);
        }
    }
}