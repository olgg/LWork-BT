using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LworkBt.Controls
{
	public partial class TimeTableControl : UserControl
	{
		public TimeTableControl()
		{
			InitializeComponent();
		}

		public void SetUpperTime(TimeSpan time)
		{
			SetTime(time, lblUpper);
		}

		public void SetMediumTime(TimeSpan time)
		{
			SetTime(time, lblMedium);
		}

		public void SetLowerTime(TimeSpan time)
		{
			SetTime(time, lblLower);
		}

		private void SetTime(TimeSpan time, Label place)
		{
			place.Text = string.Format(@"{0:hh\:mm}", time);
		}

		public void Reset()
		{
			lblUpper.Text = "--:--";
			lblMedium.Text = "--:--";
			lblLower.Text = "--:--";
		}

		public void SetUpperText(string text)
		{
			lblUpperCaption.Text = text;
		}

		public void SetMediumText(string text)
		{
			lblMediumCaption.Text = text;
		}

		public void SetLowerText(string text)
		{
			lblLowerCaption.Text = text;
		}
	}
}
