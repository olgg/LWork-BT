using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using DataModel;
using LworkBt;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileLoggerTest
{
	
	[TestClass]
	public class FileLoggerTest
	{
		[TestMethod]
		public void CreateFileTest()
		{
			XmlFileLogger logger = new XmlFileLogger();

			string filename = logger.GetFullFilename(DateTime.Today);
			if (File.Exists(filename))
			{
				File.Delete(filename);
			}

			DateTime dateTime = DateTime.Now;
			bool edge = true;
			DeviceStatus status = DeviceStatus.InRange;

			logger.Add(status, dateTime, edge);
			Assert.IsTrue(File.Exists(filename));
		}

		[TestMethod]
		public void AddRecordTest()
		{
			XmlFileLogger logger = new XmlFileLogger();

			string filename = logger.GetFullFilename(DateTime.Today);
			if (File.Exists(filename))
			{
				File.Delete(filename);
			}

			DateTime dateTime = DateTime.Now;
			bool edge = false;
			DeviceStatus status = DeviceStatus.NotFound;

			logger.Add(status, dateTime, edge);

			dateTime = DateTime.Now + new TimeSpan(0, 1, 0);
			edge = true;
			status = DeviceStatus.InRange;

			logger.Add(status, dateTime, edge);

			XDocument file = XDocument.Load(filename);
			XElement root = file.Root;
			int rowCount = root.Elements("Register").Count();
			Assert.AreEqual<int>(2, rowCount);
		}
	}
}
