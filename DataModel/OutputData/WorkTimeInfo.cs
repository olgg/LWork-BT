﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lwork.Contracts.Output;

namespace Lwork.Core.Output
{
	/// <summary>
	/// Информация о рабочем времени
	/// </summary>
	public class WorkTimeInfo : IDayWorktime
	{
		/// <summary>
		/// Отработано времени за день
		/// </summary>
		public TimeSpan Elapsed { get; set; }

		/// <summary>
		/// Осталось отработать до конца рабочего дня
		/// </summary>
		public TimeSpan Left { get; set; }

		/// <summary>
		/// Время отсутствия в течении рабочего дня
		/// </summary>
		public TimeSpan Absent { get; set; }

		/// <summary>
		/// Переработка сегодня
		/// </summary>
		public TimeSpan Overtime { get; set; }

		/// <summary>
		/// Время начала работы
		/// </summary>
		public DateTime Begin { get; set; }

		/// <summary>
		/// Расчетное время окончания работы
		/// </summary>
		public DateTime End { get; set; }
	}
}
