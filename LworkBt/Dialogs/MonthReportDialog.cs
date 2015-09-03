using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lwork.Contracts.Calculators;

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
