namespace LworkBt
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.popupShow = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabMain = new System.Windows.Forms.TabPage();
			this.timeInfo = new LworkBt.Controls.TimeTableControl();
			this.dayTimeTable = new LworkBt.Controls.TimeTableControl();
			this.tabRawData = new System.Windows.Forms.TabPage();
			this.txtLog = new System.Windows.Forms.TextBox();
			this.worker = new System.ComponentModel.BackgroundWorker();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.menuItemShowMonth = new System.Windows.Forms.ToolStripMenuItem();
			this.popupShow.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.tabMain.SuspendLayout();
			this.tabRawData.SuspendLayout();
			this.SuspendLayout();
			// 
			// notifyIcon
			// 
			this.notifyIcon.ContextMenuStrip = this.popupShow;
			this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
			this.notifyIcon.Text = "notifyIcon1";
			this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
			// 
			// popupShow
			// 
			this.popupShow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemOpen,
            this.menuItemShowMonth,
            this.toolStripSeparator1,
            this.menuItemExit});
			this.popupShow.Name = "popupShow";
			this.popupShow.ShowImageMargin = false;
			this.popupShow.Size = new System.Drawing.Size(133, 98);
			// 
			// menuItemOpen
			// 
			this.menuItemOpen.Name = "menuItemOpen";
			this.menuItemOpen.Size = new System.Drawing.Size(132, 22);
			this.menuItemOpen.Text = "Открыть";
			this.menuItemOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.menuItemOpen.Click += new System.EventHandler(this.menuItemOpen_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(129, 6);
			// 
			// menuItemExit
			// 
			this.menuItemExit.Name = "menuItemExit";
			this.menuItemExit.Size = new System.Drawing.Size(132, 22);
			this.menuItemExit.Text = "Выход";
			this.menuItemExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabMain);
			this.tabControl.Controls.Add(this.tabRawData);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(0, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(263, 220);
			this.tabControl.TabIndex = 0;
			// 
			// tabMain
			// 
			this.tabMain.BackColor = System.Drawing.SystemColors.Control;
			this.tabMain.Controls.Add(this.timeInfo);
			this.tabMain.Controls.Add(this.dayTimeTable);
			this.tabMain.Location = new System.Drawing.Point(4, 22);
			this.tabMain.Name = "tabMain";
			this.tabMain.Padding = new System.Windows.Forms.Padding(3);
			this.tabMain.Size = new System.Drawing.Size(255, 194);
			this.tabMain.TabIndex = 0;
			this.tabMain.Text = "Сегодня";
			// 
			// timeInfo
			// 
			this.timeInfo.Location = new System.Drawing.Point(135, 0);
			this.timeInfo.Name = "timeInfo";
			this.timeInfo.Size = new System.Drawing.Size(129, 194);
			this.timeInfo.TabIndex = 1;
			// 
			// dayTimeTable
			// 
			this.dayTimeTable.Location = new System.Drawing.Point(0, 0);
			this.dayTimeTable.Name = "dayTimeTable";
			this.dayTimeTable.Size = new System.Drawing.Size(129, 191);
			this.dayTimeTable.TabIndex = 0;
			// 
			// tabRawData
			// 
			this.tabRawData.Controls.Add(this.txtLog);
			this.tabRawData.Location = new System.Drawing.Point(4, 22);
			this.tabRawData.Name = "tabRawData";
			this.tabRawData.Padding = new System.Windows.Forms.Padding(3);
			this.tabRawData.Size = new System.Drawing.Size(255, 194);
			this.tabRawData.TabIndex = 1;
			this.tabRawData.Text = "Журнал";
			this.tabRawData.UseVisualStyleBackColor = true;
			// 
			// txtLog
			// 
			this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtLog.Location = new System.Drawing.Point(3, 3);
			this.txtLog.Multiline = true;
			this.txtLog.Name = "txtLog";
			this.txtLog.ReadOnly = true;
			this.txtLog.Size = new System.Drawing.Size(249, 188);
			this.txtLog.TabIndex = 0;
			// 
			// worker
			// 
			this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.worker_DoInitWork);
			this.worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
			// 
			// timer
			// 
			this.timer.Interval = 60000;
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// menuItemShowMonth
			// 
			this.menuItemShowMonth.Name = "menuItemShowMonth";
			this.menuItemShowMonth.Size = new System.Drawing.Size(132, 22);
			this.menuItemShowMonth.Text = "Отчет за месяц";
			this.menuItemShowMonth.Click += new System.EventHandler(this.menuItemShowMonth_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(263, 220);
			this.Controls.Add(this.tabControl);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Учет рабочего времени";
			this.Shown += new System.EventHandler(this.MainForm_Shown);
			this.Resize += new System.EventHandler(this.MainForm_Resize);
			this.popupShow.ResumeLayout(false);
			this.tabControl.ResumeLayout(false);
			this.tabMain.ResumeLayout(false);
			this.tabRawData.ResumeLayout(false);
			this.tabRawData.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.NotifyIcon notifyIcon;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabMain;
		private System.Windows.Forms.TabPage tabRawData;
		private System.Windows.Forms.TextBox txtLog;
		private System.ComponentModel.BackgroundWorker worker;
		private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.ContextMenuStrip popupShow;
		private System.Windows.Forms.ToolStripMenuItem menuItemOpen;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem menuItemExit;
		private Controls.TimeTableControl dayTimeTable;
		private Controls.TimeTableControl timeInfo;
		private System.Windows.Forms.ToolStripMenuItem menuItemShowMonth;
	}
}

