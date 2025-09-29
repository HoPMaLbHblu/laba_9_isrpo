using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_9 
{
    internal class SmartLight //задание 6
    {
        public bool isOn { get; set; }
        public int brightness { get; set; } = 100;
        public event Action? OnStateChanged;
        public void Toggle()
        {
            OnStateChanged?.Invoke();
            if (isOn) { isOn = false; Console.WriteLine("Свет выключен"); }
            else { isOn = true; Console.WriteLine("Свет включен"); }


        }

    }
}
