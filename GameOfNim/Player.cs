using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfNim
{
	/// <summary>
	/// Abstract class for a NimPlayer.
	/// Polymorphic to Computer and Human
	/// </summary>
	public abstract class Player
	{
		public string playerName;
		/// <summary>
		/// Causes the Player to take a turn, returning it's heap and amount
		/// </summary>
		/// <param name="Heap">Return parameter for the selected valid heap, range 0-boardSize-1</param>
		/// <param name="Amount">Return parameter for the amount to take from the selected heap</param>
		public abstract void TakeTurn(out int Heap, out int Amount);
	}
}
