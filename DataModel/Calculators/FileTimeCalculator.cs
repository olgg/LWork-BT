using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Lwork.Contracts.Calculators;
using Lwork.Output;

namespace DataModel
{
	public class FileTimeCalculator : DayCalculatorBase, IStatefullDayCalculator
	{
		private readonly DateTime day;
		private readonly IDayDataProvider dataProvider;

		public FileTimeCalculator(DateTime day)
		{
			this.day = day;
			this.dataProvider = new XmlDayDataProvider();
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
