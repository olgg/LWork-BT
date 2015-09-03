using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lwork.Contracts.Clocks
{
	public interface IClock
	{
		DateTime GetTime();
	}
}
