using HtmlAgilityPack;
namespace Nuget
{
    internal class NumberTwo
    {
        //задание 2
        static async Task Main(string[] args)
        {
            Console.WriteLine("Введите URL сайта: "); //https://example.com
            string? url = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(url))
            {
                try
                {
                    HttpClient client = new HttpClient();
                    string html = await client.GetStringAsync(url);
                    HtmlDocument doc = new HtmlDocument();
                    doc.LoadHtml(html);
                    var titleNode = doc.DocumentNode.SelectSingleNode("//title");
                    if (titleNode != null)
                    {
                        Console.WriteLine($"Заголовок страницы: {titleNode.InnerText}");
                    }
                    else { Console.WriteLine("Заголовок страницы не найден"); }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("URL не может быть пустым.");
            }
        }
    }
}
