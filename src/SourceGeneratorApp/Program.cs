using Windows.Win32;

namespace SourceGeneratorApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        HelloFrom("Generated Code");

        //PInvoke.SetLayeredWindowAttributes
        //PInvoke.Get

        Console.WriteLine("Hello world!");
    }

    static partial void HelloFrom(string name);
}