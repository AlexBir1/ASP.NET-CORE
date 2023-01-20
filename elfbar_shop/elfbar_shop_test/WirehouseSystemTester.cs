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
    public class WirehouseSystemTester
    {
        private Mock<IWirehousesService> Wirehouses { get; set; }
        private Fixture fixture;
        private WirehousesController wirehousesController;
        private IEnumerable<WirehousesViewModel> FakeWirehouses;
        private IEnumerable<SelectListItem> FakeOwners;
        private IEnumerable<SelectListItem> FakeTypes;

        public WirehouseSystemTester()
        {
            Wirehouses = new Mock<IWirehousesService>();
            fixture = new Fixture();
            FakeWirehouses = fixture.CreateMany<WirehousesViewModel>(10).ToList();
            FakeTypes = fixture.CreateMany<SelectListItem>(10).ToList();
            FakeOwners = fixture.CreateMany<SelectListItem>(10).ToList();
        }
        [TestMethod]
        public void GetWirehousesTest()
        {
            Wirehouses.Setup(service => service.GetWs()).ReturnsAsync(new DBResponse<WirehousesPageViewModel>
            {
                Data = new WirehousesPageViewModel 
                {
                    ProductList = FakeWirehouses.ToList(),
                    OwnerList = FakeOwners.ToList(),
                    ProdTypes = FakeTypes.ToList()
                },
                Description = "test",
                StatusCode = StatusCodes.OK
            });
            wirehousesController = new WirehousesController(Wirehouses.Object, null);
            var Result = (ViewResult)wirehousesController.GetW(null, null).Result;
            WirehousesPageViewModel model = (WirehousesPageViewModel)Result.ViewData.Model;

            Xunit.Assert.Equal(0, model.id);
            Xunit.Assert.Equal(0, model.cost);
            Xunit.Assert.Equal(0, model.quantity);

            Xunit.Assert.Null(model.type_name);
            Xunit.Assert.Null(model.title);
            Xunit.Assert.Null(model.owner_alias);
            Xunit.Assert.Null(model.GetByOwner);
            Xunit.Assert.Null(model.GetByType);
            Xunit.Assert.Null(model.Product);

            Xunit.Assert.Equal(Wirehouses.Object.GetWs().Result.Data.ProdTypes.Count, model.ProdTypes.Count);
            Xunit.Assert.Equal(Wirehouses.Object.GetWs().Result.Data.ProductList.Count, model.ProductList.Count);
            Xunit.Assert.Equal(10, model.ProdTypes.Count);
            Xunit.Assert.Equal(10, model.ProductList.Count);
        }
    }
}
