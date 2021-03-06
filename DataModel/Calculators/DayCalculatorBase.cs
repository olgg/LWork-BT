﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lwork.Contracts.DataProviders;
using Lwork.Core.Output;

namespace Lwork.Core.Calculators
{
	public abstract class DayCalculatorBase
	{
		protected readonly IDayWorktimeProvider worktimeData;

		protected TimeSpan elapsed;
		protected TimeSpan left;
		protected TimeSpan absent;
		protected TimeSpan overtime;
		protected DateTime begin;
		protected DateTime end;

		protected DayCalculatorBase(IDayWorktimeProvider worktimeData)
		{
			this.worktimeData = worktimeData;
		}

		protected abstract IEnumerable<IRecordRow> Records { get; }

		protected void Calculate()
		{
			CalculateIntervals();
			CalculateBegin();
			CalculateEnd();
			CalculateLeft();
			CalculateOvertime();
		}

		private void CalculateLeft()
		{
			TimeSpan worktime = GetWorktime();
			if (elapsed < worktime)
				left = worktime - elapsed;
			else
				left = TimeSpan.Zero;
		}

		private void CalculateOvertime()
		{
			TimeSpan worktime = GetWorktime();
			if (elapsed > worktime)
				overtime = elapsed - worktime;
			else
				overtime = TimeSpan.Zero;
		}

		private void CalculateIntervals()
		{
			IRecordRow[] infos = Records.Where(x => x.Edge).ToArray();

			elapsed = TimeSpan.Zero;
			absent = TimeSpan.Zero;

			if (infos.Length > 1)
			{
				for (int i = 1; i < infos.Length; i++)
				{
					bool status = infos[i - 1].Status;
					TimeSpan interval = infos[i].Time - infos[i - 1].Time;

					if (status)
						elapsed = elapsed + interval;
					else if (i > 1)
						absent = absent + interval;
				}

				IRecordRow last = Records.Last();
				if (last.Status)
				{
					IRecordRow lastEdged = infos.Last();
					elapsed = last.Time - lastEdged.Time + elapsed;
				}
			}
			else if (Records.Count() > 1)
			{
				IRecordRow first = Records.First();
				IRecordRow last = Records.Last();

				if (first.Status)
					elapsed = last.Time - first.Time;
			}
		}

		private void CalculateBegin()
		{
			var info = Records.FirstOrDefault(x => x.Status);
			if (info != null)
			{
				begin = info.Time;
			}
		}

		private void CalculateEnd()
		{
			var info = Records.LastOrDefault(x => x.Status);
			if (info != null)
			{
				end = info.Time;
			}
		}

		private TimeSpan GetWorktime()
		{
			TimeSpan result = TimeSpan.Zero;
			if (Records.Any())
			{
				DateTime day = Records.First().Time;
				result = worktimeData.GetDayWorktime(day);
			}
			return result;

		}
	}
}
