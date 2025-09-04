using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TgTimerBot.Services
{
    public interface ITelegramService
    {
        public Task StartAsync(CancellationToken ct);
        public Task HandleUpdateAsync(Update update, CancellationToken ct);
    }
}
