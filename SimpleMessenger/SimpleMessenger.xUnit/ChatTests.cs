using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SimpleMessenger.Controllers;
using SimpleMessenger.DAL.Repository.Interfaces;
using SimpleMessenger.DAL.Response;
using SimpleMessenger.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SimpleMessenger.xUnit
{
    public class ChatTests
    {
        private readonly ChatController controller;
        private readonly Mock<IAccountRepository> _repoAccountMock = new Mock<IAccountRepository>();
        private readonly Mock<IChatRepository> _repoChatMock = new Mock<IChatRepository>();
        private readonly Mock<ILogger<ChatController>> _loggerMock = new Mock<ILogger<ChatController>>();

        public ChatTests()
        {
            controller = new ChatController(_repoAccountMock.Object, _repoChatMock.Object, _loggerMock.Object);
        }

        [Fact]
        public void Chat_GetById_IfExists()
        {
            var chat = new Chat()
            {
                Id = 1,
                FromUserById = "fromUserId",
                ToUserById = "toUserId",
                FromUserByName = "fromUserName",
                ToUserByName = "toUserName",
            };

            var response = new BaseResponse<Chat>
            {
                IsSucceeded = true,
                Data = chat
            };

            _repoChatMock.Setup(x => x.GetChatAsync(chat.Id)).ReturnsAsync(response);

            var retrievedChat = (ViewResult)controller.ById(chat.Id).Result;
            var entity = (Chat)retrievedChat.Model;

            Assert.NotNull(entity);
        }

        [Fact]
        public void Chat_GetByIdWithMessages_IfExists()
        {
            var chat = new Chat()
            {
                Id = 1,
                FromUserById = "fromUserId",
                ToUserById = "toUserId",
                FromUserByName = "fromUserName",
                ToUserByName = "toUserName",
                Messages = new List<Message>
                {
                    new Message()
                    {
                        Id = 1,
                        MessageText = "msg",
                        Date = DateTime.Now,
                        Account_Nickname = "fromUserName",
                        Chat_Id = 1
                    },
                    new Message()
                    {
                        Id = 1,
                        MessageText = "msg1",
                        Date = DateTime.Now,
                        Account_Nickname = "fromUserName",
                        Chat_Id = 1
                    },
                    new Message()
                    {
                        Id = 1,
                        MessageText = "msg2",
                        Date = DateTime.Now,
                        Account_Nickname = "fromUserName",
                        Chat_Id = 1
                    },
                }
            };

            var response = new BaseResponse<Chat>
            {
                IsSucceeded = true,
                Data = chat
            };

            _repoChatMock.Setup(x => x.GetChatAsync(chat.Id)).ReturnsAsync(response);

            var retrievedChat = (ViewResult)controller.ById(chat.Id).Result;
            var entity = (Chat)retrievedChat.Model;

            Assert.NotNull(entity);
            Assert.Equal(3, entity.Messages.Count);
        }

        [Fact]
        public void Chat_GetById_IfNotExists()
        {
            var chat = new Chat()
            {
                Id = 1,
            };

            var response = new BaseResponse<Chat>
            {
                IsSucceeded = true,
                Data = null
            };

            _repoChatMock.Setup(x => x.GetChatAsync(chat.Id)).ReturnsAsync(response);

            var retrievedChat = (ViewResult)controller.ById(chat.Id).Result;
            var entity = (Chat)retrievedChat.Model;

            Assert.Null(entity);
        }

        
    }
}
