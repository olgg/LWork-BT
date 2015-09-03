using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lwork.Contracts.Calculators;
using Lwork.Contracts.DataProviders;
using Lwork.Contracts.Output;
using Lwork.Core.Output;

namespace Lwork.Core.Calculators
{
	public class ClosedDayCalculator : DayCalculatorBase, IClosedDayCalculator
	{
		private IRecordRow[] records;
		private DateTime day;
		private IDayDataProvider dataProvider;

		public ClosedDayCalculator(IDayDataProvider dataProvider, IDayWorktimeProvider worktimeProvider)
			: base(worktimeProvider)
		{
			this.dataProvider = dataProvider;
		}

		public IClosedDayWorktime GetWorktime(DateTime day)
		{
			if (this.day.Date != day.Date)
			{
				this.day = day;
				this.records = null;
			}

			Calculate();
			var result = WrapResult();

			return result;
		}

		private IClosedDayWorktime WrapResult()
		{
			ClosedDayWorktime result = new ClosedDayWorktime()
			{
				Absent = this.absent,
				Begin = this.begin,
				Date = this.day,
				Elapsed = this.elapsed,
				End = this.end,
				Left = this.left,
				Overtime = this.overtime
			};
			return result;
		}

		protected override IEnumerable<IRecordRow> Records
		{
			get 
			{
				if (records == null)
				{
					records = dataProvider.GetDayRecords(day).ToArray();
				}
				return records;
			}
		}

		private class ClosedDayWorktime : WorkTimeInfo, IClosedDayWorktime
		{
			public DateTime Date { get; set; }
		}
	}
}
