using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
	/// <summary>
	/// Калькулятор для подсчета рабочего времени за месяц
	/// </summary>
	public interface IMonthCalculator
	{
		/// <summary>
		/// Получить рабочее время в течении месяца
		/// </summary>
		/// <returns>Рабочее время</returns>
		IWorktime GetWorktime();

		/// <summary>
		/// Получить данные по дням
		/// </summary>
		/// <returns>Набор данных за день</returns>
		IEnumerable<IClosedDayWorktime> GetDayDetails();
	}
}
