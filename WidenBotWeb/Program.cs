using WidenBotWeb.Scripts;
using System;
using System.Threading.Tasks;

namespace WidenBotWeb;

public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Executing sample script...");

        var sample = new Sample();
        await sample.Run();
    }
}
