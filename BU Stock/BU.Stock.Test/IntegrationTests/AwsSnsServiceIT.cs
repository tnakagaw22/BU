using BU.Stock.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BU.Stock.Test.IntegrationTests
{
    [TestClass]
    public class AwsSnsServiceIT
    {
        [TestCategory("Integration")]
        [TestMethod]
        public void PublishMessage()
        {
            var awsSnsService = new AwsSnsService();
            var result = awsSnsService.PublishMessage("test", "test test test", "arn:aws:sns:us-west-2:767567474540:StockAlert");

            Assert.IsTrue(result);
        }
    }
}
