using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Output;

namespace Contracts.Calculators
{
	public interface IDayCalculator
	{
		IDayWorktime GetWorktime();
	}
}
