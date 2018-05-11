using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfNim
{
	public class Computer : Player
	{
		private int m_difficulty;
		public Computer(int level)
		{
			m_difficulty = level;
		}
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
		private void TurnEasy(out int Heap, out int Amount)
		{
			int[] board = NimController.Instance.GetHeaps();
			Random rng = new Random();
			Heap = rng.Next(board.Length);
			while(board[Heap] != 0)
			{
				Heap = rng.Next(board.Length);
			}
			if(board[Heap] == 1)
			{
				Amount = 1;
				return;
			}
			Amount = rng.Next(1, board[Heap]-1);
		}
		private void TurnMedium(out int Heap, out int Amount)
		{
			int[] board = NimController.Instance.GetHeaps();
			List<int> preferedIndicies = new List<int>();
			for(int j = 0; j < board.Length; j++)
			{
				if (board[j] >= 2) preferedIndicies.Add(j);
			}
			if (preferedIndicies.Count == 0)
			{
				//No piles with 2 remaing
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
			else if (preferedIndicies.Count == 1)
			{
				Heap = preferedIndicies[0];
				Amount = board[Heap] - 1;
			}
			else
			{
				Random rng = new Random();
				Heap = preferedIndicies[rng.Next(preferedIndicies.Count)];
				Amount = 2;
			}
		}
		private void TurnHard(out int Heap, out int Amount)
		{
			Heap = 0;
			Amount = 0;
		}
	}
}
