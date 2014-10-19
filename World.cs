using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fighting_Fantasy
{
    class World
    {
        int[,] Labyrinth = new int [10,10]; //creates a 10x10 matrix that will serve as the game's map

        /// <summary>map draw
        /// draws current map state
        /// </summary>
        /// <param name="Labyrinth"></param>
        public static void Map(int[,] Labyrinth)
        {
            
            int rowLength = Labyrinth.GetLength(0);
            int colLength = Labyrinth.GetLength(1);

            for(int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0} ", Labyrinth[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
            Console.ReadLine();
 
         }

        /// <summary>random player location
        /// when launching the game for the first time, gives random coordinates
        /// for the players location on the map
        /// </summary>
        public static void InitializePPOS()
        {
            Random rand = new Random();
            int[,] target = new int[10, 10];

            Program._playerPositionN = rand.Next(10);
            Program._playerPositionM = rand.Next(10);
            target[Program._playerPositionN, Program._playerPositionM] = 4;
            
            if(Program._playerPositionN == 0)
            {
                Program._playerPointer = Program._playerPositionN + 1;
            }
            else
            {
                Program._playerPointer = Program._playerPositionN - 1;
            }
            target[Program._playerPointer, Program._playerPositionM] = 5;
            Map(target);
        }

        /// <summary>player movement
        /// player's movement pattern
        /// </summary>
        public static void Move()
        {
            int oldPointer, oldN, oldM;
            int[,] target = new int[10, 10];

            if(Program._playerOrder == "move right")
            {
                if(Program._playerPointer == 9)
                {
                    Program.printAIMessage("already against the wall");
                }
                else
                {
                    oldM = Program._playerPositionM;
                    oldPointer = Program._playerPointer;
                    target[Program._playerPositionN, oldM] = 0;
                    target[Program._playerPositionN, oldPointer] = 0;

                    Program._playerPositionM += 1;
                    Program._playerPointer = Program._playerPositionM + 1;
                    target[Program._playerPositionN, Program._playerPositionM] = 4;
                    target[Program._playerPositionN, Program._playerPointer] = 5;

                    Map(target);
                }
            }

            else if(Program._playerOrder == "move left")
            {
                if (Program._playerPointer == 0)
                {
                    Program.printAIMessage("already against the wall");
                }
                else
                {
                    oldM = Program._playerPositionM;
                    oldPointer = Program._playerPointer;
                    target[Program._playerPositionN, oldM] = 0;
                    target[Program._playerPositionN, oldPointer] = 0;

                    Program._playerPositionM -= 1;
                    Program._playerPointer = Program._playerPositionM - 1;
                    target[Program._playerPositionN, Program._playerPositionM] = 4;
                    target[Program._playerPositionN, Program._playerPointer] = 5;

                    Map(target);
                }

            }
            else if(Program._playerOrder == "move up")
            {
                if ((Program._playerPointer == 0) && (Program._playerPositionN == 1))
                {
                    Program.printAIMessage("already against the wall");
                }
                else
                {
                    oldN = Program._playerPositionN;
                    oldPointer = Program._playerPointer;
                    target[oldN, Program._playerPositionM] = 0;
                    target[oldPointer, Program._playerPositionM] = 0;

                    Program._playerPositionN -= 1;
                    Program._playerPointer = Program._playerPositionN - 1;
                    target[Program._playerPositionN, Program._playerPositionM] = 4;
                    target[Program._playerPointer, Program._playerPositionM] = 5;

                    Map(target);
                }
            }

            else
            {
                if (Program._playerPointer == 9)
                {
                    Program.printAIMessage("already against the wall");
                }
                else
                {
                    oldN = Program._playerPositionN;
                    oldPointer = Program._playerPointer;
                    target[oldN, Program._playerPositionM] = 0;
                    target[oldPointer, Program._playerPositionM] = 0;

                    Program._playerPositionN += 1;
                    Program._playerPointer = Program._playerPositionN + 1;
                    target[Program._playerPositionN, Program._playerPositionM] = 4;
                    target[Program._playerPointer, Program._playerPositionM] = 5;

                    Map(target);
                }
            }
        }

     }
}
