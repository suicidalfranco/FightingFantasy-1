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

        int playerHealth;
        int playerArmour;
        int playerMana;


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
            string _playerName;
            string _playerRace;

            if (File.Exists("player.xml") != true)
            {
                _playerName = getPlayerName();
                Thread.Sleep(200);
                _playerRace = getPlayerRace(_playerName, false);
                firstGameSetup(_playerName, _playerRace);
            }
        }

        /// <summary>
        /// Asks the player for a character name and returns the name as a string
        /// </summary>
        /// <returns></returns>
        private static string getPlayerName()
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
        private static string getPlayerRace(string _playerName, bool goAgain)
        {
            // If this is the first time the function has run through, complete first bit of code
            if (goAgain == false) 
            {
                printAIMessage("\nAhhh! Welcome " + _playerName + "!");
                printAIMessage("Tell me, what race are you?\n");
            }
            else 
            {
                printAIMessage("I'm sorry, I didn't quite catch that?");
            }

            Console.WriteLine("1. Human\n2. Elf\n3. Dwarf");
            Console.Write("Your race: ");
            ConsoleKeyInfo _playerRaceKey = Console.ReadKey(); // Get the key the user pressed
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

        public static void printAIMessage(string messageToPrint)
        {
            foreach (char letter in messageToPrint)
            {
                Console.Write(letter);
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// Creates the XML file that stores the players details in it
        /// when the game is first run.
        /// </summary>
        /// <param name="playerName"></param>
        private static void firstGameSetup(string _playerName, string _playerRace)
        {
            // Create the XmlWriterSettings and set the indent to true
            XmlWriterSettings _settings = new XmlWriterSettings();
            _settings.Indent = true;

            XmlWriter _writer = XmlWriter.Create("player.xml", _settings);
            _writer.WriteStartDocument();
            _writer.WriteComment("This file holds all information about the game state when saved");
            _writer.WriteStartElement("Player");
            _writer.WriteAttributeString("Name", _playerName);
            _writer.WriteAttributeString("Race", _playerRace);



        }

        /// <summary>
        /// Shows the introduction to Fighting Fantasy
        /// </summary>
        private static void displayIntroduction()
        {
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
        }



    }
}
