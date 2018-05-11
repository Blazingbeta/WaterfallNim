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
		static extern bool SetCurrentConsoleFontEx(
			IntPtr consoleOutput,
			bool maximumWindow,
			ref CONSOLE_FONT_INFO_EX consoleCurrentFontEx);

		[DllImport("kernel32.dll", SetLastError = true)]
		static extern IntPtr GetStdHandle(int dwType);


		[DllImport("kernel32.dll", SetLastError = true)]
		static extern int SetConsoleFont(
			IntPtr hOut,
			uint dwFontNum
			);


		public static void SetConsoleFont(string fontName = "Comic Sans MS")
		{
			unsafe
			{
				IntPtr hnd = GetStdHandle(-11);
				IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);
				if (hnd != INVALID_HANDLE_VALUE)
				{
					// Set console font to Comic Sans MS
					CONSOLE_FONT_INFO_EX newInfo = new CONSOLE_FONT_INFO_EX();
					newInfo.cbSize = (uint)Marshal.SizeOf(newInfo);
					newInfo.FontFamily = 4;
					IntPtr ptr = new IntPtr(newInfo.FaceName);
					Marshal.Copy(fontName.ToCharArray(), 0, ptr, fontName.Length);

					// Get some settings from current font.
					newInfo.dwFontSize = new COORD(20, 20);
					newInfo.FontWeight = 14;
					SetCurrentConsoleFontEx(hnd, false, ref newInfo);
				}
			}
		}
	}
}
