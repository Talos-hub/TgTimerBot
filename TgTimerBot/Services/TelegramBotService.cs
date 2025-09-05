using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using TgTimerBot.Models;
using Telegram.Bot;

namespace TgTimerBot.Services
{
    public class TelegramBotService : ITelegramService
    {
        readonly private IUserState userState;
        readonly private ITelegramBotClient botClient;
        public Task HandleUpdateAsync(Update update, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task StartAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
