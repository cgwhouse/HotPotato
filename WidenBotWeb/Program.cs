using HotPotato.Scripts;
using System;
using System.Threading.Tasks;

namespace HotPotato;

public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Welcome to Hot Potato!");

        Console.WriteLine("Executing sample script...");

        var sample = new Sample();
        await sample.Run();
    }
}
