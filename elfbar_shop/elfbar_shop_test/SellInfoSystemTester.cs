using AutoFixture;
using elfbar_shop.Controllers;
using elfbar_shop.DAL.Services.Interfaces;
using elfbar_shop.Domain.Response;
using elfbar_shop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elfbar_shop_test
{
    [TestClass]
    public class SellInfoSystemTester
    {
        private Mock<ISell_InfoService> sell_info { get; set; }
        private Fixture fixture;
        private SellInfoController siController;
        private Sell_InfoViewModel FakeSI;

        public SellInfoSystemTester()
        {
            sell_info = new Mock<ISell_InfoService>();
            fixture = new Fixture();
            FakeSI = fixture.Create<Sell_InfoViewModel>();
        }
        [TestMethod]
        public void GetSITest()
        {
            sell_info.Setup(service => service.GetSell_info()).Returns(new DBResponse<Sell_InfoViewModel>
            {
                StatusCode = StatusCodes.OK,
                Description = "test",
                Data = FakeSI
            });

            siController = new SellInfoController(sell_info.Object);
            var Result = (ViewResult)siController.GetSInfo();
            Sell_InfoViewModel model = (Sell_InfoViewModel)Result.ViewData.Model;

            Xunit.Assert.NotNull(model);
            Xunit.Assert.Same(model, sell_info.Object.GetSell_info().Data);
        }
    }
}
