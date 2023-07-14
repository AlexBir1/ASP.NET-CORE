using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleMessenger.DAL.Repository.Implementations;
using SimpleMessenger.MessengerAPI.Models;
using SimpleMessenger.Shared;
using System.Threading.Tasks;

namespace SimpleMessenger.MessengerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly AccountRepository _repo;
        private readonly ILogger<AccountController> _logger;

        public AccountController(AccountRepository repo, ILogger<AccountController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        [HttpPost("[action]")]
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
                            _logger.LogError($"{model.Login}`s attempt to login has failed: {errorMessage}");
                        }

                        return BadRequest(result);
                    }

                    _logger.LogInformation($"{model.Login}`s attempt to login is successfully completed.");
                    return Ok(result);
                }
                foreach (var errorMessage in accountResult.Errors)
                {
                    ModelState.AddModelError("", errorMessage);
                    _logger.LogError($"{model.Login}`s attempt to login has failed: {errorMessage}");
                }
                return BadRequest(accountResult);
                
            }
            _logger.LogError("Error: model is not valid.");
            return BadRequest();
        }

        [HttpPatch("{Id}")]
        [Authorize]
        public async Task<IActionResult> Edit(AccountUpdateModel model)
        {
            _logger.LogInformation($"Attempt to update the account`s info is started.");

            if (!ModelState.IsValid)
                return BadRequest();

            var retrievedAccountResult = await _repo.GetAccountAsync(model.Id);

            if (!retrievedAccountResult.IsSucceeded)
            {
                foreach (var errorMessage in retrievedAccountResult.Errors)
                {
                    ModelState.AddModelError("", errorMessage);
                    _logger.LogError($"{model.Login}`s attempt to update the account`s info has failed: {errorMessage}");
                }

                return BadRequest(retrievedAccountResult);
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

                return BadRequest(Result);
            }

            Result.Data.PasswordHash = null;

            _logger.LogInformation("Attempt to update the account`s info has successfully completed.");
            return Ok(Result);
        }

        [HttpPost("[action]")]
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
                    var signInResult = await _repo.AccountSignInAsync(account, model.ConfirmPassword);

                    if (signInResult.IsSucceeded)
                    {
                        _logger.LogInformation($"{model.Login} has successfully signed up and signed in.");
                        return RedirectToAction("Index", "Home");
                    }
                        
                    foreach (var errorMessage in signInResult.Errors)
                    {
                        ModelState.AddModelError("", errorMessage);
                        _logger.LogError($"{model.Login}`s attempt to sign in info has failed: {errorMessage}");
                    }

                    return View(model);
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

        [HttpGet("[action]")]
        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            _logger.LogInformation("Current user signing out method is started.");
            var Result = await _repo.AccountSignOutAsync();

            if (Result.IsSucceeded)
            {
                _logger.LogInformation("Current user signing out method has successfully completed.");
                return Ok(Result);
            }
            _logger.LogError("Error while trying to sign out.");
            return BadRequest(Result);
        }

        [HttpGet("{userId}")]
        [Authorize]
        public async Task<IActionResult> ById(string userId)
        {
            _logger.LogInformation("Retrieving account method is started.");
            var Result = await _repo.GetAccountAsync(_userId: userId);
            if (Result.IsSucceeded)
            {
                _logger.LogInformation("Retrieving account method has successfully completed.");
                return Ok(Result);
            }
            _logger.LogError("Error: user`s not found.");
            return NotFound(Result);
        }
    }
}
