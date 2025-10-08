namespace MyClass
{
    public class Person2
    {
        string name;
        public Person2(string name) { this.name = name; }
        public void Print() => Console.WriteLine($"Имя: {name}");

    }
}
