using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lwork.Contracts.Calculators;
using Lwork.Contracts.Clocks;
using Lwork.Contracts.DataProviders;
using Lwork.Contracts.Output;
using Lwork.Core.Output;

namespace Lwork.Core.Calculators
{
	public class CurrentTimeCalculator : IStatefullDayCalculator
	{
		private DateTime previosTime;
		private DateTime current;

		private readonly IClock clock;
		private readonly IDayWorktimeProvider dayWorktime;

		private bool oldStatus = false;
		private bool status = false;
		private WorkTimeInfo timeInfo;
		private TimeCalculatorState state;

		private TimeSpan elapsed;
		private TimeSpan left;
		private TimeSpan absent;
		private TimeSpan overtime;
		private DateTime begin;
		private DateTime end;

		public CurrentTimeCalculator(IClock clock, IDayWorktimeProvider dayWorktime)
		{
			this.clock = clock;
			this.dayWorktime = dayWorktime;

			this.timeInfo = new WorkTimeInfo();
			this.state = new TimeCalculatorState();
		}

		public CurrentTimeCalculator(IClock clock, IDayWorktimeProvider dayWorktime, IStatefullDayCalculator timeCalculator)
		{
			this.clock = clock;
			this.dayWorktime = dayWorktime;

			LoadTimeInfo(timeCalculator.GetWorktime());
			LoadState(timeCalculator.GetState());

			Edge = false;
		}

		#region Реализация ITimeCalculator

		public IDayWorktime GetWorktime()
		{
			timeInfo.Elapsed = elapsed;
			timeInfo.Left = left;
			timeInfo.Absent = absent;
			timeInfo.Overtime = overtime;
			timeInfo.Begin = begin;
			timeInfo.End = end;

			return timeInfo;
		}

		public IDayCalculatorState GetState()
		{
			return state;
		}

		#endregion 

		private TimeSpan TodayWorktime
		{
			get { return dayWorktime.GetDayWorktime(clock.GetTime()); }
		}

		private void LoadTimeInfo(IDayWorktime worktime)
		{
			timeInfo = new WorkTimeInfo()
			{
				Absent = worktime.Absent,
				Begin = worktime.Begin,
				Elapsed = worktime.Elapsed,
				End = worktime.End,
				Left = worktime.Left,
				Overtime = worktime.Overtime
			};

			elapsed = timeInfo.Elapsed;
			left = timeInfo.Left;
			absent = timeInfo.Absent;
			overtime = timeInfo.Overtime;
			begin = timeInfo.Begin;
			end = begin + TodayWorktime + absent;	
		}

		private void LoadState(IDayCalculatorState calculatorState)
		{
			state = new TimeCalculatorState()
			{
				DeviceStatus = calculatorState.DeviceStatus,
				Last = calculatorState.Last,
				Ready = calculatorState.Ready
			};

			previosTime = state.Last;
			current = previosTime;
			oldStatus = state.DeviceStatus;
			status = oldStatus;
		}

		public bool Status
		{
			get { return status; }
		}

		public bool Edge { get; private set; }

		public void UpdateStatus(bool status)
		{
			this.status = status;
			Calculate();
		}

		private void Calculate()
		{
			ResetWorktimeIfNeed();
			if (state.Ready)
			{
				CalculateWorktime();
				CalculateAndShowTimes();
			}

			Edge = (oldStatus != status);
			oldStatus = status;
		}

		private void ResetWorktimeIfNeed()
		{
			DateTime time = clock.GetTime();
			if (current.Day != time.Day)
			{
				if (status)
				{
					elapsed = TimeSpan.Zero;
					absent = TimeSpan.Zero;
					previosTime = time;
					current = time;
					begin = time;
					state.Ready = true;
				}
				else
					state.Ready = false;
			}
		}

		private void CalculateWorktime()
		{
			current = clock.GetTime();

			if (status)
			{
				TimeSpan delta = current - previosTime;
				if (!oldStatus)
					delta = TimeSpan.Zero;

				elapsed += delta;

				if (!oldStatus && elapsed != TimeSpan.Zero)
				{
					delta = current - previosTime;
					absent += delta;
				}
			}
			else
			{
				if (oldStatus)
				{
					TimeSpan delta = current - previosTime;
					elapsed += delta;
				}

				if (elapsed != TimeSpan.Zero)
				{
					TimeSpan delta = current - previosTime;
					if (oldStatus)
						delta = TimeSpan.Zero;
					absent += delta;
				}
			}

			previosTime = current;
		}

		private void CalculateAndShowTimes()
		{
			left = TimeSpan.Zero;
			if (elapsed < TodayWorktime)
			{
				left = TodayWorktime - elapsed;
				if (elapsed > TimeSpan.Zero)
					left += new TimeSpan(0, 1, 0);
			}

			overtime = TimeSpan.Zero;
			if (elapsed >= TodayWorktime)
				overtime = elapsed - TodayWorktime;

			end = begin + TodayWorktime + absent;
		}
	}

	public class SystemClock : IClock, IDayWorktimeProvider
	{
		public DateTime GetTime()
		{
			return DateTime.Now;
		}

		public TimeSpan GetDayWorktime(DateTime date)
		{
			return new TimeSpan(8, 0, 0);
		}
	}
}
