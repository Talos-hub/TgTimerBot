using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TgTimerBot.Models
{
    /// <summary>
    /// It contains a two type time for food
    /// </summary>
    public class IntervalsFood
    {
       
        public IFood? Meat {  get; set; }
        public IFood Egg { get; set; }

        public IntervalsFood(IFood meat, IFood egg)
        {
            Meat = meat;
            Egg = egg;
        }

    }
}
