using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Fighting_Fantasy
{
    class Program
    {

        int playerBaseHealth; // The players base health
        int playerBaseArmour; // The players base armour
        int playerBaseMana; // The players base mana
        public static string _playerName;
        public static string _playerRace;

        static void Main(string[] args)
        {
            // Display the introduction for the game
            displayIntroduction();

            checkGameState();


            // End program here
            Console.ReadKey();            
        }

        /// <summary>
        /// Check the state of the game to see if it is being run for the first time
        /// or the user is returning to continue playing from where they left off.
        /// </summary>
        private static void checkGameState()
        {
            if (File.Exists("player.xml") != true)
            {
                XmlManagement.firstGameSetup(_playerName, _playerRace);
            }
            else
            {
                XmlManagement.readFromPlayerXml();
                printAIMessage("Welcome back " + _playerName + "!");
            }
        }

        /// <summary>
        /// Asks the player for a character name and returns the name as a string
        /// </summary>
        /// <returns></returns>
        public static string getPlayerName()
        {
            printAIMessage("Welcome traveller! What is your name?\n");
            Console.Write("My name is: ");
            string _playerName = Console.ReadLine();
            return _playerName;
        }

        /// <summary>
        /// Asks the player to select a race and returns the race as a string.
        /// </summary>
        /// <param name="_playerName">The players character name</param>
        /// <param name="goAgain">Did the user press a wrong key?</param>
        /// <returns></returns>
        public static string getPlayerRace(string _playerName, bool goAgain)
        {
            // If this is the first time the function has run through, complete first bit of code
            if (goAgain == false) 
            {
                printAIMessage("\nAhhh! Welcome " + _playerName + "!\n");
                printAIMessage("Tell me, what race are you?\n");
            }
            else 
            {
                printAIMessage("I'm sorry, I didn't quite catch that?");
            }

            Console.WriteLine("1. Human\n2. Elf\n3. Dwarf\n");
            Console.Write("Your race: ");
            ConsoleKeyInfo _playerRaceKey = Console.ReadKey(); // Get the key the user pressed
            Console.WriteLine();
            switch (_playerRaceKey.Key)
            {
                case ConsoleKey.D1: // If key "1"
                    return "Human";
                case ConsoleKey.D2: // If key "2"
                    return "Elf";
                case ConsoleKey.D3: // If key "3"
                    return "Dwarf";
                default:
                    getPlayerRace(_playerName, true); // Re-run the function with goAgain as "true"
                    break;
            }

            return null;
        }

        /// <summary>
        /// Prints a message to the console with a slight delay between each
        /// character to separate game and AI text
        /// </summary>
        /// <param name="messageToPrint"></param>
        public static void printAIMessage(string messageToPrint)
        {
            // Get the original color of the console
            ConsoleColor _originalColor = Console.ForegroundColor;
            // Set the new color to Cyan
            Console.ForegroundColor = ConsoleColor.Cyan;

            foreach (char letter in messageToPrint)
            {
                Console.Write(letter);
                Thread.Sleep(100);
            }
            Console.WriteLine();
          
            // Set the console color back to the original color
            Console.ForegroundColor = _originalColor;
        }

        /// <summary>
        /// Shows the introduction to Fighting Fantasy
        /// </summary>
        private static void displayIntroduction()
        {
            ConsoleColor _originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("================================================================================");
            Thread.Sleep(300);
            Console.WriteLine("|                                                                              |");
            Thread.Sleep(300);
            Console.WriteLine("|                               Fighting Fantasy                               |");
            Thread.Sleep(300);
            Console.WriteLine("|                                                                              |");
            Thread.Sleep(300);
            Console.WriteLine("|                           Programmed by Alex Burt                            |");
            Thread.Sleep(300);
            Console.WriteLine("|                          Ideas by Robert Caradain                            |");
            Thread.Sleep(300);
            Console.WriteLine("|                                                                              |");
            Thread.Sleep(300);
            Console.WriteLine("|                                                                              |");
            Thread.Sleep(300);
            Console.WriteLine("================================================================================\n\n");
            Thread.Sleep(300);

            Console.ForegroundColor = _originalColor;
        }

        public static void displayMainMenu() 
        {
            ConsoleColor _originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;

            printAIMessage("What would you like to do?");

            Console.ForegroundColor = _originalColor;

            Console.WriteLine("1. Start a new game\n2. Load a save game\n3. Exit\n");
            Console.Write("Your selection: ");
            Thread.Sleep(100);
            ConsoleKeyInfo _userSelectionKey = Console.ReadKey();
            Console.WriteLine();

            switch (_userSelectionKey.Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("\nAre you sure you want to start a new game?\nThis will overwrite your old save game!");
                    Console.Write("Y/N?: ");
                    ConsoleKeyInfo _selection = Console.ReadKey();
                    if (_selection.Key == ConsoleKey.Y)
                    {
                        printAIMessage("\n\nStarting new game...");
                        Thread.Sleep(1000);
                        XmlManagement.firstGameSetup(_playerName, _playerRace);
                    }
                    break;
                case ConsoleKey.D2:
                    break;
                case ConsoleKey.D3:
                    break;
                default:
                    break;
            }
        }
    }
}
