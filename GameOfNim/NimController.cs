using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfNim {
    public class NimController {

        private Player player1;
        private Player player2;
        private int[] heaps;

        private AudioManager audioMan;
        public static NimController Instance;

        public void SetUpInstance() {
            Instance = new NimController();
        }

        public void RunNim() {

        }

        public void DisplayHeaps() {
            for(int i = 0; i < heaps.Length; i++) {
                for(int y = 0; y < heaps[i]; y++) {
                    Console.Write("| ");
                }
                Console.WriteLine();
            }
        }

        public static string GetStringInput() {
            string input = Console.ReadLine();

            return input;
        }
        public static int GetIntInput() {
            int num = 0;

            while(!int.TryParse(Console.ReadLine(), out num)) {
                Console.WriteLine("That is not a valid int.");
            }

            return num;
        }
        public static int GetMenuInput(List<string> options) {
            bool isInvalid = true;
            int num = 0;
            while (isInvalid) {
                for (int i = 0; i < options.Count; i++) {
                    Console.WriteLine(i + 1 + ". " + options[i]);
                }
                num = GetIntInput();
                isInvalid = num < 1 || num > options.Count;
                if (isInvalid) {
                    Console.WriteLine("Please enter a number between 1 and " + options.Count);
                }
            }

            return num;
        }

        public int[] GetHeaps() {
            return heaps;
        }


        private void SetConsoleFont() {

        }
    }
}
