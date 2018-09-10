using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace TelegramInterface.ChatState
{
    public class TalkState : State
    {
        public void receiveMsg(Message message, StateValue chatStatus)
        {
            switch (message.Text.ToLower())
            {
                case "hola":
                    //TelegramBot.sendMessage(message, "Bot: Hola " + message.Chat.FirstName + ".", new TalkState());
                    break;

                case "/start":
                    //TelegramBot.sendMessage(message, "Bot: Bienvenido, mi nombre es Jacint@, en que puedo ayudarte?", new TalkState());
                    break;

                default:
                    //TelegramBot.sendMessage(message, "Bot: No entiendo el mensaje \"" + message.Text + "\".", new TalkState());
                    break;
            }
        }
    }
}
