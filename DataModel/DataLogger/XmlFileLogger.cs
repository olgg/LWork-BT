using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataModel
{
	public class XmlFileLogger : IDataLogger
	{
		public const string XML_NAME = "Register";
		public const string XML_DATE_TIME = "DateTime";
		public const string XML_STATUS = "DeviceStatus";
		public const string XML_EDGE = "Edge";

		private string userRootDir;

		public void Add(DeviceStatus status, DateTime dateTime, bool edge)
		{
			XDocument file = CheckOrOpenDataFile();
			XElement xmlData = CreateRow(status, dateTime, edge);
			file.Root.Add(xmlData);

			string fullFilePath = GetFullFilename(dateTime);
			file.Save(fullFilePath);
		}

		public string GetFullFilename(DateTime dateTime)
		{
			string filename = ComposeDataFilename(dateTime);
			string fullFilePath = String.Format("{0}/{1}", UserRootDir, filename);
			return fullFilePath;
		}

		public string UserRootDir
		{
			get
			{
				if (string.IsNullOrEmpty(userRootDir))
					userRootDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/LWork/Data";
				return userRootDir;
			}
		}

		public string GetFilename(DateTime date)
		{
			string result = string.Empty;
			string filename = GetFullFilename(DateTime.Today);
			if (File.Exists(filename))
				result = filename;
			return result;
		}

		private XDocument CheckOrOpenDataFile()
		{		
			if (!Directory.Exists(UserRootDir))
			{
				Directory.CreateDirectory(UserRootDir);
			}

			string fullFilePath = GetFullFilename(DateTime.Today);
			XDocument doc;
			if (!File.Exists(fullFilePath))
			{
				doc = new XDocument();
				doc.Add(new XElement("Data", new XAttribute("created", DateTime.Now)));
				doc.Save(fullFilePath);
			}
			else
			{
				doc = XDocument.Load(fullFilePath);
			}
			return doc;
		}

		private XElement CreateRow(DeviceStatus status, DateTime dateTime, bool edge)
		{
			XElement result = new XElement(XML_NAME,
				new XAttribute(XML_DATE_TIME, dateTime),
				new XAttribute(XML_STATUS, status),
				new XAttribute(XML_EDGE, edge));
			
			return result;
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
	}
}
