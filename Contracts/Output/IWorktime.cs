using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lwork.Contracts.Output
{
	/// <summary>
	/// Данное по отработанному времени за некоторый период
	/// </summary>
	public interface IWorktime
	{
		/// <summary>
		/// Отработано времени
		/// </summary>
		TimeSpan Elapsed { get; }

		/// <summary>
		/// Осталось отработать
		/// </summary>
		TimeSpan Left { get; }

		/// <summary>
		/// Переработка
		/// </summary>
		TimeSpan Overtime { get; }
	}
}
