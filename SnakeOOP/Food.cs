using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeOOP
{
    class Food
    {
        public int FoodPosX { get; set; }
        public int FoodPosY { get; set; }
        public int FoodWidth { get; set; }
        public int FoodHeight { get; set; }

        public Food()
        {
            FoodPosX = 100;
            FoodPosY = 160;

            FoodWidth = 15;
            FoodHeight = 15;
        }
    }
}
