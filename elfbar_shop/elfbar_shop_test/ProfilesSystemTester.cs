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
    public class ProfilesSystemTester
    {
        private Mock<IProfilesService> Profiles { get; set; }
        private Fixture fixture;
        private ProfilesController profilesController;
        private IEnumerable<ProfilesViewModel> FakeProfiles;

        public ProfilesSystemTester()
        {
            Profiles = new Mock<IProfilesService>();
            fixture = new Fixture();
            FakeProfiles = fixture.CreateMany<ProfilesViewModel>(5);
        }

        [TestMethod]
        public void GetProfilesTest() 
        {
            Profiles.Setup(service => service.GetProfiles()).Returns(new DBResponse<IEnumerable<ProfilesViewModel>>
            {
                Data = FakeProfiles.ToList(),
                Description = "test",
                StatusCode = StatusCodes.OK
            });
            profilesController = new ProfilesController(Profiles.Object);

            foreach (var item in Profiles.Object.GetProfiles().Data.ToList()) 
            {
                var Result = (ViewResult)profilesController.GetProfile(item);
                ProfilesViewModel model = (ProfilesViewModel)Result.ViewData.Model;
                Xunit.Assert.Equal(item, model);
            }
            
        }
    }
}
