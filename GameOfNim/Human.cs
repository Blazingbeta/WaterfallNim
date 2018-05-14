using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfNim
{
	public class Human : Player
	{
		public Human(string name, int playerNum)
		{
            if(name == null || name == "")
            {
                playerName = "Player " + playerNum;
            }
            else
            {
			    playerName = name;
            }

			//If name is invalid, name is "Player " + playerNum
		}
		public override void TakeTurn(out int Heap, out int Amount)
		{
            int[] board = NimController.Instance.GetHeaps();

            int tempHeap = 0;
            int tempAmount = 0;

            while(true)
            {
                Console.WriteLine("Please enter a heap number between 0 and " + (board.Length - 1));
                tempHeap = NimController.GetIntInput();
                if (tempHeap > board.Length - 1 || tempHeap < 0 || board[tempHeap] <= 0)
                {
                    Console.WriteLine("That is not a valid heap selection.");
                }
                else
                {
                    break;
                }
            }

            while(true)
            {
                Console.WriteLine("Please enter the number you want to grab, (Up to " + board[tempHeap] + ")");
                tempAmount = NimController.GetIntInput();
                if(tempAmount > board[tempHeap] || tempAmount < 1)
                {
                    Console.WriteLine("That is not a valid amount to select.");
                }
                else
                {
                    break;
                }
            }


            Heap = tempHeap;
            Amount = tempAmount;

		}
	}
}
