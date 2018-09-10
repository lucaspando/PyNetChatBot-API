using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramInterface.ChatState;

namespace TelegramInterface
{
    public class TelegramBot
    {
        public static TelegramBotClient botClient = new Telegram.Bot.TelegramBotClient("622032967:AAE4fpP4Ylde6o3_5-d4Xy7RucCvi553OFE");
        public static List<StateValue> chatsStatus = new List<StateValue>() { };

        public static void initBot()
        {
            try
            {
                string msg = "";
                botClient.OnMessage += Bot_OnMessage;
                botClient.StartReceiving();
                while (msg != "exit")
                {
                    Console.ReadLine();
                }
                botClient.StopReceiving();
            }
            catch (Exception e) {
                throw e;
            }
        }

        private static async void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
            {
                if (e.Message.Text != "/start")
                {
                    Console.WriteLine(e.Message.Text);
                    string resp = await talkToChatPy(e.Message.Chat.Id, e.Message.From.FirstName, e.Message.Text);
                    if (resp != null)
                    {
                        await botClient.SendTextMessageAsync(e.Message.Chat.Id, resp);
                    }
                }
            }
        }

        private static async Task<string> talkToChatPy(long chatId, string user, string msg)
        {
            var url = "http://127.0.0.1:5000/chat/talk";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);


                string parameters = JsonConvert.SerializeObject(
                    new{
                            msg = msg,
                            user = user,
                            chatId = chatId
                });


                var stringContent = new StringContent(parameters, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(url, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    string strResult = await response.Content.ReadAsStringAsync();

                    return strResult;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
