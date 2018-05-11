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
			playerName = name;
			//If name is invalid, name is "Player " + playerNum
		}
		public override void TakeTurn(out int Heap, out int Amount)
		{
			throw new NotImplementedException();
		}
	}
}
