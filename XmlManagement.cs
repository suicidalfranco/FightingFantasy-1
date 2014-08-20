using System;
using System.Xml;
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
        }
    }
}
