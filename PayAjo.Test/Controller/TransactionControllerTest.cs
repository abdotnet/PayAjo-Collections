using System;
using System.Collections.Generic;
using Xunit;

namespace PayAjo.Test.Controller
{
    public class TransactionControllerTest
    {
        //[Fact]
        [Theory]
        [InlineData(1, "Jignesh")]
        [InlineData(2, "Rakesh")]
        [InlineData(3, "Not Found")]
        public void Test11(int id , string transNo)
        {
            var lstItem = new List<String>() { };

            Assert.Equal(transNo, null);
        }

    }
}
