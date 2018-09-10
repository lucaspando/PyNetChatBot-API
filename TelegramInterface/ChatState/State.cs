using Telegram.Bot.Types;

namespace TelegramInterface.ChatState
{
    public interface State
    {
        void receiveMsg(Message message, StateValue chatStatus);
    }
}
