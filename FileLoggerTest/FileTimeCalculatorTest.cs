using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileLoggerTest
{
	[TestClass]
	public class FileTimeCalculatorTest
	{
		private const string fullPathFormat = "{0}.Data.{1}";
		private const string filename = "FileCalculatorData.xml";

		[TestMethod]
		public void CalculateTest()
		{
			Assert.Inconclusive();

			//FileTimeCalculator instance = new FileTimeCalculator(stream);

			//IDayWorktime worktime = instance.GetWorktime();

			//DateTime expected = DateTime.Parse("2015-07-02T12:03:34.6744046+03:00");
			//Assert.AreEqual<DateTime>(expected, worktime.Begin);

			//expected = DateTime.Parse("2015-07-02T19:38:59.0080045+03:00");
			//Assert.AreEqual<DateTime>(expected, worktime.End);

			//TimeSpan total = worktime.End - worktime.Begin;
			//Assert.AreEqual<TimeSpan>(total, worktime.Absent + worktime.Elapsed);
		}

		private Stream GetDataFile()
		{
			string streamName = string.Format(fullPathFormat, GetType().Namespace, filename);
			return Assembly.GetExecutingAssembly().GetManifestResourceStream(streamName);
		}
	}
}
