using MathLibrary;
using Newtonsoft.Json;

namespace laba_9
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            //задание 1
            //MathTools Maths = new MathTools();
            //Console.WriteLine($"{Maths.Add(2,2)}");
            //Console.WriteLine($"{Maths.Multiply(4, 2)}");

            //задание 2 в проекте NumberTwo.cs

            //задание 3
            //Logger print = LogToConsole;
            //print("Привет мир!");

            //задание 4
            //Thermometer therm = new Thermometer();
            //therm.Measure(155);

            //задание 5
            //PrintLenght(null);
            //PrintLenght("12345");

            //Задание 6
            //SmartLight light = new SmartLight();
            //light.OnStateChanged += Toggle_click;
            //light.Toggle();
            //light.Toggle();
            //string serialization = JsonConvert.SerializeObject(light);
            //Console.WriteLine(serialization);
            //string loadedJson = File.ReadAllText("light.json");
            //SmartLight? deserialization = JsonConvert.DeserializeObject<SmartLight>(loadedJson);
            //Console.WriteLine($"IsOn = {deserialization?.isOn}, Brightness = {deserialization?.brightness}");
        }






        public delegate void Logger(string message);//для задания 3
        static void LogToConsole(string message) //для задания 3
        {
            Console.WriteLine($"{message}");
        }
        static void PrintLenght(string? input) // для задания 5
        {
            if (input != null)
            {
                Console.WriteLine(input.Length);
            }
            else
            {
                Console.WriteLine("Строка отсутствует");
            }

        }
        private static void Toggle_click() { Console.WriteLine("Нажата кнопка включения/выключения света"); } //для задания 6
    }
    
    
}
