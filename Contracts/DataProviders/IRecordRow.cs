﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lwork.Contracts.DataProviders
{
	public interface IRecordRow
	{
		DateTime Time { get; }

		bool Status { get; }

		bool Edge { get; }
	}
}
