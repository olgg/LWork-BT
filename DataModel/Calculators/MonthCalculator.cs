using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lwork.Contracts.Calculators;
using Lwork.Contracts.DataProviders;
using Lwork.Contracts.Output;

namespace Lwork.Core.Calculators
{
	public class MonthCalculator : IMonthCalculator
	{
		private readonly DateTime date;
		private readonly IDayWorktimeProvider worktimeProvider;
		private readonly ClosedDayCalculator dayCalculator;

		private TimeSpan totalHours = TimeSpan.Zero;
		private Dictionary<DateTime, IClosedDayWorktime> dayDetails;
		private Dictionary<DateTime, TimeSpan> dayWorktimes;


		public MonthCalculator(DateTime date, IDayDataProvider dataProvider, IDayWorktimeProvider worktimeProvider)
		{
			this.date = date;
			dayCalculator = new ClosedDayCalculator(dataProvider, worktimeProvider);
			InitDaysList();
		}

		private void InitDaysList()
		{
			dayWorktimes = new Dictionary<DateTime, TimeSpan>();
			int days = DateTime.DaysInMonth(date.Year, date.Month);
			DateTime today = DateTime.Now;

			if (date.Year == today.Year && date.Month == today.Month)
			{
				days = today.Day;
			}
			else if (today < date)
				return;

			for (int i = 1; i <= days; i++)
			{
				TimeSpan dayWorktime = GetDayWorktime(i);
				DateTime currentDate = new DateTime(date.Year, date.Month, i);
				dayWorktimes.Add(currentDate, dayWorktime);
				totalHours = totalHours + dayWorktime;
			}
		}

		private TimeSpan GetDayWorktime(int day)
		{
			DateTime current = new DateTime(date.Year, date.Month, day);
			if (current.DayOfWeek == DayOfWeek.Saturday || current.DayOfWeek == DayOfWeek.Sunday)
				return TimeSpan.Zero;
			else
				return new TimeSpan(8, 0, 0);
		}

		#region Реализация IMonthCalculator...

		public IWorktime GetWorktime()
		{
			var dayDetails = GetDayDetails();
			TimeSpan elapsed = TimeSpan.Zero;

			foreach (var dayDetail in dayDetails)
				elapsed = elapsed + dayDetail.Elapsed;

			TimeSpan left = TimeSpan.Zero;
			TimeSpan overtime = TimeSpan.Zero;

			if (elapsed >= totalHours)
				overtime = elapsed - totalHours;
			else
				left = totalHours - elapsed;

			return new MonthWorktime() { Elapsed = elapsed, Left = left, Overtime = overtime };
		}

		public IEnumerable<IClosedDayWorktime> GetDayDetails()
		{
			if (dayDetails == null)
			{
				dayDetails = new Dictionary<DateTime, IClosedDayWorktime>();
				foreach (var dayWorktime in dayWorktimes)
				{
					IClosedDayWorktime worktime = dayCalculator.GetWorktime(dayWorktime.Key);
					dayDetails.Add(dayWorktime.Key, worktime);
				}
			}
			return dayDetails.Values;
		}

		#endregion

		private class MonthWorktime : IWorktime
		{
			public TimeSpan Elapsed	{ get; set;	}

			public TimeSpan Left { get; set; }

			public TimeSpan Overtime { get;	set; }
		}
	}
}
