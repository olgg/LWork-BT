namespace LworkBt
{
	partial class MonthReportDialog
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
			this.gridViewMonthReport = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.gridViewMonthReport)).BeginInit();
			this.SuspendLayout();
			// 
			// gridViewMonthReport
			// 
			this.gridViewMonthReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridViewMonthReport.Dock = System.Windows.Forms.DockStyle.Top;
			this.gridViewMonthReport.Location = new System.Drawing.Point(0, 0);
			this.gridViewMonthReport.Name = "gridViewMonthReport";
			this.gridViewMonthReport.Size = new System.Drawing.Size(881, 424);
			this.gridViewMonthReport.TabIndex = 0;
			// 
			// MonthReportDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(881, 507);
			this.Controls.Add(this.gridViewMonthReport);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "MonthReportDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MonthReportDialog";
			((System.ComponentModel.ISupportInitialize)(this.gridViewMonthReport)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView gridViewMonthReport;
	}
}