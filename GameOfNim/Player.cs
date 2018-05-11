using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfNim
{
	public abstract class Player
	{
		public string playerName;
		public abstract void TakeTurn(out int Heap, out int Amount);
	}
}
