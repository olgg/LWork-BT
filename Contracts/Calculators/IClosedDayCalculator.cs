using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Output;

namespace Contracts.Calculators
{
	/// <summary>
	/// Калькулятор для расчета рабочего времени по завершенному дню
	/// </summary>
	public interface IClosedDayCalculator
	{
		/// <summary>
		/// Получить рабочее время за день
		/// </summary>
		/// <param name="day">Дата, на которую запрашиваются данные</param>
		/// <returns>Расчитанное рабочее время</returns>
		IClosedDayWorktime GetWorktime(DateTime day);
	}
}
