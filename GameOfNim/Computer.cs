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
			Heap = 0;
			Amount = 0;
		}
		private void TurnMedium(out int Heap, out int Amount)
		{
			Heap = 0;
			Amount = 0;
		}
		private void TurnHard(out int Heap, out int Amount)
		{
			Heap = 0;
			Amount = 0;
		}
	}
}
