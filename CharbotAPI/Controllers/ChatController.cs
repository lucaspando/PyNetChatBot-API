using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TelegramInterface;

namespace CharbotAPI.Controllers
{
    public class ChatController : ApiController
    {
        public string getSaludo()
        {
            return "Hola";
        }
    }
}
