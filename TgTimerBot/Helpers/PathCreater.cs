using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TgTimerBot.Models;

namespace TgTimerBot.Helpers
{
    public static class PathCreator
    {   
        // there is all configs
        private const string ConfigFolder = "Configs";
        // json extention
        private const string JsonExtention = ".json";
        // default path for egg
        private static readonly string DefaultEggPath = Path.Combine(ConfigFolder, "DefaultEgg.json");
        // default path for meat
        private static readonly string DefaultMeatPath = Path.Combine(ConfigFolder, "DefaultMeat.json");
        /// <summary>
        ///  Creates a path to config file for the specified chat ID and food type
        ///  If chatId is null it create default path
        /// </summary>
        /// <param name="chatId">the chat identifier</param>
        /// <param name="typeFood">the type of food</param>
        /// <param name="logger">Logger instance</param>
        /// <returns>path to the config </returns>
        public static string CreatePathToConfig(long? chatId, IFood typeFood, ILogger logger)
        {
           

            // if typeFood name is null or empty we throw exception
            if (string.IsNullOrEmpty(typeFood.Name)) 
            {
                const string errorMessage = "Type food cannot be null or empty";
                logger.LogError("Error creating path: {ErrorMessage}", errorMessage);
                throw new ArgumentException(errorMessage, nameof(typeFood.Name));
            }
            
            // if chat id is null it create defalut path
            if (chatId is null)
            {
                logger.LogWarning("Using default path for null chat id");
                switch (typeFood.Name)
                {
                    case "Meat":
                        return DefaultMeatPath;
                    case "Egg":
                        return DefaultEggPath;
                    default:
                        const string ErrorMessage = "Unknown food type";
                        logger.LogError("Error creating default path {Error}", ErrorMessage);
                        throw new ArgumentException($"Error creating default path: {ErrorMessage}");
                }
            }

            // for example: 23434547584Meat.json
            string fileName = $"{chatId}{typeFood.Name}{JsonExtention}";
            string fullPath = Path.Combine(ConfigFolder, fileName);

            
            // it validate a path
            if (!IsValidPath(fullPath))
            {
                const string errorMessage = "Generated path is invalid";
                logger.LogError("Error creating path {ErrorMessage}", errorMessage);
                throw new InvalidOperationException($"Error creating path: {errorMessage}");
            }
            logger.LogDebug("Generated a path {Path}", fullPath);

            return fullPath;
        }
        /// <summary>
        /// It's simple validation that chack that a path contatins .json 
        /// </summary>
        /// <param name="path"></param>
        /// <returns>bool</returns>
        public static bool IsValidPath(string path)
        {
            if (string.IsNullOrEmpty(path)) return false;

            return Path.GetExtension(path).Equals(".json", StringComparison.OrdinalIgnoreCase) && path.Length >= 6; // as json min
        }
    }
}
