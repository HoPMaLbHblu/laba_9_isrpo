using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_9
{
    internal class Thermometer //задание 4
    {
        public event Action? TemperutureTooHigh;
        public void Measure(int value)
        {
            if (value >= 100)
            {
                TemperutureTooHigh?.Invoke();
                Console.WriteLine("Температура слишком высока");
            }
            else if (value > -30)
            {
                Console.WriteLine("Температура в норме");
            }

        }
    }
}
