namespace InventoryManager.gui {
	partial class EventEditor {
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
			name = new TextBox();
			groupBox1 = new GroupBox();
			groupBox2 = new GroupBox();
			dateTimePicker1 = new DateTimePicker();
			ModifyButton = new Button();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			SuspendLayout();
			// 
			// name
			// 
			name.Dock = DockStyle.Fill;
			name.Font = new Font("Segoe UI", 13F);
			name.Location = new Point(3, 33);
			name.Name = "name";
			name.Size = new Size(585, 42);
			name.TabIndex = 0;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(name);
			groupBox1.Dock = DockStyle.Top;
			groupBox1.Font = new Font("Segoe UI", 11F);
			groupBox1.Location = new Point(0, 0);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(591, 85);
			groupBox1.TabIndex = 1;
			groupBox1.TabStop = false;
			groupBox1.Text = "Event name";
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(dateTimePicker1);
			groupBox2.Dock = DockStyle.Top;
			groupBox2.Font = new Font("Segoe UI", 11F);
			groupBox2.Location = new Point(0, 85);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(591, 84);
			groupBox2.TabIndex = 2;
			groupBox2.TabStop = false;
			groupBox2.Text = "Event date";
			// 
			// dateTimePicker1
			// 
			dateTimePicker1.Dock = DockStyle.Fill;
			dateTimePicker1.Location = new Point(3, 33);
			dateTimePicker1.Name = "dateTimePicker1";
			dateTimePicker1.Size = new Size(585, 37);
			dateTimePicker1.TabIndex = 0;
			// 
			// ModifyButton
			// 
			ModifyButton.AutoSize = true;
			ModifyButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			ModifyButton.Dock = DockStyle.Right;
			ModifyButton.Location = new Point(512, 169);
			ModifyButton.Margin = new Padding(8);
			ModifyButton.Name = "ModifyButton";
			ModifyButton.Size = new Size(79, 55);
			ModifyButton.TabIndex = 3;
			ModifyButton.Text = "Modify";
			ModifyButton.UseVisualStyleBackColor = true;
			ModifyButton.Click += ModifyButton_Click;
			// 
			// EventEditor
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(591, 224);
			Controls.Add(ModifyButton);
			Controls.Add(groupBox2);
			Controls.Add(groupBox1);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			MaximumSize = new Size(613, 280);
			MinimumSize = new Size(613, 280);
			Name = "EventEditor";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "EventEditor";
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			groupBox2.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox name;
		private GroupBox groupBox1;
		private GroupBox groupBox2;
		private DateTimePicker dateTimePicker1;
		private Button ModifyButton;
	}
}