using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleMessenger.DAL;
using SimpleMessenger.DAL.Repository.Implementations;
using SimpleMessenger.DAL.Repository.Interfaces;
using SimpleMessenger.Models;
using SimpleMessenger.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleMessenger.Controllers
{

    public class AccountController : Controller
    {
        private readonly IAccountRepository _repo;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IAccountRepository repo, ILogger<AccountController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            _logger.LogInformation("Opening login page.");
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            _logger.LogInformation("Opening registration page.");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInModel model)
        {
            
            _logger.LogInformation($"{model.Login}`s attempt to login is started.");

            if (ModelState.IsValid)
            {
                var accountResult = await _repo.GetAccountAsync(_userEmail: model.Login);
                if (accountResult.IsSucceeded)
                {
                    var result = await _repo.AccountSignInAsync(accountResult.Data, model.Password);
                    if (!result.IsSucceeded)
                    {
                        foreach (var errorMessage in accountResult.Errors)
                        {
                            ModelState.AddModelError("", errorMessage);
                            _logger.LogError($"{model.Login}`s attempt to login has failed: {errorMessage}");
                        }
                        
                        return View(model);
                    }

                    _logger.LogInformation($"{model.Login}`s attempt to login is successfully completed.");
                    return RedirectToAction("Index", "Home");
                }
                foreach (var errorMessage in accountResult.Errors)
                {
                    ModelState.AddModelError("", errorMessage);
                    _logger.LogError($"{model.Login}`s attempt to login has failed: {errorMessage}");
                }

                return View(model);
            }
            _logger.LogError("Error: model is not valid.");
            return View();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(string userId)
        {
            var Result = await _repo.GetAccountAsync(_userId: userId);

            if (!Result.IsSucceeded)
                return BadRequest();

            var user = Result.Data;

            return View(new AccountUpdateModel()
            {
                Id = user.Id,
                Username = user.UserName,
                Nickname = user.Nickname,
                Login = user.Email
            });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(AccountUpdateModel model)
        {
            _logger.LogInformation($"Attempt to update the account`s info is started.");

            if (!ModelState.IsValid)
                return View(model);

            var retrievedAccountResult = await _repo.GetAccountAsync(model.Id);

            if (!retrievedAccountResult.IsSucceeded)
            {
                foreach (var errorMessage in retrievedAccountResult.Errors)
                {
                    ModelState.AddModelError("", errorMessage);
                    _logger.LogError($"{model.Login}`s attempt to update the account`s info has failed: {errorMessage}");
                }

                return View(model);
            }

            retrievedAccountResult.Data.UserName = model.Username;
            retrievedAccountResult.Data.Email = model.Login;
            retrievedAccountResult.Data.Nickname = model.Nickname;

            var Result = await _repo.UpdateAccountAsync(retrievedAccountResult.Data, model.OldPassword, model.NewPassword);
            if (!Result.IsSucceeded)
            {
                foreach (var errorMessage in Result.Errors)
                {
                    ModelState.AddModelError("", errorMessage);
                    _logger.LogError($"{model.Login}`s attempt to update the account`s info has failed: {errorMessage}");
                }

                return View(model);
            }

            Result.Data.PasswordHash = null;

            _logger.LogInformation("Attempt to update the account`s info has successfully completed.");
            return RedirectToAction("ById", routeValues: Result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            _logger.LogInformation("Attempt to register new account is started.");

            if (ModelState.IsValid)
            {
                Account account = new Account()
                {
                    UserName = model.Username,
                    Email = model.Login,
                    Nickname = model.Nickname,
                };

                var Result = await _repo.CreateAccountAsync(account, model.ConfirmPassword);

                if (Result.IsSucceeded)
                {
                    _logger.LogInformation($"{model.Login} has successfully signed up.");

                        _logger.LogInformation($"{model.Login} has successfully signed up and signed in.");
                        return RedirectToAction("Index", "Home");
                }

                foreach (var errorMessage in Result.Errors)
                {
                    ModelState.AddModelError("", errorMessage);
                    _logger.LogError($"{model.Login}`s attempt to sign up info has failed: {errorMessage}");
                }

                return View(model);
            }

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            _logger.LogInformation("Current user signing out method is started.");
            var Result = await _repo.AccountSignOutAsync();

            if (Result.IsSucceeded)
            {
                _logger.LogInformation("Current user signing out method has successfully completed.");
                return RedirectToAction("Index", "Home");
            }
            _logger.LogError("Error while trying to sign out.");
            return BadRequest();
        }

        [HttpGet("{controller}/{action}/{userId}")]
        [Authorize]
        public async Task<IActionResult> ById(string userId)
        {
            _logger.LogInformation("Retrieving account method is started.");
            var Result = await _repo.GetAccountAsync(_userId: userId);
            if (Result.IsSucceeded)
            {
                _logger.LogInformation("Retrieving account method has successfully completed.");
                return View(Result.Data);
            }
            _logger.LogError("Error: user`s not found.");
            return NotFound();
        }
    }
}
