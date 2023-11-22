using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HotPotato.Services
{
    public static class PromptService
    {
        #region Main Menu

        public static void PresentMainMenu()
        {
            ImmutableDictionary<int, string> mainMenuOptions = ImmutableDictionary<int, string>
                .Empty
                .Add(1, "Run a potato")
                .Add(2, "Exit");

            PresentMenu("Main Menu", mainMenuOptions);
        }

        public static int GetMainMenuSelection()
        {
            return GetMenuSelection("Select an option")
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
                    Environment.Exit(0);
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
                        "Select an option (Press Enter to return to main menu)"
                    );

                    // Exit to main menu
                    if (potatoMenuSelection == null)
                    {
                        break;
                    }

                    PotatoRunService potatoRunService = new();

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
            ImmutableDictionary<int, string> potatoMenuOptions = ImmutableDictionary<int, string>
                .Empty
                .Add(1, "Sample");

            PresentMenu("Please choose a potato", potatoMenuOptions);
        }

        #endregion

        private static void PresentMenu(
            string menuTitle,
            ImmutableDictionary<int, string> menuOptions
        )
        {
            if (!menuOptions.Any())
            {
                throw new ArgumentException("menuOptions was empty");
            }

            Console.WriteLine($"{menuTitle}:\n");

            foreach (KeyValuePair<int, string> menuOption in menuOptions)
            {
                Console.WriteLine($"{menuOption.Key} - {menuOption.Value}");
            }
        }

        private static int? GetMenuSelection(string userPrompt)
        {
            Console.Write($"\n{userPrompt}: ");

            string? choice = Console.ReadLine();

            // Write a line to keep the output looking not cramped
            Console.WriteLine();

            if (string.IsNullOrWhiteSpace(choice))
            {
                return null;
            }

            try
            {
                return int.Parse(choice, NumberFormatInfo.InvariantInfo);
            }
            catch (Exception)
            {
                throw new ArgumentException("choice could not be parsed as int");
            }
        }
    }
}
