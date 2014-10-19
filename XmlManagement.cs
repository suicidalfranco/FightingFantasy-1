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
        /// CREATES THE XML FILE THAT STORES THE PLAYERS DETAILS IN IT
        /// WHEN THE GAME IS FIRST RUN.
        /// </summary>
        /// <param name="playerName"></param>
        public static void firstGameSetup(string _playerName, string _playerRace)
        {
            // RUN THE FUNCTIONS TO GET THE PLAYERS NAME AND RACE
            World.InitializePPOS();
            Program._playerName = Program.getPlayerName();
            Thread.Sleep(200);
            Program._playerRace = Program.getPlayerRace(Program._playerName, false);

            // RANDOM OBJECT
            Random r = new Random();

            // IF STATEMENT TO SEE WHAT RACE THEY CHOSE AND WHAT IT SHOULD PRINT TO THE CONSOLE
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


            // CREATE THE XMLWRITERSETTINGS AND SET THE INDENT TO TRUE
            XmlWriterSettings _settings = new XmlWriterSettings();
            _settings.Indent = true;

            // LOAD THE PLAYER.XML FILE WITH THE SETTINGS
            XmlWriter _writer = XmlWriter.Create("player.xml", _settings);
            _writer.WriteStartDocument();
            _writer.WriteComment("This file holds all information about the game state when saved");
            _writer.WriteStartElement("Player");
                _writer.WriteAttributeString("Name", _playerName);
                _writer.WriteAttributeString("Race", _playerRace);
            _writer.WriteEndElement();
            _writer.WriteEndDocument();

            // FLUSH THE WRITER AND CLOSE IT
            _writer.Flush();
            _writer.Close();
        }

        /// <summary>
        /// READ DATA FROM "PLAYER.XML" INTO SET VARIABLES
        /// </summary>
        public static void readFromPlayerXml()
        {

            // CREATE THE XML READER
            XmlReader _reader = XmlReader.Create("player.xml");

            
            while (_reader.Read())
            {
                // IF THE NODE TYPE IS AN ELEMENT AND THE NAME IS PLAYER THEN RUN THIS CODE ELSE DO NOTHING
                if (_reader.NodeType == XmlNodeType.Element && _reader.Name == "Player")
                {
                    Program._playerName = _reader.GetAttribute(0);
                    Program._playerRace = _reader.GetAttribute(1);
                }
            }

            // CLOSE THE READER SO THE FILE CAN BE USED AGAIN
            _reader.Close();
        }
    }
}
