using System;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace HotPotato.Services;

public static class PromptService
{
    private static ImmutableDictionary<int, string> MainMenuOptions = ImmutableDictionary<
        int,
        string
    >.Empty
        .Add(1, "Run a potato")
        .Add(2, "Exit");

    private static ImmutableDictionary<int, string> PotatoRunMenuOptions = ImmutableDictionary<
        int,
        string
    >.Empty.Add(1, "Sample");

    public static void PresentMainMenu()
    {
        PresentMenu("Main Menu", MainMenuOptions);
    }

    public static int GetMainMenuSelection()
    {
        Console.Write("\nSelect an option: ");

        var choice = Console.ReadLine();

        // Write a line to keep the output looking not cramped
        Console.WriteLine();

        if (string.IsNullOrEmpty(choice))
            throw new ArgumentException("Choice was null or empty");

        // Parse choice as int
        int? choiceInt = null;
        try
        {
            choiceInt = int.Parse(choice);
        }
        catch (Exception)
        {
            throw new ArgumentException("Choice could not be parsed as int");
        }

        if (choiceInt == null)
            throw new ArgumentException("choiceAsKey was null");

        if (!MainMenuOptions.Keys.Contains(choiceInt.Value))
            throw new ArgumentException("Choice was not found in menu options");

        return choiceInt.Value;
    }

    public static async Task ExecuteMainMenuSelection(int mainMenuSelection)
    {
        switch (mainMenuSelection)
        {
            case 1:
                await RunPotatoAfterShowingMenu();
                break;
            case 2:
                Console.WriteLine("Goodbye!\n");
                System.Environment.Exit(0);
                break;
            default:
                throw new ArgumentException("Unrecognized selection for main menu");
        }
    }

    #region Private

    private static async Task RunPotatoAfterShowingMenu()
    {
        while (true)
        {
            try
            {
                PresentPotatoRunMenu();

                int? potatoMenuSelection = null;

                potatoMenuSelection = 0; // TODO GetMainMenuSelection, but for potatoes

                // Exit to main menu
                if (potatoMenuSelection == null)
                    break;

                var potatoRunService = new PotatoRunService();
                await potatoRunService.RunPotato(potatoMenuSelection.Value);

                break;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid selection.\n");
            }
        }
    }

    private static void PresentMenu(string menuTitle, ImmutableDictionary<int, string> menuOptions)
    {
        if (!menuOptions.Any())
            throw new Exception("menuOptions was empty");

        Console.WriteLine($"{menuTitle}:\n");

        foreach (var menuOption in menuOptions)
            Console.WriteLine($"{menuOption.Key} - {menuOption.Value}");
    }

    private static void PresentPotatoRunMenu()
    {
        PresentMenu("Please choose a potato", PotatoRunMenuOptions);
    }

    #endregion
}
