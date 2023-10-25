using HotPotato.Models;
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

                var mainMenuSelection = PromptService.GetMainMenuSelection();

                await PromptService.ExecuteMainMenuSelection(mainMenuSelection);
            }
            catch (Exception ex)
            {
                // Log exception if unexpected
                if (ex.GetType() != typeof(PromptException))
                    Log.Error(ex, "An unexpected exception was thrown");
            }
        }
    }
}
