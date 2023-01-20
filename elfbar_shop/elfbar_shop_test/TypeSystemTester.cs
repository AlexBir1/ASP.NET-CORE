using AutoFixture;
using elfbar_shop.Controllers;
using elfbar_shop.DAL.Services.Interfaces;
using elfbar_shop.Domain.Response;
using elfbar_shop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace elfbar_shop_test
{
    [TestClass]
    public class TypeSystemTester
    {
        private Mock<ITypesService> Types { get; set; }
        private Fixture fixture;
        private TypesController typesController;
        private IEnumerable<TypesViewModel> FakeTypes;

        public TypeSystemTester()
        {
            Types = new Mock<ITypesService>();
            fixture = new Fixture();
            FakeTypes = fixture.CreateMany<TypesViewModel>(10).ToList();
        }

        [TestMethod]
        public void GetTypesTest()
        {
            Types.Setup(Service => Service.GetTypes()).ReturnsAsync(
                new DBResponse<TypesPageViewModel>
                {
                    StatusCode = StatusCodes.OK,
                    Description = "test",
                    Data = new TypesPageViewModel
                    {
                        TypeList = FakeTypes.ToList()
                    }
                });

            typesController = new TypesController(Types.Object);
            var Result = (ViewResult)typesController.GetTypes().Result;
            TypesPageViewModel model = (TypesPageViewModel)Result.ViewData.Model;

            Xunit.Assert.Null(model.title);

            Xunit.Assert.IsType<List<TypesViewModel>>(model.TypeList);

            Xunit.Assert.Equal(0, model.id);
            Xunit.Assert.Equal(10, model.TypeList.Count);
            Xunit.Assert.Equal(model.TypeList.Count, Types.Object.GetTypes().Result.Data.TypeList.Count);

        }
    }
}
