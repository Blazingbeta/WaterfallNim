using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

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
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                while(true)
                {
                    Console.Beep(658, 125);
                    Console.Beep(1320, 500);
                    Console.Beep(990, 250);
                    Console.Beep(1056, 250);
                    Console.Beep(1188, 250);
                    Console.Beep(1320, 125);
                    Console.Beep(1188, 125);
                    Console.Beep(1056, 250);
                    Console.Beep(990, 250);
                    Console.Beep(880, 500);
                    Console.Beep(880, 250);
                    Console.Beep(1056, 250);
                    Console.Beep(1320, 500);
                    Console.Beep(1188, 250);
                    Console.Beep(1056, 250);
                    Console.Beep(990, 750);
                    Console.Beep(1056, 250);
                    Console.Beep(1188, 500);
                    Console.Beep(1320, 500);
                    Console.Beep(1056, 500);
                    Console.Beep(880, 500);
                    Console.Beep(880, 500);
                    Thread.Sleep(250);
                    Console.Beep(1188, 500);
                    Console.Beep(1408, 250);
                    Console.Beep(1760, 500);
                    Console.Beep(1584, 250);
                    Console.Beep(1408, 250);
                    Console.Beep(1320, 750);
                    Console.Beep(1056, 250);
                    Console.Beep(1320, 500);
                    Console.Beep(1188, 250);
                    Console.Beep(1056, 250);
                    Console.Beep(990, 500);
                    Console.Beep(990, 250);
                    Console.Beep(1056, 250);
                    Console.Beep(1188, 500);
                    Console.Beep(1320, 500);
                    Console.Beep(1056, 500);
                    Console.Beep(880, 500);
                    Console.Beep(880, 500);
                    Thread.Sleep(500);
                    Console.Beep(1320, 500);
                    Console.Beep(990, 250);
                    Console.Beep(1056, 250);
                    Console.Beep(1188, 250);
                    Console.Beep(1320, 125);
                    Console.Beep(1188, 125);
                    Console.Beep(1056, 250);
                    Console.Beep(990, 250);
                    Console.Beep(880, 500);
                    Console.Beep(880, 250);
                    Console.Beep(1056, 250);
                    Console.Beep(1320, 500);
                    Console.Beep(1188, 250);
                    Console.Beep(1056, 250);
                    Console.Beep(990, 750);
                    Console.Beep(1056, 250);
                    Console.Beep(1188, 500);
                    Console.Beep(1320, 500);
                    Console.Beep(1056, 500);
                    Console.Beep(880, 500);
                    Console.Beep(880, 500);
                    Thread.Sleep(250);
                    Console.Beep(1188, 500);
                    Console.Beep(1408, 250);
                    Console.Beep(1760, 500);
                    Console.Beep(1584, 250);
                    Console.Beep(1408, 250);
                    Console.Beep(1320, 750);
                    Console.Beep(1056, 250);
                    Console.Beep(1320, 500);
                    Console.Beep(1188, 250);
                    Console.Beep(1056, 250);
                    Console.Beep(990, 500);
                    Console.Beep(990, 250);
                    Console.Beep(1056, 250);
                    Console.Beep(1188, 500);
                    Console.Beep(1320, 500);
                    Console.Beep(1056, 500);
                    Console.Beep(880, 500);
                    Console.Beep(880, 500);
                    Thread.Sleep(500);
                    Console.Beep(660, 1000);
                    Console.Beep(528, 1000);
                    Console.Beep(594, 1000);
                    Console.Beep(495, 1000);
                    Console.Beep(528, 1000);
                    Console.Beep(440, 1000);
                    Console.Beep(419, 1000);
                    Console.Beep(495, 1000);
                    Console.Beep(660, 1000);
                    Console.Beep(528, 1000);
                    Console.Beep(594, 1000);
                    Console.Beep(495, 1000);
                    Console.Beep(528, 500);
                    Console.Beep(660, 500);
                    Console.Beep(880, 1000);
                    Console.Beep(838, 2000);
                    Console.Beep(660, 1000);
                    Console.Beep(528, 1000);
                    Console.Beep(594, 1000);
                    Console.Beep(495, 1000);
                    Console.Beep(528, 1000);
                    Console.Beep(440, 1000);
                    Console.Beep(419, 1000);
                    Console.Beep(495, 1000);
                    Console.Beep(660, 1000);
                    Console.Beep(528, 1000);
                    Console.Beep(594, 1000);
                    Console.Beep(495, 1000);
                    Console.Beep(528, 500);
                    Console.Beep(660, 500);
                    Console.Beep(880, 1000);
                    Console.Beep(838, 2000);
                }
            }).Start();


            return true;
        }

    }
}
