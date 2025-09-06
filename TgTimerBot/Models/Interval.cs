using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TgTimerBot.Models
{
    /// <summary>
    /// Interval implemented Ifood
    /// It contatins Hour, Minute, Second, TypeFood
    /// </summary>
    public class Interval:IFood
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; } 
        public string Name { get; set; }

        public Interval(int hour,int minute, int second, string typeFood) 
        {
            Hour = hour;
            Minute = minute;
            Second = second; 
            Name = typeFood;
        }

        public Interval() 
        {
            Name = string.Empty;
        }
    }
}
