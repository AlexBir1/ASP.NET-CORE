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
    public class LaughSystenTester
    {
        private Mock<ILaughService> Laugh { get; set; }
        private Fixture fixture;
        private LaughController laughController;
        private LaughViewModel FakeJoke;

        public LaughSystenTester()
        {
            Laugh = new Mock<ILaughService>();
            fixture = new Fixture();
            FakeJoke = fixture.Create<LaughViewModel>();
        }
        [TestMethod]
        public void GetJokesTest() 
        {
            Laugh.Setup(service => service.GetLs()).Returns(new DBResponse<LaughPageViewModel>
            {
                Description = "test",
                StatusCode = StatusCodes.OK,
                Data = new LaughPageViewModel
                {
                    _Laugh = FakeJoke
                }
            });

            laughController = new LaughController(Laugh.Object);
            var Result = (ViewResult)laughController.GetLs();
            LaughPageViewModel model = (LaughPageViewModel)Result.ViewData.Model;

            Xunit.Assert.NotNull(model._Laugh);
            Xunit.Assert.Same(Laugh.Object.GetLs().Data._Laugh, model._Laugh);
            Xunit.Assert.Equal(0, model.id);
            Xunit.Assert.Null(model.str);
        }
    }
}
