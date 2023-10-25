using System;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace HotPotato.Services;

public static class PromptService
{
    #region Main Menu

    public static void PresentMainMenu()
    {
        var mainMenuOptions = ImmutableDictionary<int, string>.Empty
            .Add(1, "Run a potato")
            .Add(2, "Exit");

        PresentMenu("Main Menu", mainMenuOptions);
    }

    public static int GetMainMenuSelection()
    {
        return GetMenuSelection("Select an option", allowEmpty: false)
            ?? throw new ArgumentException("Main menu selection was null");
    }

    public static async Task ExecuteMainMenuSelection(int mainMenuSelection)
    {
        switch (mainMenuSelection)
        {
            case 1:
                await ExecutePotatoMenuSelection();
                break;
            case 2:
                System.Environment.Exit(0);
                break;
            default:
                throw new ArgumentException("Unrecognized selection for main menu");
        }
    }

    #endregion

    #region Potato Menu

    private static async Task ExecutePotatoMenuSelection()
    {
        while (true)
        {
            try
            {
                PresentPotatoMenu();

                int? potatoMenuSelection = null;

                potatoMenuSelection = GetMenuSelection(
                    "Select an option (Press Enter to return to main menu)",
                    allowEmpty: true
                );

                // Exit to main menu
                if (potatoMenuSelection == null)
                    break;

                var potatoRunService = new PotatoRunService();

                await potatoRunService.RunPotato(potatoMenuSelection.Value);

                break;
            }
            // We just want it to re-prompt the user, if they entered anything other than a
            // valid option for selection
            catch (ArgumentException) { }
        }
    }

    private static void PresentPotatoMenu()
    {
        var potatoMenuOptions = ImmutableDictionary<int, string>.Empty.Add(1, "Sample");

        PresentMenu("Please choose a potato", potatoMenuOptions);
    }

    #endregion

    private static void PresentMenu(string menuTitle, ImmutableDictionary<int, string> menuOptions)
    {
        if (!menuOptions.Any())
            throw new Exception("menuOptions was empty");

        Console.WriteLine($"{menuTitle}:\n");

        foreach (var menuOption in menuOptions)
            Console.WriteLine($"{menuOption.Key} - {menuOption.Value}");
    }

    private static int? GetMenuSelection(string userPrompt, bool allowEmpty)
    {
        Console.Write($"\n{userPrompt}: ");

        var choice = Console.ReadLine();

        // Write a line to keep the output looking not cramped
        Console.WriteLine();

        if (string.IsNullOrWhiteSpace(choice))
        {
            if (allowEmpty)
                return null;

            throw new ArgumentException("choice was null");
        }

        // Parse choice as int
        int? choiceInt = null;

        try
        {
            choiceInt = int.Parse(choice);
        }
        catch (Exception)
        {
            throw new ArgumentException("choice could not be parsed as int");
        }

        if (choiceInt == null)
            throw new ArgumentException("choiceInt was null");

        return choiceInt.Value;
    }
}
