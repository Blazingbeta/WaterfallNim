﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfNim
{
	class Program
	{
		static void Main(string[] args)
		{
            //Play nim
            NimController.SetUpInstance();
            NimController.Instance.RunNim();
		}
	}
}
