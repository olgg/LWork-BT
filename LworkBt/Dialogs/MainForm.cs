using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lwork.Contracts.DataLoggers;
using Lwork.Core.Calculators;
using Lwork.XmlData.DataLoggers;
using Lwork.XmlData.DataProviders;

namespace LworkBt
{
	public partial class MainForm : Form
	{
		private const string DEVICE_NAME = "iPhone (Oleg)";
		
		private BtDiscover discover;
		private bool init = true;
		private bool exit = false;
		private IDataLogger logger = new XmlFileLogger();
		private CurrentTimeCalculator timeCalculator;

		public MainForm()
		{
			InitializeComponent();

			SetCaptions();
			notifyIcon.Icon = Properties.Resources.Find11;
			notifyIcon.Text = "Инициализация...";

			
			TryRestoreCalculator();
			discover = new BtDiscover(DEVICE_NAME, AddLine);
			worker.RunWorkerAsync();
		}

		private void TryRestoreCalculator()
		{
			SystemClock clock = new SystemClock();
			StatefullDayCalculator saved = new StatefullDayCalculator(DateTime.Now, new XmlDayDataProvider(), clock);
			if (saved.GetState().Ready)
			{
				timeCalculator = new CurrentTimeCalculator(clock, clock, saved);
				ShowTimes();
			}
			else
				timeCalculator = new CurrentTimeCalculator(clock, clock);
		}

		private void SetCaptions()
		{
			timeInfo.SetUpperText("Начало работы");
			timeInfo.SetMediumText("Окончание работы");
			timeInfo.SetLowerText("Время отсутствия");
		}

		private void MainForm_Resize(object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Minimized)
			{
				notifyIcon.Visible = true;
				this.ShowInTaskbar = false;
			}
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			if (!exit)
			{
				e.Cancel = true;
				this.WindowState = FormWindowState.Minimized;
			}
		}

		private void MainForm_Shown(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}

		private void AddLine(string text)
		{
			if (InvokeRequired)
			{
				Invoke(new Action<string>(AddLine), text);
			}
			else
			{
				List<string> lines = new List<string>();
				lines.Add(text);
				lines.AddRange(txtLog.Lines);
				txtLog.Lines = lines.ToArray();
			}
		}

		private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (init)
			{
				init = false;
				if (discover.Ready)
				{					
					worker.DoWork -= worker_DoInitWork;
					worker.DoWork += worker_DoDiscoverWork;
					timer.Start();
				}
			}
			else if (discover.Ready)
				UpdateDeviceStatus();
		}

		private void UpdateDeviceStatus()
		{
			timeCalculator.UpdateStatus(discover.InRange);
			SaveData();

			if (timeCalculator.Edge)
				NotifyTray();

			ShowTimes();
		}

		private void ShowTimes()
		{
			var state = timeCalculator.GetState();
			if (state.Ready)
				UpdateTimeTables();
			else
				ResetTimes();
		}

		private void UpdateTimeTables()
		{
			var worktime = timeCalculator.GetWorktime();

			dayTimeTable.SetUpperTime(worktime.Elapsed);
			dayTimeTable.SetMediumTime(worktime.Left);
			dayTimeTable.SetLowerTime(worktime.Overtime);	

			timeInfo.SetUpperTime(worktime.Begin.TimeOfDay);
			timeInfo.SetMediumTime(worktime.End.TimeOfDay);
			timeInfo.SetLowerTime(worktime.Absent);

			notifyIcon.Text = string.Format("Отработано: {0:hh\\:mm}\nОсталось: {1:hh\\:mm}", worktime.Elapsed, worktime.Left);
			Icon icon = timeCalculator.Status ? Properties.Resources.accept : Properties.Resources.Error16;
			notifyIcon.Icon = icon;
		}

		private void ResetTimes()
		{
			dayTimeTable.Reset();
			timeInfo.Reset();
			notifyIcon.Text = "Поиск устройства...";
		}

		private void SaveData()
		{
			DeviceStatus deviceStatus = DeviceStatus.NotFound;
			if (discover.Ready)
			{
				deviceStatus = timeCalculator.Status ? DeviceStatus.InRange : DeviceStatus.NotFound;
				logger.Add(deviceStatus, DateTime.Now, timeCalculator.Edge);
			}	
		}

		private void NotifyTray()
		{
			string message;

			if (timeCalculator.Status)
				message = string.Format("Устройство обнаружено в {0}", DateTime.Now);
			else
				message = string.Format("Устройство НЕ обнаружено в {0}", DateTime.Now);

			notifyIcon.BalloonTipTitle = "Изменилось состояние";
			notifyIcon.BalloonTipText = message;
						
			notifyIcon.ShowBalloonTip(100);

			AddLine(message);
		}

		private void worker_DoDiscoverWork(object sender, DoWorkEventArgs e)
		{
			discover.Search();
		}

		private void worker_DoInitWork(object sender, DoWorkEventArgs e)
		{
			discover.InitDevice();
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			if (!worker.IsBusy)
				worker.RunWorkerAsync();
			else
				timer.Start();
		}

		private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ShowForm();
			}
		}

		private void ShowForm()
		{
			WindowState = FormWindowState.Normal;
			notifyIcon.Visible = false;
			this.ShowInTaskbar = true;
		}

		private void menuItemOpen_Click(object sender, EventArgs e)
		{
			ShowForm();
		}

		private void menuItemExit_Click(object sender, EventArgs e)
		{
			exit = true;
			Close();
		}

		private void menuItemShowMonth_Click(object sender, EventArgs e)
		{
			//using (MonthReportDialog mrd = new MonthReportDialog())
			//{
			//	mrd.ShowDialog();
			//}
		}
	}
}
