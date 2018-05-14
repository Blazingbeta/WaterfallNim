using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfNim {
    public class AudioManager {

        public void ValidBeep() 
        {
            Console.Beep(400, 400);
        }

        public void InvalidBeep() 
        {
            Console.Beep(800, 400);
        }

        public bool StartMusic() 
        {
            return false;
        }

    }
}
