﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTC.Models.JF17.HARMHTS
{
	public class HTSSystem
	{
		public int[] ManualEmitters { get; set; }
		public bool ManualEmittersToBeUpdated { get; set; }
		public bool[] EnabledClasses { get; set; }
		public bool ManualTableEnabledToBeUpdated { get; set; }

		public bool ManualTableEnabled;
		public bool EnableUpload { get; set; }

		public HTSSystem()
		{
			ManualEmitters = new int[0];
			EnabledClasses = new bool[11];
			for (var i = 0; i < EnabledClasses.Length; i++)
			{
				EnabledClasses[i] = true;
			}
		}
	}
}
