using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimpleMessenger.DAL;
using SimpleMessenger.DAL.Repository.Implementations;
using SimpleMessenger.DAL.Repository.Interfaces;
using SimpleMessenger.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SimpleMessenger.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private readonly IAccountRepository _userRepo;
        private readonly IChatRepository _chatRepo;
        private readonly ILogger<ChatController> _logger;

        public ChatController(IAccountRepository userRepo, IChatRepository chatRepo, ILogger<ChatController> logger)
        {
            _userRepo = userRepo;
            _chatRepo = chatRepo;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            _logger.LogInformation("Chat precreation method is started.");

            var Result = await _userRepo.GetAccountsAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (Result.IsSucceeded)
            {
                _logger.LogInformation("Chat precreation method is successfully completed.");
                return View(Result.Data);
            }

            _logger.LogError($"Chat precreation method completed with error: {Result.Errors.FirstOrDefault()}");

            return NotFound($"{Result.Errors.FirstOrDefault()}");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int chatId)
        {
            _logger.LogInformation("Chat removal method is started.");

            var Result = await _chatRepo.DeleteChatAsync(chatId);

            if (Result.IsSucceeded)
            {
                _logger.LogInformation("Chat removal method is successfully completed.");
                return RedirectToAction("Yours", "Chat");
            }

            _logger.LogError($"Chat removal method completed with error: {Result.Errors.FirstOrDefault()}");

            return BadRequest(Result.Errors.FirstOrDefault());
        } 

        [HttpPost]
        public async Task<IActionResult> Create(string toUserId)
        {
            _logger.LogInformation("Chat creation method is started.");

            string fromId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string fromName = User.FindFirstValue(ClaimTypes.Name);

            var Result = await _chatRepo.CreateChatAsync(fromId, fromName, toUserId);
            if (Result.IsSucceeded)
            {
                _logger.LogInformation("Chat creation method is successfully completed.");
                return RedirectToAction("ById", "Chat", Result.Data);
            }

            _logger.LogError($"Chat creation method completed with error: {Result.Errors.FirstOrDefault()}");

            return BadRequest($"{Result.Errors.FirstOrDefault()}");
        }

        [HttpGet]
        public async Task<IActionResult> ById(int Id)
        {
            _logger.LogInformation("Chat selection method is started.");

            var Result = await _chatRepo.GetChatAsync(Id);

            if (Result.IsSucceeded)
            {
                _logger.LogInformation("Chat selection method is successfully completed.");

                return View(Result.Data);
            }

            _logger.LogError($"Chat selection method completed with error: {Result.Errors.FirstOrDefault()}");

            return BadRequest($"{Result.Errors.FirstOrDefault()}");
        }

        [HttpPost]
        public async Task<IActionResult> AddMessage(string chatId, string messageText, string user)
        {
            _logger.LogInformation("Adding message to the chat method is started.");

            var Result = await _chatRepo.AddMessageAsync(int.Parse(chatId), messageText, user);

            if (Result.IsSucceeded)
            {
                _logger.LogInformation("Adding message to the chat method is successfully completed.");

                return Ok();
            }

            _logger.LogError($"Chat selection method completed with error: {Result.Errors.FirstOrDefault()}");

            return BadRequest($"{Result.Errors.FirstOrDefault()}");
        }

        [HttpGet]
        public async Task<IActionResult> Yours()
        {
            _logger.LogInformation("Chat selection method is started.");

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var Result = await _chatRepo.GetChatsAsync(userId);
            if (Result.IsSucceeded)
            {
                _logger.LogInformation("Chat selection method is successfully completed.");

                return View(Result.Data);
            }

            _logger.LogError($"Chat selection method completed with error: {Result.Errors.FirstOrDefault()}");

            return BadRequest($"{Result.Errors.FirstOrDefault()}");
        }
    }
}
