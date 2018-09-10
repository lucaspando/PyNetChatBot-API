using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramInterface;

namespace ChatbotShell
{
    class ChatInit
    {
        static void Main(string[] args)
        {
            initChat();
        }

        private static void initChat() {
            TelegramBot.initBot();
        }
    }
}
