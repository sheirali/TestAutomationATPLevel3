using NUnit.Framework;
using Unicorn.Web;

namespace Unicorn.FrameworkTests
{
    public class PurchaseTest : WebTest
    {
        ////[SetUp]
        ////public void Setup()
        ////{
        ////}

        [Test]
        public void Test1()
        {
            Button button = App.ElementCreateService.CreateById<Button>("myID").ToExists().ToBeClickable();
            Assert.Pass();
        }
    }
}