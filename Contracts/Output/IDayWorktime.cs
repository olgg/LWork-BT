using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lwork.Contracts.Output
{
	/// <summary>
	/// Рабочее время по итогам дня
	/// </summary>
	public interface IDayWorktime : IWorktime
	{
		/// <summary>
		/// Время отсутствия в течении рабочего дня
		/// </summary>
		TimeSpan Absent { get; }

		/// <summary>
		/// Время начала работы
		/// </summary>
		DateTime Begin { get; }

		/// <summary>
		/// Расчетное время окончания работы
		/// </summary>
		DateTime End { get; }
	}
}
