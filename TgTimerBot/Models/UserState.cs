using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TgTimerBot.Models
{
    /// <summary>
    /// It gives a user state in process using a bot.
    /// Using for check a current context chat
    /// </summary>
    public class UserState : IUserState
    {
        /// <summary>
        /// Geta  value that bot wait a user input
        /// </summary>
        public bool WaitingForUserInput { get; set; }
        /// <summary>
        /// It might be meat or egg or something esle
        /// </summary>
        public string TypeFood {  get; set; }
        /// <summary>
        /// Get and set type operation from user
        /// </summary>
        public string TypeOperation { get; set; } 
        /// <summary>
        /// Init a new object <see cref="UserState"/>
        /// </summary>
        /// <param name="typeFood"></param>
        /// <param name="typeOperation"></param>
        /// <param name="waitingForUserInput"></param>
        public UserState(string typeFood, string typeOperation, bool waitingForUserInput )
        {
            WaitingForUserInput = waitingForUserInput;
            TypeFood = typeFood;
            TypeOperation = typeOperation;
            
        }
    }
}
