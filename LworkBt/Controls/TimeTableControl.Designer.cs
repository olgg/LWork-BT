namespace LworkBt.Controls
{
	partial class TimeTableControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblLowerCaption = new System.Windows.Forms.Label();
			this.lblMedium = new System.Windows.Forms.Label();
			this.lblMediumCaption = new System.Windows.Forms.Label();
			this.lblUpper = new System.Windows.Forms.Label();
			this.lblUpperCaption = new System.Windows.Forms.Label();
			this.lblLower = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblLowerCaption
			// 
			this.lblLowerCaption.AutoSize = true;
			this.lblLowerCaption.Location = new System.Drawing.Point(8, 134);
			this.lblLowerCaption.Name = "lblLowerCaption";
			this.lblLowerCaption.Size = new System.Drawing.Size(77, 13);
			this.lblLowerCaption.TabIndex = 9;
			this.lblLowerCaption.Text = "Переработка:";
			// 
			// lblMedium
			// 
			this.lblMedium.AutoSize = true;
			this.lblMedium.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblMedium.ForeColor = System.Drawing.Color.DarkRed;
			this.lblMedium.Location = new System.Drawing.Point(3, 82);
			this.lblMedium.Name = "lblMedium";
			this.lblMedium.Size = new System.Drawing.Size(88, 44);
			this.lblMedium.TabIndex = 8;
			this.lblMedium.Text = "--:--";
			// 
			// lblMediumCaption
			// 
			this.lblMediumCaption.AutoSize = true;
			this.lblMediumCaption.Location = new System.Drawing.Point(8, 69);
			this.lblMediumCaption.Name = "lblMediumCaption";
			this.lblMediumCaption.Size = new System.Drawing.Size(59, 13);
			this.lblMediumCaption.TabIndex = 7;
			this.lblMediumCaption.Text = "Осталось:";
			// 
			// lblUpper
			// 
			this.lblUpper.AutoSize = true;
			this.lblUpper.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblUpper.ForeColor = System.Drawing.Color.ForestGreen;
			this.lblUpper.Location = new System.Drawing.Point(3, 17);
			this.lblUpper.Name = "lblUpper";
			this.lblUpper.Size = new System.Drawing.Size(88, 44);
			this.lblUpper.TabIndex = 6;
			this.lblUpper.Text = "--:--";
			// 
			// lblUpperCaption
			// 
			this.lblUpperCaption.AutoSize = true;
			this.lblUpperCaption.Location = new System.Drawing.Point(8, 4);
			this.lblUpperCaption.Name = "lblUpperCaption";
			this.lblUpperCaption.Size = new System.Drawing.Size(70, 13);
			this.lblUpperCaption.TabIndex = 5;
			this.lblUpperCaption.Text = "Отработано:";
			// 
			// lblLower
			// 
			this.lblLower.AutoSize = true;
			this.lblLower.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblLower.ForeColor = System.Drawing.Color.DarkGray;
			this.lblLower.Location = new System.Drawing.Point(3, 147);
			this.lblLower.Name = "lblLower";
			this.lblLower.Size = new System.Drawing.Size(88, 44);
			this.lblLower.TabIndex = 10;
			this.lblLower.Text = "--:--";
			// 
			// TimeTableControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lblLower);
			this.Controls.Add(this.lblLowerCaption);
			this.Controls.Add(this.lblMedium);
			this.Controls.Add(this.lblMediumCaption);
			this.Controls.Add(this.lblUpper);
			this.Controls.Add(this.lblUpperCaption);
			this.Name = "TimeTableControl";
			this.Size = new System.Drawing.Size(129, 194);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblLowerCaption;
		private System.Windows.Forms.Label lblMedium;
		private System.Windows.Forms.Label lblMediumCaption;
		private System.Windows.Forms.Label lblUpper;
		private System.Windows.Forms.Label lblUpperCaption;
		private System.Windows.Forms.Label lblLower;
	}
}
