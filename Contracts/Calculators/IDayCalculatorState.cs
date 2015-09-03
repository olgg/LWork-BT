using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lwork.Contracts.Calculators
{
	/// <summary>
	/// Последныее состояние дневного калькулятора (для восстановления из хранилища)
	/// </summary>
	public interface IDayCalculatorState
	{
		/// <summary>
		/// Есть ли валидные данные для расчета
		/// </summary>
		bool Ready { get; }

		/// <summary>
		/// Состояние метки присутствия
		/// </summary>
		bool DeviceStatus { get; }

		/// <summary>
		/// Последнее время когда изменилось состояние метки присутствия
		/// </summary>
		DateTime Last { get; }
	}
}
