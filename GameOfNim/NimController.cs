using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfNim {
    public class NimController {

        //Player player1;
        //Player player2;
        //AudioManager audioMan;
        int[] heaps;
        public static NimController Instance;

        public void SetUpInstance() {
            Instance = new NimController();
        }

        public void RunNim() {

        }

        public void DisplayHeaps() {

        }

        public static string GetStringInput() {
            return "";
        }
        public static int GetIntInput() {
            return 0;
        }
        public static int GetMenuInput(List<string> options) {
            return 0;
        }

        public int[] GetHeaps() {
            return heaps;
        }


        private void SetConsoleFont() {

        }
    }
}
