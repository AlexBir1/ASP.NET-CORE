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
    public class SpendsSystemTester
    {
        private Mock<ISpendsService> Spends { get; set; }
        private Fixture fixture;
        private SpendsController spendsController;
        private IEnumerable<SpendsViewModel> FakeSpends;

        public SpendsSystemTester()
        {
            Spends = new Mock<ISpendsService>();
            fixture = new Fixture();
            FakeSpends = fixture.CreateMany<SpendsViewModel>(10).ToList();
        }

        [TestMethod]
        public void GetSpendsTest()
        {
            Spends.Setup(Service => Service.GetSpends()).ReturnsAsync(
                new DBResponse<SpendsPageViewModel>
                {
                    StatusCode = StatusCodes.OK,
                    Description = "test",
                    Data = new SpendsPageViewModel
                    {
                        SpendList = FakeSpends.ToList()
                    }
                });

            spendsController = new SpendsController(Spends.Object);
            var Result = (ViewResult)spendsController.GetSpends().Result;
            SpendsPageViewModel model = (SpendsPageViewModel)Result.ViewData.Model;

            Xunit.Assert.IsType<List<SpendsViewModel>>(model.SpendList);

            Xunit.Assert.Null(model.spend_title);

            Xunit.Assert.Equal(10, model.SpendList.Count);
            Xunit.Assert.Equal(0, model.id);
            Xunit.Assert.Equal(0, model.cost);
            Xunit.Assert.Equal(model.SpendList.Count, Spends.Object.GetSpends().Result.Data.SpendList.Count);
        }
    }
}
