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
        // GLOBAL VARIABLES TO DO WITH PLAYER STATS
        int playerBaseHealth; // THE PLAYERS BASE HEALTH
        int playerBaseArmour; // THE PLAYERS BASE ARMOUR
        int playerBaseMana; // THE PLAYERS BASE MANA

        // GLOBAL VARIBALES TO DO WITH PLAYER NAME AND RACE
        public static string _playerName;
        public static string _playerRace;
        public static int _playerPositionN;
        public static int _playerPositionM;
        public static int _playerPointer;
        public static string _playerOrder;

        static void Main(string[] args)
        {
            // DISPLAY THE INTRODUCTION FOR THE GAME
            displayIntroduction();

            // CHECK WETHER THE GAME HAS BEEN RUN BEFORE
            checkGameState();


            // END PROGRAM HERE
            Console.ReadKey();            
        }

        /// <summary>Control game status
        /// CHECK THE STATE OF THE GAME TO SEE IF IT IS BEING RUN FOR THE FIRST TIME
        /// OR THE USER IS RETURNING TO CONTINUE PLAYING FROM WHERE THEY LEFT OFF.
        /// </summary>
        private static void checkGameState()
        {
            // IF THE FILE "PLAYER.XML" DOESN'T EXIST, RUN THE FIRST SETUP TO GET USER NAME AND
            // RACE THEN SAVE THE IMFORMATION TO "PLAYER.XML"
            // ELSE READ THE SAVE DATA FROM "PLAYER.XML" AND CONTINUE
            if (File.Exists("player.xml") != true)
            {
                XmlManagement.firstGameSetup(_playerName, _playerRace);
                
                while(_playerOrder != "quit")
                {
                    Orders();
                }
            }
            else
            {
                XmlManagement.readFromPlayerXml();
                printAIMessage("Welcome back " + _playerName + "!");
                while (_playerOrder != "quit")
                {
                    Orders();
                }
            }
        }

        /// <summary>Name input
        /// ASKS THE PLAYER FOR A CHARACTER NAME AND RETURNS THE NAME AS A STRING
        /// </summary>
        /// <returns></returns>
        public static string getPlayerName()
        {
            printAIMessage("Welcome traveller! What is your name?\n");
            Console.Write("My name is: ");
            string _playerName = Console.ReadLine();
            return _playerName;
        }

        /// <summary>Race input
        /// ASKS THE PLAYER TO SELECT A RACE AND RETURNS THE RACE AS A STRING.
        /// </summary>
        /// <param name="_playerName">The players character name</param>
        /// <param name="goAgain">Did the user press a wrong key?</param>
        /// <returns></returns>
        public static string getPlayerRace(string _playerName, bool goAgain)
        {
            // IF THIS IS THE FIRST TIME THE FUNCTION HAS RUN THROUGH, COMPLETE FIRST BIT OF CODE
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
            ConsoleKeyInfo _playerRaceKey = Console.ReadKey(); // GET THE KEY THE USER PRESSED
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
                    getPlayerRace(_playerName, true); // RE-RUN THE FUNCTION WITH GOAGAIN AS "TRUE"
                    break;
            }

            return null;
        }

        /// <summary>Text control
        /// PRINTS A MESSAGE TO THE CONSOLE WITH A SLIGHT DELAY BETWEEN EACH
        /// CHARACTER TO SEPARATE GAME AND AI TEXT
        /// </summary>
        /// <param name="messageToPrint"></param>
        public static void printAIMessage(string messageToPrint)
        {
            // GET THE ORIGINAL COLOR OF THE CONSOLE
            ConsoleColor _originalColor = Console.ForegroundColor;
            // SET THE NEW COLOR TO CYAN
            Console.ForegroundColor = ConsoleColor.Cyan;

            // FOR EVERY LETTER IN THE STRING GIVEN, PRINT EACH CHARACTER SEPARATELY WITH
            // A SMALL PAUSE IN BETWEEN
            foreach (char letter in messageToPrint)
            {
                Console.Write(letter);
                Thread.Sleep(50);
            }
            Console.WriteLine();
          
            // SET THE CONSOLE COLOR BACK TO THE ORIGINAL COLOR
            Console.ForegroundColor = _originalColor;
        }

        /// <summary>Intro
        /// SHOWS THE INTRODUCTION TO FIGHTING FANTASY
        /// </summary>
        private static void displayIntroduction()
        {
            // STORE THE ORIGINAL FOREGROUND COLOR AND CHANGE IT TO RED
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
        
        /// <summary>command input
        /// check for command inputed by the player
        /// </summary>
        private static void Orders()
        {
            printAIMessage("what do you want to do?");
            _playerOrder = Console.ReadLine();
            if (_playerOrder.Contains("move"))
            {
                World.Move();
            }
        }
        public static void displayMainMenu() 
        {
            // STORE THE ORIGINAL FOREGROUND COLOR AND CHANGE TO CYAN
            ConsoleColor _originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;

            printAIMessage("What would you like to do?");

            Console.ForegroundColor = _originalColor;

            Console.WriteLine("1. Start a new game\n2. Load a save game\n3. Exit\n");
            Console.Write("Your selection: ");
            Thread.Sleep(100);
            ConsoleKeyInfo _userSelectionKey = Console.ReadKey(); // GET THE USER TO PRESS A KEY
            Console.WriteLine();

            // LOOK AT WHICH KEY WAS PRESSED
            switch (_userSelectionKey.Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("\nAre you sure you want to start a new game?\nThis will overwrite your old save game!");
                    Console.Write("Y/N?: ");
                    ConsoleKeyInfo _selection = Console.ReadKey(); // GET THE USERS INPUT AS A KEY
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
