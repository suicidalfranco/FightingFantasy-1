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

        private static void checkGameState()
        {
            string _playerName;
            string _playerRace;

            if (File.Exists("player.xml") != true)
            {
                _playerName = getPlayerName();
                _playerRace = getPlayerRace(_playerName);
                firstGameSetup(_playerName);
            }
        }

        private static string getPlayerRace(string _playerName)
        {
            Console.WriteLine("Ahhh! Welcome " + _playerName + "!");
            Console.WriteLine("Tell me, what race are you?\n");
            Console.WriteLine("1. Human\n2. Elf\n3. Dwarf\n4. Undead\n5. ")
        }

        private static string getPlayerName()
        {
            Console.WriteLine("Welcome traveller! What is your name?\n");
            Console.Write("My name is: ");
            string _playerName = Console.ReadLine();
            return _playerName;
        }

        /// <summary>
        /// Creates the XML file that stores the players details in it
        /// when the game is first run.
        /// </summary>
        /// <param name="playerName"></param>
        private static void firstGameSetup(string _playerName)
        {
            // Create the XmlWriterSettings and set the indent to true
            XmlWriterSettings _settings = new XmlWriterSettings();
            _settings.Indent = true;

            XmlWriter _writer = XmlWriter.Create("player.xml", _settings);
            _writer.WriteStartDocument();
            _writer.WriteComment("This file holds all information about the game state when saved");
            _writer.WriteStartElement("Player");
            _writer.WriteAttributeString("Name", _playerName);
            _writer.WriteAttributeString("Race", _playerRace)



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
