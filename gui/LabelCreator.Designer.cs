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
			SuspendLayout();
			// 
			// print
			// 
			print.Location = new Point(196, 137);
			print.Name = "print";
			print.Size = new Size(410, 188);
			print.TabIndex = 0;
			print.Text = "PRINT!";
			print.UseVisualStyleBackColor = true;
			print.Click += print_Click;
			// 
			// LabelCreator
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(print);
			Name = "LabelCreator";
			Text = "LabelCreator";
			ResumeLayout(false);
		}

		#endregion
		private Button print;
	}
}