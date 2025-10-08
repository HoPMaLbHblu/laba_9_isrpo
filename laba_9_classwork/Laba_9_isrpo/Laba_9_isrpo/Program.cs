using MyClass;
using Newtonsoft.Json;
using HtmlAgilityPack;
using System.ComponentModel.Design;
using System.Threading.Channels;
using static Laba_9_isrpo.Program;
namespace Laba_9_isrpo
{
    internal class Program
    {
        //public delegate void MessageHandler(string text);
        //static void ShowMessage(string message)
        //{
        //    Console.WriteLine($"Сообщение: {message}");
        //}

        public delegate void NumberHandler(int number);
        static void Double(int num) => Console.WriteLine($"Удвоенно: {num * 2}");
        static void Square(int num) => Console.WriteLine($"Квадрат: {num * num}");

        static async Task Main(string[] args)
        {
            //Person2 anton = new("Anton");
            //Fruit apple = new() { Name = "ЯБлоко", Quantity = 5 };
            //string json = JsonConvert.SerializeObject(apple);
            //Console.WriteLine("В JSON: " + json);
            //var deserialized = JsonConvert.DeserializeObject<Fruit>(json);
            //Console.WriteLine($"Объект: {deserialized?.Name} - {deserialized.Quantity} шт.");
            //Console.Write("Введите URL сайта: ");
            //string? url = Console.ReadLine();
            //if (!string.IsNullOrWhiteSpace(url))
            //{
            //    try {
            //        HttpClient client = new HttpClient();
            //        string html = await client.GetStringAsync(url);
            //        HtmlDocument doc = new HtmlDocument();
            //        doc.LoadHtml(html);
            //        var titleNode = doc.DocumentNode.SelectSingleNode("//title");
            //        if (titleNode != null)
            //        {
            //            Console.WriteLine($"Заголовок страницы: {titleNode.InnerText}");
            //        } else { Console.WriteLine("Заголовок страницы не найден"); }
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine("Ошибка: " + ex.Message);
            //    }

            //}
            //else
            //{
            //    Console.WriteLine("URL не может быть пустым.");
            //}

            //string name = null;
            //Console.WriteLine(name.Length);

            //string nonNullableName = "Ария";
            //string? nullableName = null;
            //Console.WriteLine(nullableName?.Length);
            //string? GetUserName(int id)
            //{
            //    return id == 1 ? "Alice" : null;
            //}
            //var user = GetUserName(2);
            //Console.WriteLine(user?.ToUpper());

            //List<string> names = new() { "Anna", null, "Bob" };
            //foreach(var name in names)
            //{
            //    Console.WriteLine(name?.Length ?? 0);
            //}
            //string? text = null;
            //Console.WriteLine(text?.Length);
            //string? name = null;
            //string result = name ?? "Default";
            //string? name = null;
            //Console.WriteLine(name!.Length);
            //int? val = null;
            //Console.WriteLine(val);
            //IsNull(val);
            //val = 22;
            //IsNull(val);
            //void IsNull(int? obj)
            //{
            //    if (obj == null) Console.WriteLine("null");
            //    else Console.WriteLine(obj);
            //}
            //int val = null;
            //int? number1 = 5;
            //Nullable<int> number2 = 5;
            //PrintNullable(5);
            //PrintNullable(null);

            //void PrintNullable(int? number)
            //{
            //    if(number.HasValue)
            //    {
            //        Console.WriteLine(number.Value);
            //        Console.WriteLine(number);
            //    }
            //    else
            //    {
            //        Console.WriteLine("параметр равен null");
            //    }
            //}
            //int? number = null;
            //Console.WriteLine(number.Value);
            //Console.WriteLine(number);
            //Console.WriteLine(number.GetValueOrDefault());
            //Console.WriteLine(number.GetValueOrDefault(10));

            //MessageHandler handler = ShowMessage;
            //handler("Привет мир!");
            //NumberHandler handler = Double;
            //handler += Square;
            //handler(5);
            //Player player = new Player();
            //player.OnDeath += () => Console.WriteLine("Враги празднуют победу!");
            //player.OnDeath += ShowGameOver;
            //player.TakeDamage(100);

            var tempSensor = new TemperatureSensor();
            var motionSensor = new MotionSensor();
            var smartLight = new SmartLight();
            
            tempSensor.OnOverHeat += Notifier.SendTemperatureAlert;
            motionSensor.OnMotionDetected += Notifier.LogMotionEvent;
            motionSensor.OnMotionDetected += smartLight.TurnOn;

            Console.WriteLine("=== Симуляция умного дома ===");
            tempSensor.CheckTemperature(15);
            tempSensor.CheckTemperature(35);
            motionSensor.DetectMotion(false);
            motionSensor.DetectMotion(true);
            smartLight.TurnOn("Обнаружено движение");
            Thread.Sleep(3000);
            smartLight.TurnOff();
           

        }
        static void ShowGameOver() => Console.WriteLine("GAME OVER");

        
    }
    public delegate void TemperatureEventHandler(string message);
    public delegate void MotionEventHandler(string message);
    public class TemperatureSensor
    {
        public event TemperatureEventHandler OnOverHeat;

        public void CheckTemperature(int currentTemp)
        {
            if (currentTemp > 30)
            {
                OnOverHeat?.Invoke($"!! Температура критическая: {currentTemp}*C!");
            }
        }

    }
    public class MotionSensor
    {
        public event MotionEventHandler OnMotionDetected;

        public void DetectMotion(bool isMotion)
        {
            if (isMotion)
            {
                OnMotionDetected?.Invoke("!! Обнаружено движение в коридоре!");

            }
        }
    }

    public class Notifier
    {
        public static void SendTemperatureAlert(string message)
        {
            Console.WriteLine($"[Уведомление] {message}");
        }
        public static void LogMotionEvent(string message)
        {
            Console.WriteLine($"[Лог] {message} (время: {DateTime.Now}");
        }
       
    }
    public class SmartLight
    {
        private bool isOn = false;
        public void TurnOn(string message)
        {
            if(!isOn)
            {
                isOn = true;
                Console.WriteLine("[Лампочка]! Включена (триггер: движение)");
            }
        }
        public void TurnOff()
        {
            if (isOn)
            {
                isOn = false;
                Console.WriteLine("[Лампочка]! Выключена (прошло время без движения)");
            }
        }
    }

    internal class Player
    {
        public event Action OnDeath;
        private int health = 100;
        private void Die()
        {
            Console.WriteLine("Игрок погиб");
            OnDeath?.Invoke();
        }
        public void TakeDamage(int damage)
        {
            health -= damage;
            if (health <= 0) { Die(); }
        }
    }

    public class Fruit
    {
        public string? Name { get; set; }
        public int Quantity { get; set; }
    }

}
