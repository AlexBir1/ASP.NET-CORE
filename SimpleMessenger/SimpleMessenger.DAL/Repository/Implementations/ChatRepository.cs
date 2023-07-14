using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SimpleMessenger.DAL.Repository.Interfaces;
using SimpleMessenger.DAL.Response;
using SimpleMessenger.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMessenger.DAL.Repository.Implementations
{
    public class ChatRepository : IChatRepository
    {
        private readonly AppDBContext _db;
        private readonly UserManager<Account> _userManager;

        public ChatRepository(AppDBContext db, UserManager<Account> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task<IBaseResponse<Chat>> CreateChatAsync(string _fromUserId, string _fromUserName, string _toUserId)
        {
            try
            {
                var toAccount = await _userManager.FindByIdAsync(_toUserId);
                Chat chat = new()
                {
                    FromUserById = _fromUserId,
                    FromUserByName = _fromUserName,
                    ToUserById = _toUserId,
                    ToUserByName = toAccount.Nickname
                };

                Chat existingChat = await _db.Chat.Where(x => x.FromUserById == _fromUserId && x.ToUserById == _toUserId).FirstOrDefaultAsync();
                Chat existingChatInversedIds = await _db.Chat.Where(x => x.FromUserById == _toUserId && x.ToUserById == _fromUserId).FirstOrDefaultAsync();

                if (existingChat is not null)
                {
                    return new BaseResponse<Chat>
                    {
                        IsSucceeded = true,
                        Data = existingChat
                    };
                }
                else if(existingChatInversedIds is not null)
                {
                    return new BaseResponse<Chat>
                    {
                        IsSucceeded = true,
                        Data = existingChatInversedIds
                    };
                }
                else
                {
                    var Result = _db.Chat.Add(chat);
                    await _db.SaveChangesAsync();

                    return new BaseResponse<Chat>
                    {
                        Data = Result.Entity,
                        IsSucceeded = true
                    };
                }
            }
            catch(Exception ex)
            {
                return new BaseResponse<Chat>
                {
                    IsSucceeded = false,
                    Errors = new List<string> { new string(ex.Message) }
                };
            }
        }

        public async Task<IBaseResponse<Chat>> DeleteChatAsync(int _chatId)
        {
            try
            {
                var Result = await _db.Chat.Where(x => x.Id == _chatId).FirstAsync();

                _db.Chat.Remove(Result);
                await _db.SaveChangesAsync();

                return new BaseResponse<Chat>
                {
                    Data = Result,
                    IsSucceeded = true
                };
            }
            catch(Exception ex)
            {
                return new BaseResponse<Chat>
                {
                    IsSucceeded = false,
                    Errors = new List<string> { new string(ex.Message) }
                };
            }
        }

        public async Task<IBaseResponse<Chat>> GetChatAsync(int _chatId)
        {
            try
            {
                Chat Result = await _db.Chat.Include(x=>x.Messages).Where(x => x.Id == _chatId).FirstAsync();
                return new BaseResponse<Chat>
                {
                    Data = Result,
                    IsSucceeded = true
                };
            }
            catch(Exception ex)
            {
                return new BaseResponse<Chat>
                {
                    IsSucceeded = false,
                    Errors = new List<string> { new string(ex.Message) }
                };
            }
        }

        public async Task<IBaseResponse<Chat>> GetChatAsync(string _fromUserId, string _toUserId)
        {
            try
            {
                Chat Result = await _db.Chat.Include(x => x.Messages).Where(x => x.FromUserById == _fromUserId && x.ToUserById == _toUserId).FirstOrDefaultAsync();
                Chat ResultInversed = await _db.Chat.Include(x => x.Messages).Where(x => x.FromUserById == _fromUserId && x.ToUserById == _toUserId).FirstOrDefaultAsync();

                if(Result is not null)
                    return new BaseResponse<Chat>
                    {
                        Data = Result,
                        IsSucceeded = true
                    };
                else if (ResultInversed is not null)
                    return new BaseResponse<Chat>
                    {
                        Data = Result,
                        IsSucceeded = true
                    };
                else
                    return new BaseResponse<Chat>
                    {
                        Errors = new List<string> { "Chat doesn`t exist." },
                        IsSucceeded = false
                    };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Chat>
                {
                    IsSucceeded = false,
                    Errors = new List<string> { new string(ex.Message) }
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Chat>>> GetChatsAsync()
        {
            try
            {
                IEnumerable<Chat> ResultList = await _db.Chat.ToListAsync();

                if(ResultList is null)
                    return new BaseResponse<IEnumerable<Chat>>
                    {
                        IsSucceeded = false,
                        Errors = new List<string> { "NULL" }
                    };

                if(ResultList.Count() == 0)
                    return new BaseResponse<IEnumerable<Chat>>
                    {
                        IsSucceeded = false,
                        Errors = new List<string> { "Chat`s list is empty." }
                    };

                return new BaseResponse<IEnumerable<Chat>>
                {
                    IsSucceeded = true,
                    Data = ResultList
                };
            }
            catch(Exception ex)
            {
                return new BaseResponse<IEnumerable<Chat>>
                {
                    IsSucceeded = false,
                    Errors = new List<string> { new string(ex.Message) }
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Chat>>> GetChatsAsync(string _userId)
        {
            try
            {
                IEnumerable<Chat> ResultList = await _db.Chat.Where(x=>x.FromUserById == _userId || x.ToUserById == _userId).ToListAsync();

                if (ResultList is null)
                    return new BaseResponse<IEnumerable<Chat>>
                    {
                        IsSucceeded = false,
                        Errors = new List<string> { "NULL" }
                    };

                if (ResultList.Count() == 0)
                    return new BaseResponse<IEnumerable<Chat>>
                    {
                        IsSucceeded = true,
                        Data = new List<Chat>(),
                        Errors = new List<string> { "Chat`s list is empty." }
                    };

                return new BaseResponse<IEnumerable<Chat>>
                {
                    IsSucceeded = true,
                    Data = ResultList
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Chat>>
                {
                    IsSucceeded = false,
                    Errors = new List<string> { new string(ex.Message) }
                };
            }
        }

        public async Task<IBaseResponse<Message>> AddMessageAsync(int _chatId, string _messageText, string _fromUserName)
        {
            try
            {
                Message message = new()
                {
                    Chat_Id = _chatId,
                    Account_Nickname = _fromUserName,
                    MessageText = _messageText,
                    Date = DateTime.Now
                };

                var insertedMessage = _db.Message.Add(message);
                await _db.SaveChangesAsync();

                return new BaseResponse<Message>
                {
                    IsSucceeded = true,
                    Data = message
                };
            }
            catch(Exception ex)
            {
                return new BaseResponse<Message>
                {
                    IsSucceeded = false,
                    Errors = new List<string> { new string(ex.Message) }
                };
            }
        }
    }
}
