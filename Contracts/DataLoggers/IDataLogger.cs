using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lwork.Contracts.DataLoggers
{
	public interface IDataLogger
	{
		void Add(DeviceStatus status, DateTime dateTime, bool edge);
	}
}
