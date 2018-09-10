using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramInterface.ChatState
{
    public class StateValue
    {
        public long chatId { get; set; }
        public State status { get; set; }
        public string lastMsg { get; set; }
        public DateTime lastMsgTime { get; set; }
    }
}
