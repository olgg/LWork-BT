using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Lwork.Contracts.DataLoggers;
using Lwork.Contracts.DataProviders;

namespace Lwork.XmlData.DataLoggers
{
	public class XmlDayDataProvider : IDayDataProvider
	{
		private string userRootDir;
		private IRecordRow[] records;

		public IEnumerable<IRecordRow> GetDayRecords(DateTime day)
		{
			if (records == null)
			{
				string filename = GetFullFilename(day);
				if (!string.IsNullOrWhiteSpace(filename) && File.Exists(filename))
				{
					XDocument file = XDocument.Load(filename);
					var elements = file.Root.Elements(XmlFileLogger.XML_NAME);
					records = elements.Select(x => new XmlRecordRow(x)).ToArray();
				}
				else
				{
					records = new IRecordRow[0];
				}
			}
			return records;
		}

		private string GetFullFilename(DateTime dateTime)
		{
			string filename = ComposeDataFilename(dateTime);
			string fullFilePath = String.Format("{0}/{1}", UserRootDir, filename);
			return fullFilePath;
		}

		private string GetFilename(DateTime date)
		{
			string result = string.Empty;
			string filename = GetFullFilename(DateTime.Today);
			if (File.Exists(filename))
				result = filename;
			return result;
		}

		private string UserRootDir
		{
			get
			{
				if (string.IsNullOrEmpty(userRootDir))
					userRootDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/LWork/Data";
				return userRootDir;
			}
		}

		private string ComposeDataFilename(DateTime date)
		{
			StringBuilder sb = new StringBuilder();
#if DEBUG
			sb.Append("DEBUG_");
#endif
			sb.Append(string.Format("{0:D2}", date.Day)).Append(string.Format("{0:D2}", date.Month)).Append(date.Year.ToString().Substring(2));
			sb.Append(".xml");
			return sb.ToString();
		}

		private class XmlRecordRow : IRecordRow
		{
			public XmlRecordRow(XElement element)
			{
				Time = ParseDateTime(element);
				Status = ParseDeviceStatus(element);
				Edge = ParseEdge(element);
			}

			public DateTime Time { get; private set; }

			public bool Status { get; private set; }

			public bool Edge { get; private set; }

			private bool ParseEdge(XElement element)
			{
				string value = element.Attribute(XmlFileLogger.XML_EDGE).Value;
				bool edge = bool.Parse(value);
				return edge;
			}

			private static bool ParseDeviceStatus(XElement element)
			{
				string value = element.Attribute(XmlFileLogger.XML_STATUS).Value;
				DeviceStatus result = (DeviceStatus)Enum.Parse(typeof(DeviceStatus), value);
				return result == DeviceStatus.InRange;
			}

			private static DateTime ParseDateTime(XElement element)
			{
				string value = element.Attribute(XmlFileLogger.XML_DATE_TIME).Value;
				DateTime result = DateTime.Parse(value);
				return result;
			}
		}
	}
}
