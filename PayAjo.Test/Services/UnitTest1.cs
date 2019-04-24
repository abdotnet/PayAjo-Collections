using System;
using System.Threading.Tasks;
using Xunit;

namespace PayAjo.Test.Services
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Task.Run(() =>
            {
                throw new Exception("Testing what happens");
            });
        }
    }
}
