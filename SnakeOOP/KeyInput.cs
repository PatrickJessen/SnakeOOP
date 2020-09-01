using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace SnakeOOP
{
    class KeyInput
    {
        private static Hashtable keyTable = new Hashtable();

        public static bool KeyPress(Keys keys)
        {
            if (keyTable[keys] == null)
            {
                return false;
            }
            return (bool)keyTable[keys];
        }

        public static void ChangeState(Keys keys, bool state)
        {
            keyTable[keys] = state;
        }
    }
}
