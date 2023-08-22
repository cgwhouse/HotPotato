using HotPotato.Services;
using Serilog;
using System;
using System.Threading.Tasks;

namespace HotPotato;

public class Program
{
    public static async Task Main()
    {
        Console.WriteLine("\nWelcome to Hot Potato!\n");

        while (true)
        {
            try
            {
                PromptService.PresentMainMenu();

                int? mainMenuSelection = null;

                try
                {
                    mainMenuSelection = PromptService.GetMainMenuSelection();
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid selection.\n");
                    throw;
                }

                await PromptService.ExecuteMainMenuSelection(
                    mainMenuSelection ?? throw new Exception("mainMenuSelection was null")
                );
            }
            catch (Exception ex)
            {
                // Log exception if unexpected
                if (ex.GetType() != typeof(ArgumentException))
                    Log.Error(ex, "An unexpected exception was thrown");
            }
        }
    }
}
