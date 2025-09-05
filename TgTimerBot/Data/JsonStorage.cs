using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TgTimerBot.Models;
using TgTimerBot.Helpers;
using Microsoft.Extensions.Logging;

namespace TgTimerBot.Data
{
    public class JsonStorage : ITelegramStorage
    {
        public Task<bool> IsConfigExist(long? chatID, IFood typeFood, ILogger logger, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<Interval> LoadIntervalAsync(string path, ILogger logger, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task SaveUserSettingsAsync(long chatID, IFood food, ILogger logger, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
