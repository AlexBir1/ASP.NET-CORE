using SimpleMessenger.DAL.Response;
using SimpleMessenger.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMessenger.DAL.Repository.Interfaces
{
    public interface IChatRepository
    {
        Task<IBaseResponse<Chat>> CreateChatAsync(string _fromUserId, string _fromUserName, string _toUserId);
        public Task<IBaseResponse<Message>> AddMessageAsync(int chatId, string messageText, string _fromUserName);
        Task<IBaseResponse<Chat>> DeleteChatAsync(int _chatId);
        Task<IBaseResponse<Chat>> GetChatAsync(int _chatId);
        Task<IBaseResponse<Chat>> GetChatAsync(string _fromUserId, string _toUserId);
        Task<IBaseResponse<IEnumerable<Chat>>> GetChatsAsync();
        Task<IBaseResponse<IEnumerable<Chat>>> GetChatsAsync(string _userId);
    }
}
