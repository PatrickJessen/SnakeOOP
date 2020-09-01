using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeOOP
{
    class Snake
    {
        public int snakePosX { get; set; }
        public int snakePosY { get; set; }

        public Snake()
        {
            snakePosX = 100;
            snakePosY = 100;
        }
    }
}
