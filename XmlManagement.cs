using System;
using System.Xml;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fighting_Fantasy
{
    class XmlManagement
    {

        /// <summary>
        /// Creates the XML file that stores the players details in it
        /// when the game is first run.
        /// </summary>
        /// <param name="playerName"></param>
        public static void firstGameSetup(string _playerName, string _playerRace)
        {
            Program._playerName = Program.getPlayerName();
            Thread.Sleep(200);
            Program._playerRace = Program.getPlayerRace(Program._playerName, false);

            Random r = new Random();

            if (Program._playerRace == "Human")
            {
                Program.printAIMessage("So a human called " + Program._playerName + "... A fitting name if I do say so myself!");
            }
            else if (Program._playerRace == "Elf")
            {
                Program.printAIMessage("So an elf called " + Program._playerName + "... A fitting name if I do say so myself!");
            }
            else if (Program._playerRace == "Dwarf")
            {
                Program.printAIMessage("So a dwarf called " + Program._playerName + "... A fitting name if I do say so myself!");
            }


            // Create the XmlWriterSettings and set the indent to true
            XmlWriterSettings _settings = new XmlWriterSettings();
            _settings.Indent = true;

            // Load the player.xml file with the settings
            XmlWriter _writer = XmlWriter.Create("player.xml", _settings);
            _writer.WriteStartDocument();
            _writer.WriteComment("This file holds all information about the game state when saved");
            _writer.WriteStartElement("Player");
                _writer.WriteAttributeString("Name", _playerName);
                _writer.WriteAttributeString("Race", _playerRace);
            _writer.WriteEndElement();
            _writer.WriteEndDocument();

            // Flush the writer and close it
            _writer.Flush();
            _writer.Close();
        }

        /// <summary>
        /// Read data from "player.xml" into set variables
        /// </summary>
        public static void readFromPlayerXml()
        {

            // Create the Xml Reader
            XmlReader _reader = XmlReader.Create("player.xml");

            while (_reader.Read())
            {
                if (_reader.NodeType == XmlNodeType.Element && _reader.Name == "Player")
                {
                    Program._playerName = _reader.GetAttribute(0);
                    Program._playerRace = _reader.GetAttribute(1);
                }
            }

            _reader.Close();
        }
    }
}
