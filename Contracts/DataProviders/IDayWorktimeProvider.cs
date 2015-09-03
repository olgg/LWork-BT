using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lwork.Contracts.DataProviders
{
	public interface IDayWorktimeProvider
	{
		/// <summary>
		/// Продолжительность рабочего дня
		/// </summary>
		TimeSpan GetDayWorktime(DateTime date);
	}
}
