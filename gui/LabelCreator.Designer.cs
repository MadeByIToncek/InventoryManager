namespace InventoryManager.gui {
	partial class LabelCreator {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
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
			print = new Button();
			labelNO = new NumericUpDown();
			ToBePrinted = new Label();
			tableLayoutPanel1 = new TableLayoutPanel();
			panel2 = new Panel();
			panel1 = new Panel();
			label1 = new Label();
			offsetNO = new NumericUpDown();
			((System.ComponentModel.ISupportInitialize)labelNO).BeginInit();
			tableLayoutPanel1.SuspendLayout();
			panel2.SuspendLayout();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)offsetNO).BeginInit();
			SuspendLayout();
			// 
			// print
			// 
			print.Dock = DockStyle.Right;
			print.Font = new Font("Segoe UI", 14F);
			print.Location = new Point(324, 0);
			print.Name = "print";
			print.Size = new Size(218, 125);
			print.TabIndex = 0;
			print.Text = "PRINT!";
			print.UseVisualStyleBackColor = true;
			print.Click += print_Click;
			// 
			// labelNO
			// 
			labelNO.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
			labelNO.Location = new Point(105, 14);
			labelNO.Maximum = new decimal(new int[] { 52, 0, 0, 0 });
			labelNO.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			labelNO.Name = "labelNO";
			labelNO.Size = new Size(211, 31);
			labelNO.TabIndex = 1;
			labelNO.Value = new decimal(new int[] { 52, 0, 0, 0 });
			// 
			// ToBePrinted
			// 
			ToBePrinted.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			ToBePrinted.AutoSize = true;
			ToBePrinted.Location = new Point(9, 16);
			ToBePrinted.Name = "ToBePrinted";
			ToBePrinted.Size = new Size(95, 25);
			ToBePrinted.TabIndex = 2;
			ToBePrinted.Text = "# of labels";
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 1;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel1.Controls.Add(panel2, 0, 0);
			tableLayoutPanel1.Controls.Add(panel1, 0, 1);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 2;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
			tableLayoutPanel1.Size = new Size(324, 125);
			tableLayoutPanel1.TabIndex = 3;
			// 
			// panel2
			// 
			panel2.Controls.Add(ToBePrinted);
			panel2.Controls.Add(labelNO);
			panel2.Dock = DockStyle.Fill;
			panel2.Location = new Point(3, 3);
			panel2.Name = "panel2";
			panel2.Size = new Size(318, 56);
			panel2.TabIndex = 0;
			// 
			// panel1
			// 
			panel1.Controls.Add(label1);
			panel1.Controls.Add(offsetNO);
			panel1.Dock = DockStyle.Fill;
			panel1.Location = new Point(3, 65);
			panel1.Name = "panel1";
			panel1.Size = new Size(318, 57);
			panel1.TabIndex = 1;
			// 
			// label1
			// 
			label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			label1.AutoSize = true;
			label1.Location = new Point(9, 17);
			label1.Name = "label1";
			label1.Size = new Size(74, 25);
			label1.TabIndex = 4;
			label1.Text = "offset #";
			// 
			// offsetNO
			// 
			offsetNO.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			offsetNO.Location = new Point(89, 17);
			offsetNO.Maximum = new decimal(new int[] { 51, 0, 0, 0 });
			offsetNO.Name = "offsetNO";
			offsetNO.Size = new Size(226, 31);
			offsetNO.TabIndex = 3;
			// 
			// LabelCreator
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(542, 125);
			Controls.Add(tableLayoutPanel1);
			Controls.Add(print);
			FormBorderStyle = FormBorderStyle.Fixed3D;
			MaximumSize = new Size(568, 185);
			MinimumSize = new Size(568, 185);
			Name = "LabelCreator";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "LabelCreator";
			((System.ComponentModel.ISupportInitialize)labelNO).EndInit();
			tableLayoutPanel1.ResumeLayout(false);
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)offsetNO).EndInit();
			ResumeLayout(false);
		}

		#endregion
		private Button print;
		private NumericUpDown labelNO;
		private Label ToBePrinted;
		private TableLayoutPanel tableLayoutPanel1;
		private Panel panel2;
		private Panel panel1;
		private Label label1;
		private NumericUpDown offsetNO;
	}
}