using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TgTimerBot.Models
{
    public interface IUserState
    {
        public bool WaitingForUserInput { get; set; } // For handle user input
        public string TypeFood { get; set; } // Meat or Egg or something esle
        public string TypeOperation { get; set; } 
    }
}
