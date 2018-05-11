using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfNim
{
	/// <summary>
	/// An AI player, polymorphic to Player
	/// </summary>
	public class Computer : Player
	{
		private int m_difficulty;
		public Computer(int level)
		{
			m_difficulty = level;
		}
		/// <summary>
		/// Takes a turn based on this computer's difficulty value
		/// </summary>
		/// <param name="Heap">Return value for selected heap, 0-boardSize-1 range</param>
		/// <param name="Amount">The amount of sticks to take from the selected heap</param>
		public override void TakeTurn(out int Heap, out int Amount)
		{
			switch (m_difficulty)
			{
				case 0:
					TurnEasy(out Heap, out Amount);
					break;
				case 1:
					TurnMedium(out Heap, out Amount);
					break;
				default:
					TurnHard(out Heap, out Amount);
					break;

			}
		}
		/// <summary>
		/// Takes a random amount from a random valid heap
		/// </summary>
		/// <param name="Heap"></param>
		/// <param name="Amount"></param>
		private void TurnEasy(out int Heap, out int Amount)
		{
			int[] board = NimController.Instance.GetHeaps();
			Random rng = new Random();
			Heap = rng.Next(board.Length);
			//Loops until we randomly select a good value
			while(board[Heap] != 0)
			{
				Heap = rng.Next(board.Length);
			}
			//If there is only 1 stick in the selected pile
			if(board[Heap] == 1)
			{
				Amount = 1;
				return;
			}
			//Otherwise take a random amount from 1 to size-1
			Amount = rng.Next(1, board[Heap]-1);
		}
		/// <summary>
		/// Attempst to find the first heap with at least 2 remaining and take 2 from it
		/// </summary>
		/// <param name="Heap"></param>
		/// <param name="Amount"></param>
		private void TurnMedium(out int Heap, out int Amount)
		{
			int[] board = NimController.Instance.GetHeaps();
			List<int> preferedIndicies = new List<int>();
			//Adds all indicies with at least 2 to a list
			for(int j = 0; j < board.Length; j++)
			{
				if (board[j] >= 2) preferedIndicies.Add(j);
			}
			//If no piles with 2 remain
			if (preferedIndicies.Count == 0)
			{
				//Take 1 from the first avalible heap
				for (int j = 0; j < board.Length; j++)
				{
					if (board[j] == 1)
					{
						Heap = j;
						Amount = 1;
						return;
					}
				}
				throw new ArgumentException("Error: An empty board was passed to TurnMedium.");
			}
			//If there is only one heap with at least 2 remaining, takes all but one, assuring a win
			else if (preferedIndicies.Count == 1)
			{
				Heap = preferedIndicies[0];
				Amount = board[Heap] - 1;
			}
			//Otherwise, takes 2 from a random preferedIndicie
			else
			{
				Random rng = new Random();
				Heap = preferedIndicies[rng.Next(preferedIndicies.Count)];
				Amount = 2;
			}
		}
		/// <summary>
		/// Finds the nimsum of the current boardstate and uses that to calculate the optimal move
		/// </summary>
		/// <param name="Heap"></param>
		/// <param name="Amount"></param>
		private void TurnHard(out int Heap, out int Amount)
		{
			int[] board = NimController.Instance.GetHeaps();
			int nimSum = 0;
			//Setup the nimSum of the board, the unbalanced binary amount that we need to take
			for(int j = 0; j < board.Length; j++)
			{
				nimSum ^= board[j];
			}
			//If nimsum is already 0, the bot is not in a winning state and needs to try and force the player into a mistake
			if(nimSum == 0)
			{
				//Just takes one from the first heap it can, trying to stall the game until player makes a mistake
				for(int j = 0; j < board.Length; j++)
				{
					if(board[j] > 0)
					{
						Heap = j;
						Amount = 1;
						return;
					}
				}
				throw new ArgumentException("Error: An empty board was passed to TurnHard potentially");
			}
			//nimSum is not 0 and the computer can make it 0
			else
			{
				//Loop through the array, looking for a heap large enough to take the nimSum from
				for(int j = 0; j < board.Length; j++)
				{
					//If heap is large enough that we can remove the nimSum from it.
					if(board[j] >= nimSum)
					{
						Heap = j;
						Amount = nimSum;
						return;
					}
				}
				//If no heaps are large enough (unsure if this is possible)
				Console.WriteLine("No heaps were large enough for the NimSum, debug these values.");
				for (int j = 0; j < board.Length; j++)
				{
					if (board[j] > 0)
					{
						Heap = j;
						Amount = 1;
						return;
					}
				}
				throw new ArgumentException("Error: An empty board was passed to TurnHard potentially");
			}
		}
	}
}
