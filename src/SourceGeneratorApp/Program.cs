namespace SourceGeneratorApp
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            HelloFrom("Generated Code");
            Console.WriteLine("Hello world!");
        }

        static partial void HelloFrom(string name);
    }
}