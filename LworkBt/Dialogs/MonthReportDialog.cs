using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Contracts.Calculators;
using DataModel;

namespace LworkBt
{
	public partial class MonthReportDialog : Form
	{
		public MonthReportDialog(IMonthCalculator calculator)
		{
			InitializeComponent();
		}
	}
}
