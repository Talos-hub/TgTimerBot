using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TgTimerBot.Models;
using Microsoft.Extensions.Logging;

namespace TgTimerBot.Data
{
    public interface ITelegramStorege
    {
        /// <summary>
        /// LoadIntervalsAsync loads configuration which contains <see cref="IntervalsFood"/>
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        public Task<Interval> LoadIntervalAsync(string path, ILogger logger, CancellationToken ct);
        /// <summary>
        /// Saves user settings with food intervals configuration
        /// </summary>
        /// <param name="chatID">Unique identifier of the user's chat (long)</param>
        /// <param name="typeFood">Type of food configuration</param>
        /// <param name="foods">IntervalsFood configuration object</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Task representing async operation</returns>
        public Task SaveUserSettingsAsync(long chatID, IFood food, ILogger logger, CancellationToken ct);
        /// <summary>
        /// Check that config is exist
        /// </summary>
        /// <param name="chatID">User chat id</param>
        /// <param name="typeFood">Meat or Egg</param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public Task<bool> IsConfigExist(long? chatID, IFood typeFood, ILogger logger, CancellationToken ct);
    }
}
