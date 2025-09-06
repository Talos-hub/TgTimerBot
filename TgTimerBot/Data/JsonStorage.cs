using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using TgTimerBot.Models;
using TgTimerBot.Helpers;
using Microsoft.Extensions.Logging;

namespace TgTimerBot.Data
{
    public class JsonStorage : ITelegramStorage
    {

        private readonly ILogger _logger;

        public JsonStorage(ILogger logger)
        {
            _logger = logger;
        }

        public async Task CreateDefaultConfig(string typeFood, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested(); 

            try
            {
                Interval DefaultInteral = new();
                // check type and set default value for diffirent type food
                switch (typeFood)
                {
                    case "Meat":
                        DefaultInteral.Name = typeFood;
                        DefaultInteral.Hour = 0;
                        DefaultInteral.Minute = 20;
                        DefaultInteral.Second = 0;
                        break;
                    case "Egg":
                        DefaultInteral.Name = typeFood;
                        DefaultInteral.Hour = 0;
                        DefaultInteral.Minute = 8;
                        DefaultInteral.Second = 0;
                        break;
                }
                await SaveUserSettingsAsync(null, DefaultInteral, ct);
            }
            catch(Exception ex)
            {
                _logger.LogError("Error creating default config {Error}", ex);
            }
        }


        /// <summary>
        /// It checks that a config exists
        /// </summary>
        /// <param name="chatID">That is chat id from telegram</param>
        /// <param name="typeFood">This is a type of food that contains a time interval.</param>
        /// <param name="logger">Logger</param>
        /// <param name="ct">That is Cancellation Token</param>
        /// <returns></returns>
        public bool IsConfigExist(long? chatID, string typeFood)
        {

            if (typeFood == null)
            {
                _logger.LogError("Error checking config, typeFood is null");
                throw new ArgumentNullException(nameof(typeFood));
            }


            // create path to file
            try
            {
                string path = PathCreator.CreatePathToConfig(chatID, typeFood, _logger);

                // checks that config exists
                var ok = System.IO.File.Exists(path);

                return ok;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error checking config {Error}", ex);
                throw;
            }
            
        }
        /// <summary>
        /// It loads a config that contains interval settings for timer.
        /// </summary>
        /// <param name="chatID">That is chat id of telegram user</param>
        /// <param name="typeFood">That is type food, it might be Meat or Egg</param>
        /// <param name="ct"></param>
        /// <returns>Deserialized Interval object</returns>
        /// <exception cref="ArgumentNullException">Throw when typeFood or deserialization result is null </exception>
        /// <exception cref="ArgumentException">Thrown when typeFood is invalid or deserialization fails</exception>
        public async Task<IFood> LoadIntervalAsync(long? chatID, string typeFood, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();
            if (typeFood is null)
            {
                _logger.LogError("Error loading config, typefood is null {Type}", nameof(typeFood));
                throw new ArgumentNullException("Error, typeFood cannot be null", nameof(typeFood));
            }

            try
            {
                // path to config
                string path = PathCreator.CreatePathToConfig(chatID, typeFood, _logger);
                // it's read everything to memory because the file is small
                
                if (!File.Exists(path))
                {
                    _logger.LogError($"Could not load {path}, files is not found");
                    throw new FileNotFoundException($"Cant found the file {path}");
                }

                //create file stream
                await using var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true);
                // Deserualization
                IFood? Result = await JsonSerializer.DeserializeAsync<IFood>(fileStream);

                if (Result is null)
                    throw new ArgumentNullException("Deserialization returned null");
                if (string.IsNullOrEmpty(Result.Name))
                {
                    throw new ArgumentException("Result.Name cannot be empty or null");
                }

                return Result;
            }
            catch(FileNotFoundException ex)
            {
                _logger.LogWarning("Default config is not exists {Error}", ex);
                _logger.LogInformation("Creating new default Config for type {TypeFood}", typeFood);
                
                
            }
            catch (Exception ex)
            {
                _logger.LogError("Error loading a config {Error}", ex);
                throw;
            }
            
          
        }

        /// <summary>
        /// Save a food settings for timer
        /// </summary>
        /// <param name="chatID">That is chat id of telegram</param>
        /// <param name="food">Type food that contains interval settings </param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public async Task SaveUserSettingsAsync(long? chatID, IFood food, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            try
            {
                // setup json options
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };
                
                string path = PathCreator.CreatePathToConfig(chatID, food.Name, _logger); 
                string jsonData = JsonSerializer.Serialize<IFood>(food, options);

                // if a folder is not exists it creat new folder
                PathCreator.CreatFolder(path);
                var tempPath = path + ".tmp";  // creat a temp file

                await File.WriteAllTextAsync(tempPath, jsonData, ct); // write to temp file

                File.Move(tempPath, path, true); // write to original file
            }
            catch (Exception ex)
            {
                _logger.LogError("Error save config {Error}", ex);
                throw;
            }

        }
    }
}
