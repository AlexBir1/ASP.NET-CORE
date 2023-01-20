using AutoFixture;
using elfbar_shop.Controllers;
using elfbar_shop.DAL.Services.Interfaces;
using elfbar_shop.Domain.Response;
using elfbar_shop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace elfbar_shop_test
{
    [TestClass]
    public class ProductSystemTester
    {
        private Mock<IProductService> Product { get; set; }
        private Fixture fixture;
        private ProductController productController;
        private IEnumerable<ProductViewModel> FakeProducts;
        private IEnumerable<SelectListItem> FakeTypes;

        public ProductSystemTester()
        {
            Product = new Mock<IProductService>();
            fixture = new Fixture();
            FakeProducts = fixture.CreateMany<ProductViewModel>(10).ToList();
            FakeTypes = fixture.CreateMany<SelectListItem>(10).ToList();
        }

        [TestMethod]
        public void GetProductsTest()
        {
            Product.Setup(s => s.GetProducts())
                .ReturnsAsync(
                new DBResponse<ProductPageViewModel>
                {
                    StatusCode = StatusCodes.OK,
                    Description = "test",
                    Data = new ProductPageViewModel
                    {
                        ProductList = FakeProducts.ToList(),
                        ProdTypes = FakeTypes.ToList(),
                    }
                });

            productController = new ProductController(Product.Object, null);
            var Result = (ViewResult)productController.GetProducts(null).Result;
            ProductPageViewModel model = (ProductPageViewModel)Result.ViewData.Model;

            Xunit.Assert.IsType<List<ProductViewModel>>(model.ProductList);
            Xunit.Assert.IsType<List<SelectListItem>>(model.ProdTypes);

            Xunit.Assert.NotNull(model.ProdTypes);

            Xunit.Assert.Null(model.ProdNames);
            Xunit.Assert.Null(model.Product);

            Xunit.Assert.Equal(10, model.ProductList.Count);
            Xunit.Assert.Equal(10, model.ProdTypes.Count);
            Xunit.Assert.Equal(model.ProductList.Count, Product.Object.GetProducts().Result.Data.ProductList.Count);
        }
    }
}
