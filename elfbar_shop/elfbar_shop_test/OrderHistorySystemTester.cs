using AutoFixture;
using elfbar_shop.Controllers;
using elfbar_shop.DAL.Services.Interfaces;
using elfbar_shop.Domain.Response;
using elfbar_shop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class OrderHistorySystemTester
    {
        private Mock<IOrderHistoryService> OHistories { get; set; }
        private Fixture fixture;
        private OrderHistoryController orderHistoryController;
        private IEnumerable<OrderHistoryViewModel> FakeOHistories;
        private IEnumerable<SelectListItem> FakeSellers;

        public OrderHistorySystemTester()
        {
            OHistories = new Mock<IOrderHistoryService>();
            fixture = new Fixture();
            FakeOHistories = fixture.CreateMany<OrderHistoryViewModel>(10);
            FakeSellers = fixture.CreateMany<SelectListItem>(10);
        }

        [TestMethod]
        public void GetOHistoriesTest() 
        {
            OHistories.Setup(service => service.GetOHistories()).Returns(new DBResponse<OrderHistoryPageViewModel>
            {
                Description = "test",
                StatusCode = StatusCodes.OK,
                Data = new OrderHistoryPageViewModel
                {
                    SellerList = FakeSellers.ToList(),
                    OHistoryList = FakeOHistories.ToList()
                }
            });

            orderHistoryController = new OrderHistoryController(OHistories.Object);
            var Result = (ViewResult)orderHistoryController.GetOHistories("");
            OrderHistoryPageViewModel model = (OrderHistoryPageViewModel)Result.ViewData.Model;

            Xunit.Assert.NotNull(model.SellerList);
            Xunit.Assert.NotNull(model.OHistoryList);

            Xunit.Assert.Null(model.product_name);
            Xunit.Assert.Null(model.product_type);
            Xunit.Assert.Null(model.seller_alias);
            Xunit.Assert.Null(model.GetBySeller);

            Xunit.Assert.Equal(0, model.id);
            Xunit.Assert.Equal(OHistories.Object.GetOHistories().Data.OHistoryList.Count, model.OHistoryList.Count);
            Xunit.Assert.Equal(OHistories.Object.GetOHistories().Data.SellerList.Count, model.SellerList.Count);
        }
    }
}
