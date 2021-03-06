﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lwork.Contracts.Calculators;

namespace Lwork.Core.Calculators
{
	public class TimeCalculatorState : IDayCalculatorState
	{
		public bool Ready { get; set; }
		public bool DeviceStatus { get; set; }
		public DateTime Last { get; set; }

		public static TimeCalculatorState NotReady
		{
			get { return new TimeCalculatorState() {Ready = false }; }
		}
	}
}
