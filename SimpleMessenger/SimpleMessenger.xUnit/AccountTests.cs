
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SimpleMessenger.Controllers;
using SimpleMessenger.DAL.Repository.Interfaces;
using SimpleMessenger.DAL.Response;
using SimpleMessenger.Shared;
using System;
using Xunit;

namespace SimpleMessenger.xUnit
{
    public class AccountTests
    {
        private readonly AccountController _controller;
        private readonly Mock<IAccountRepository> _repoMock = new Mock<IAccountRepository>();
        private readonly Mock<ILogger<AccountController>> _loggerMock = new Mock<ILogger<AccountController>>();

        public AccountTests()
        {
            _controller = new AccountController(_repoMock.Object, _loggerMock.Object);
        }

        [Fact]
        public void Account_GetById_IfExists()
        {
            var account = new Account
            {
                Id = "userid",
                UserName = "username",
                Nickname = "nickname",
                Email = "email",
            };

            var response = new BaseResponse<Account>
            {
                IsSucceeded = true,
                Data = account,
            };

            _repoMock.Setup(x => x.GetAccountAsync(account.Id, null, null)).ReturnsAsync(response);

            var user = (ViewResult)_controller.ById(account.Id).Result;
            var entity = (Account)user.Model;

            Assert.NotNull(entity);
        }

        [Fact]
        public void Account_GetById_IfNotExists()
        {
            var account = new Account
            {
                Id = "userid",
            };

            var response = new BaseResponse<Account>
            {
                IsSucceeded = true,
                Data = null,
            };

            _repoMock.Setup(x => x.GetAccountAsync(account.Id, null, null)).ReturnsAsync(response);

            var user = (ViewResult)_controller.ById(account.Id).Result;
            var entity = (Account)user.Model;

            Assert.Null(entity);
        }
    }
}
