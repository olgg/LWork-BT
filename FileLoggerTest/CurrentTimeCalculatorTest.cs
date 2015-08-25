using System;
using DataModel;
using LworkBt;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileLoggerTest
{
	[TestClass]
	public class CurrentTimeCalculatorTest
	{
		private CurrentTimeCalculatorTest.CkockMoq clock = new CkockMoq();

		[TestMethod]
		public void WorkBeginTest()
		{
			var instance = GetInstance();
			var state = instance.GetState();
			
			DateTime start = new DateTime(2000, 06, 02, 9, 28, 0);
			clock.SetTime(start);
			instance.UpdateStatus(false);
			Assert.IsFalse(state.Ready);

			DateTime begin = new DateTime(2000, 06, 02, 9, 30, 0);
			clock.SetTime(begin);

			instance.UpdateStatus(true);
			Assert.IsTrue(state.Ready);
			var worktime = instance.GetWorktime();
			Assert.AreEqual<DateTime>(begin, worktime.Begin);
		}

		[TestMethod]
		public void ElapsedTest()
		{
			var instance = GetInstance();

			DateTime begin = new DateTime(2000, 06, 02, 9, 30, 0);			
			clock.SetTime(begin);
			instance.UpdateStatus(false);
			
			TimeSpan delta1 = new TimeSpan(0, 1, 0);
			begin += delta1;
			clock.SetTime(begin);
			instance.UpdateStatus(true);

			TimeSpan delta2 = new TimeSpan(1, 30, 0);
			begin += delta2;
			clock.SetTime(begin);
			instance.UpdateStatus(false);

			var worktime = instance.GetWorktime();
			Assert.AreEqual<TimeSpan>(delta2, worktime.Elapsed);
		}

		[TestMethod]
		public void AbsentTest()
		{
			var instance = GetInstance();

			DateTime begin = new DateTime(2000, 06, 02, 9, 30, 0);
			clock.SetTime(begin);
			instance.UpdateStatus(false);

			TimeSpan delta1 = new TimeSpan(0, 1, 0);
			begin += delta1;
			clock.SetTime(begin);
			instance.UpdateStatus(true);

			TimeSpan delta2 = new TimeSpan(1, 30, 0);
			begin += delta2;
			clock.SetTime(begin);
			instance.UpdateStatus(false);

			TimeSpan delta3 = new TimeSpan(0, 15, 0);
			begin += delta3;
			clock.SetTime(begin);
			instance.UpdateStatus(true);

			var worktime = instance.GetWorktime();
			Assert.AreEqual<TimeSpan>(delta3, worktime.Absent);
		}

		[TestMethod]
		public void WorkEndTest()
		{
			var instance = GetInstance();

			DateTime startWork = new DateTime(2000, 06, 02, 9, 30, 0);
			DateTime begin = startWork;
			clock.SetTime(begin);
			instance.UpdateStatus(true);

			TimeSpan delta1 = new TimeSpan(0, 1, 0);
			begin += delta1;
			clock.SetTime(begin);
			instance.UpdateStatus(true);

			TimeSpan delta2 = new TimeSpan(1, 30, 0);
			begin += delta2;
			clock.SetTime(begin);
			instance.UpdateStatus(false);

			TimeSpan delta3 = new TimeSpan(0, 15, 0);
			begin += delta3;
			clock.SetTime(begin);
			instance.UpdateStatus(true);

			var worktime = instance.GetWorktime();
			DateTime expectedEnd = startWork + WorkTimeInfo.DayWorkTime + delta3;
			Assert.AreEqual<DateTime>(expectedEnd, worktime.End);
		}

		[TestMethod]
		public void OvertimeTest()
		{
			var instance = GetInstance();

			DateTime startWork = new DateTime(2000, 06, 02, 9, 30, 0);
			DateTime begin = startWork;
			clock.SetTime(begin);
			instance.UpdateStatus(false);

			TimeSpan delta1 = new TimeSpan(0, 1, 0);
			begin += delta1;
			clock.SetTime(begin);
			instance.UpdateStatus(true);

			TimeSpan delta2 = new TimeSpan(1, 30, 0);
			begin += delta2;
			clock.SetTime(begin);
			instance.UpdateStatus(false);

			TimeSpan delta3 = new TimeSpan(0, 15, 0);
			begin += delta3;
			clock.SetTime(begin);
			instance.UpdateStatus(true);

			TimeSpan delta4 = new TimeSpan(6, 30, 0);
			begin += delta4;
			clock.SetTime(begin);
			instance.UpdateStatus(true);

			TimeSpan delta5 = new TimeSpan(0, 30, 0);
			begin += delta5;
			clock.SetTime(begin);
			instance.UpdateStatus(true);

			var worktime = instance.GetWorktime();
			Assert.AreEqual<TimeSpan>(delta5, worktime.Overtime);
		}

		private CurrentTimeCalculator GetInstance()
		{
			CurrentTimeCalculator instance = new CurrentTimeCalculator(clock);
			return instance;
		}

		private class CkockMoq : IClock
		{
			private DateTime currentTime;

			public void SetTime(DateTime time)
			{
				currentTime = time;
			}
			
			public DateTime GetTime()
			{
				return currentTime;
			}
		}
	}
}
