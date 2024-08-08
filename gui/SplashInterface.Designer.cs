namespace InventoryManager {
    partial class SplashInterface
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
		private void InitializeComponent() {
			label1 = new Label();
			ver = new Label();
			logDisplay = new Label();
			pictureBox2 = new PictureBox();
			label2 = new Label();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Stolzl Bold", 35.9999962F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.ForeColor = Color.White;
			label1.Location = new Point(12, 24);
			label1.Name = "label1";
			label1.Size = new Size(724, 86);
			label1.TabIndex = 0;
			label1.Text = "InventoryManager";
			// 
			// ver
			// 
			ver.AutoSize = true;
			ver.Font = new Font("Stolzl", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
			ver.ForeColor = Color.White;
			ver.Location = new Point(35, 110);
			ver.Name = "ver";
			ver.Size = new Size(120, 22);
			ver.TabIndex = 2;
			ver.Text = "Version: null";
			// 
			// logDisplay
			// 
			logDisplay.AutoSize = true;
			logDisplay.ForeColor = Color.White;
			logDisplay.Location = new Point(35, 210);
			logDisplay.Name = "logDisplay";
			logDisplay.Size = new Size(206, 25);
			logDisplay.TabIndex = 3;
			logDisplay.Text = "[SYSTEM] Splash created";
			// 
			// pictureBox2
			// 
			pictureBox2.Image = Properties.Resources.profilovka;
			pictureBox2.Location = new Point(35, 135);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new Size(26, 25);
			pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
			pictureBox2.TabIndex = 7;
			pictureBox2.TabStop = false;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.ForeColor = Color.White;
			label2.Location = new Point(67, 135);
			label2.Name = "label2";
			label2.Size = new Size(145, 25);
			label2.TabIndex = 6;
			label2.Text = "#madebyitoncek";
			// 
			// SplashInterface
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.Black;
			ClientSize = new Size(744, 290);
			Controls.Add(pictureBox2);
			Controls.Add(label2);
			Controls.Add(logDisplay);
			Controls.Add(ver);
			Controls.Add(label1);
			FormBorderStyle = FormBorderStyle.None;
			Name = "SplashInterface";
			ShowInTaskbar = false;
			StartPosition = FormStartPosition.CenterParent;
			Text = "Splash";
			TopMost = true;
			TransparencyKey = Color.Red;
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
        private Label ver;
        private Label logDisplay;
        private PictureBox pictureBox2;
        private Label label2;
    }
}