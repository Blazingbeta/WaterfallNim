using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GameOfNim
{
	class ConsoleHelpers
	{


		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal unsafe struct CONSOLE_FONT_INFO_EX
		{
			internal uint cbSize;
			internal uint nFont;
			internal COORD dwFontSize;
			internal int FontFamily;
			internal int FontWeight;
			internal fixed char FaceName[32];
		}
		[StructLayout(LayoutKind.Sequential)]
		internal struct COORD
		{
			internal short X;
			internal short Y;

			internal COORD(short x, short y)
			{
				X = x;
				Y = y;
			}
		}

		[DllImport("kernel32.dll", SetLastError = true)]
		static extern public  bool SetCurrentConsoleFontEx(
			IntPtr consoleOutput,
			bool maximumWindow,
			ref CONSOLE_FONT_INFO_EX consoleCurrentFontEx);

		[DllImport("kernel32.dll", SetLastError = true)]
		static extern public IntPtr GetStdHandle(int dwType);


		[DllImport("kernel32.dll", SetLastError = true)]
		static extern public  int SetConsoleFont(
			IntPtr hOut,
			uint dwFontNum
			);


		
	}
}
