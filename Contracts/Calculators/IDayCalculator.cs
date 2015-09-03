﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lwork.Output;

namespace Lwork.Contracts.Calculators
{
	public interface IDayCalculator
	{
		IDayWorktime GetWorktime();
	}
}
