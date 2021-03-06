﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Lwork.Contracts.Calculators;
using Lwork.Contracts.DataProviders;
using Lwork.Contracts.Output;
using Lwork.Core.Output;

namespace Lwork.Core.Calculators
{
	public class StatefullDayCalculator : DayCalculatorBase, IStatefullDayCalculator
	{
		private readonly DateTime day;
		private readonly IDayDataProvider dataProvider;

		public StatefullDayCalculator(DateTime day, IDayDataProvider dataProvider, IDayWorktimeProvider worktimeProvider)
			: base(worktimeProvider)
		{
			this.day = day;
			this.dataProvider = dataProvider;
		}

		protected override IEnumerable<IRecordRow> Records
		{
			get { return dataProvider.GetDayRecords(day); }
		}

		#region Реализация IDayCalculator

		public IDayWorktime GetWorktime()
		{
			Calculate();

			WorkTimeInfo result = new WorkTimeInfo()
			{
				Absent = absent,
				Begin = begin,
				Elapsed = elapsed,
				End = end,
				Left = left,
				Overtime = overtime
			};

			return result;
		}

		#endregion

		#region Реализация IStatefullDayCalculator
		
		public IDayCalculatorState GetState()
		{
			if (Records.Any())
			{
				IRecordRow info = Records.Last();
				TimeCalculatorState result = new TimeCalculatorState()
				{
					DeviceStatus = info.Status,
					Last = info.Time,
					Ready = Records.Count() > 1
				};
				return result;
			}
			else
				return TimeCalculatorState.NotReady;
		}

		#endregion
	}
}
