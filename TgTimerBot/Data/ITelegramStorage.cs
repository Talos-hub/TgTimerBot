using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TgTimerBot.Models;
using Microsoft.Extensions.Logging;

namespace TgTimerBot.Data
{
    public interface ITelegramStorage
    {
        /// <summary>
        /// LoadIntervalsAsync loads configuration which contains <see cref="IntervalsFood"/>
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        public Task<IFood> LoadIntervalAsync(long? chatID, string typeFood, CancellationToken ct = default);
        /// <summary>
        /// Saves user settings with food intervals configuration
        /// </summary>
        /// <param name="chatID">Unique identifier of the user's chat (long)</param>
        /// <param name="typeFood">Type of food configuration</param>
        /// <param name="foods">IntervalsFood configuration object</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Task representing async operation</returns>
        public Task SaveUserSettingsAsync(long? chatID, IFood food, CancellationToken ct = default);
        /// <summary>
        /// Check that config is exist
        /// </summary>
        /// <param name="chatID">User chat id</param>
        /// <param name="typeFood">Meat or Egg</param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public bool IsConfigExist(long? chatID, string typeFood);

        
    }
}
