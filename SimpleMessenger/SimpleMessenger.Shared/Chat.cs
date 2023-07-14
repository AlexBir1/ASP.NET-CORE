using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMessenger.Shared
{
    public class Chat
    {
        public int Id { get; set; }

        public string FromUserByName { get; set; }
        public string FromUserById { get; set; }

        public string ToUserByName { get; set; }
        public string ToUserById { get; set; }

        public ICollection<Message> Messages { get; set; }
    }
}
