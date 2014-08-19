using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fighting_Fantasy
{
    class Human
    {
        public int baseHealth = 20;
        public int baseArmour = 5;
        public int baseMana = 10;

        public Human(int playerLevel)
        {
            setHelm();
        }
    }
}
