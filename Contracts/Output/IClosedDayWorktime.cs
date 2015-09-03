using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lwork.Contracts.Output
{
	/// <summary>
	/// Данные о рабочем времени по завершенному рабочему дню
	/// </summary>
	public interface IClosedDayWorktime : IDayWorktime
	{
		/// <summary>
		/// Дата, в которую были отработаны часы
		/// </summary>
		DateTime Date { get; }
	}
}
