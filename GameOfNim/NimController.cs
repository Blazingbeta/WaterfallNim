using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GameOfNim {
    public class NimController {

        private Player player1;
        private Player player2;
        private int[] heaps;

        public AudioManager audioMan = new AudioManager();
        public static NimController Instance;

        public static bool SetUpInstance() {
            Instance = new NimController();
            Instance.SetConsoleFont();
            return true;
        }

        public void RunNim() {
            List<string> gameMenu = new List<string>(
                    new string[] { "Play Player vs. Player", "Play Player vs. Computer", "Rules of Nim", "Quit" }
                );
            List<string> boardMenu = new List<string>(
                new string[] { "3 x 3", "2 x 5 x 7", "2 x 3 x 8 x 9"}
                );
            List<string> difficultyMenu = new List<string>(
                new string[] { "Easy", "Medium", "Hard" }
                );

            bool playing = true;
            while (playing) {
                

                int seletion = GetMenuInput(gameMenu);

                int boardType = 0;
                string name = "";

                bool hasWon = false;
                int heap;
                int amo;
                switch (seletion) {
                    case 1:
                        boardType = GetMenuInput(boardMenu);
                        switch (boardType) {
                            case 1:
                                heaps = new int[2];
                                heaps[0] = 3;
                                heaps[1] = 3;
                                break;
                            case 2:
                                heaps = new int[3];
                                heaps[0] = 2;
                                heaps[1] = 5;
                                heaps[2] = 7;
                                break;
                            case 3:
                                heaps = new int[4];
                                heaps[0] = 2;
                                heaps[1] = 3;
                                heaps[2] = 8;
                                heaps[3] = 9;
                                break;
                        }

                        Console.WriteLine("What is Player 1's name?");
                        name = GetStringInput();
                        player1 = new Human(name, 1);

                        Console.WriteLine("What is Player 2's name?");
                        name = GetStringInput();
                        player2 = new Human(name, 2);

                        while (!hasWon) {
                            DisplayHeaps();
                            player1.TakeTurn(out heap, out amo);
                            heaps[heap] -= amo;
                            if (heaps.Sum() == 0) {
                                Console.WriteLine(player2.playerName + " Won!" + player1.playerName + " Lost!");
                                hasWon = true;
                            }
                            DisplayHeaps();
                            player2.TakeTurn(out heap, out amo);
                            heaps[heap] -= amo;
                            if (heaps.Sum() == 0) {
                                Console.WriteLine(player1.playerName + " Won!" + player2.playerName + " Lost!");
                                hasWon = true;
                            }
                        }

                        break;
                    case 2:
                        Console.WriteLine("What board size do you want to play?");
                        boardType = GetMenuInput(boardMenu);
                        switch (boardType) {
                            case 1:
                                heaps = new int[2];
                                heaps[0] = 3;
                                heaps[1] = 3;
                                break;
                            case 2:
                                heaps = new int[3];
                                heaps[0] = 2;
                                heaps[1] = 5;
                                heaps[2] = 7;
                                break;
                            case 3:
                                heaps = new int[4];
                                heaps[0] = 2;
                                heaps[1] = 3;
                                heaps[2] = 8;
                                heaps[3] = 9;
                                break;
                        }

                        Console.WriteLine("What is Player 1's name?");
                        name = GetStringInput();
                        player1 = new Human(name, 1);

                        Console.WriteLine("What is the computer's difficulty?");
                        int diff = GetMenuInput(difficultyMenu);
                        player2 = new Computer(diff - 1);

                        while (!hasWon) {
                            DisplayHeaps();
                            player1.TakeTurn(out heap, out amo);
                            heaps[heap] -= amo;
                            if(heaps.Sum() == 0) {
                                Console.WriteLine(player2.playerName + " Won!" + player1.playerName + " Lost!");
                                hasWon = true;
                            }
                            DisplayHeaps();
                            player2.TakeTurn(out heap, out amo);
                            heaps[heap] -= amo;
                            if (heaps.Sum() == 0) {
                                Console.WriteLine(player1.playerName + " Won!" + player2.playerName + " Lost!");
                                hasWon = true;
                            }
                        }

                        break;
                    case 3:
                        Console.WriteLine("\nNim is a game about picking up sticks. " +
                            "\nThere are several piles of sticks.You can choose to pick up as many as want from any pile." +
                            "\n\nHeap 1: | |" +
                            "\nHeap 2: | | | | |" +
                            "\nHeap 3: | | | | | | |" +
                            "\n\nFor example, you can pick up to 2 sticks from Pile 1, or up to 7 sticks from Pile 3." +
                            "\nIf you pick up the last stick, you lose." +
                            "\nPress Enter to go back.");
                        Console.ReadLine();
                        break;
                    case 4:
                        playing = false;
                        break;
                }
            }
            Console.WriteLine("Thanks for Playing");
        }

        public void DisplayHeaps() {
            Console.WriteLine();
            for(int i = 0; i < heaps.Length; i++) {
                Console.Write(i + ". ");
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


        public void SetConsoleFont(string fontName = "Comic Sans MS") {
            unsafe {
                IntPtr hnd = ConsoleHelpers.GetStdHandle(-11);
                IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);
                if (hnd != INVALID_HANDLE_VALUE) {
                    // Set console font to Comic Sans MS
                    ConsoleHelpers.CONSOLE_FONT_INFO_EX newInfo = new ConsoleHelpers.CONSOLE_FONT_INFO_EX();
                    newInfo.cbSize = (uint)Marshal.SizeOf(newInfo);
                    newInfo.FontFamily = 4;
                    IntPtr ptr = new IntPtr(newInfo.FaceName);
                    Marshal.Copy(fontName.ToCharArray(), 0, ptr, fontName.Length);

                    // Get some settings from current font.
                    newInfo.dwFontSize = new ConsoleHelpers.COORD(20, 20);
                    newInfo.FontWeight = 14;
                    ConsoleHelpers.SetCurrentConsoleFontEx(hnd, false, ref newInfo);
                }
            }
        }
    }
}
