using System;
using System.Threading.Tasks;
using HotPotato.Services;

namespace HotPotato
{
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

                    int mainMenuSelection = PromptService.GetMainMenuSelection();

                    await PromptService.ExecuteMainMenuSelection(mainMenuSelection);
                }
                catch (Exception ex)
                {
                    // Log exception if unexpected
                    if (ex.GetType() != typeof(ArgumentException))
                    {
                        Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                    }
                }
            }
        }
    }
}
