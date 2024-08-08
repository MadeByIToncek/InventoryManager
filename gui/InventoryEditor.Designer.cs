namespace InventoryManager.gui {
	partial class InventoryEditor {
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
			textBox1 = new TextBox();
			groupBox1 = new GroupBox();
			dataGridView1 = new DataGridView();
			ItemEdit = new DataGridViewButtonColumn();
			ItemDelete = new DataGridViewButtonColumn();
			panel1 = new Panel();
			AddNewItemButton = new Button();
			ItemID = new DataGridViewTextBoxColumn();
			ItemName = new DataGridViewTextBoxColumn();
			ItemCode = new DataGridViewTextBoxColumn();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			panel1.SuspendLayout();
			SuspendLayout();
			// 
			// textBox1
			// 
			textBox1.Dock = DockStyle.Fill;
			textBox1.Location = new Point(3, 27);
			textBox1.Multiline = true;
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(669, 54);
			textBox1.TabIndex = 0;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(textBox1);
			groupBox1.Dock = DockStyle.Bottom;
			groupBox1.Location = new Point(0, 940);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(675, 84);
			groupBox1.TabIndex = 1;
			groupBox1.TabStop = false;
			groupBox1.Text = "Last UUID received";
			// 
			// dataGridView1
			// 
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ItemID, ItemName, ItemCode });
			dataGridView1.Dock = DockStyle.Fill;
			dataGridView1.Location = new Point(0, 0);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.RowHeadersWidth = 62;
			dataGridView1.Size = new Size(675, 940);
			dataGridView1.TabIndex = 2;
			// 
			// ItemEdit
			// 
			ItemEdit.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
			ItemEdit.HeaderText = "Edit";
			ItemEdit.MinimumWidth = 8;
			ItemEdit.Name = "ItemEdit";
			ItemEdit.Text = "📝";
			ItemEdit.UseColumnTextForButtonValue = true;
			ItemEdit.Width = 150;
			// 
			// ItemDelete
			// 
			ItemDelete.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
			ItemDelete.HeaderText = "Del";
			ItemDelete.MinimumWidth = 8;
			ItemDelete.Name = "ItemDelete";
			ItemDelete.Text = "♻";
			ItemDelete.UseColumnTextForButtonValue = true;
			ItemDelete.Width = 150;
			// 
			// panel1
			// 
			panel1.Controls.Add(AddNewItemButton);
			panel1.Dock = DockStyle.Bottom;
			panel1.Location = new Point(0, 879);
			panel1.Name = "panel1";
			panel1.Size = new Size(675, 61);
			panel1.TabIndex = 3;
			// 
			// AddNewItemButton
			// 
			AddNewItemButton.AutoSize = true;
			AddNewItemButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			AddNewItemButton.Dock = DockStyle.Left;
			AddNewItemButton.Location = new Point(0, 0);
			AddNewItemButton.Name = "AddNewItemButton";
			AddNewItemButton.Size = new Size(133, 61);
			AddNewItemButton.TabIndex = 0;
			AddNewItemButton.Text = "Add new item";
			AddNewItemButton.UseVisualStyleBackColor = true;
			AddNewItemButton.Click += AddNewItemButton_Click;
			// 
			// ItemID
			// 
			ItemID.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			ItemID.HeaderText = "ID";
			ItemID.MinimumWidth = 8;
			ItemID.Name = "ItemID";
			ItemID.ReadOnly = true;
			ItemID.Width = 66;
			// 
			// ItemName
			// 
			ItemName.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			ItemName.HeaderText = "Name";
			ItemName.MinimumWidth = 8;
			ItemName.Name = "ItemName";
			ItemName.Width = 95;
			// 
			// ItemCode
			// 
			ItemCode.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			ItemCode.HeaderText = "UUID";
			ItemCode.MinimumWidth = 8;
			ItemCode.Name = "ItemCode";
			ItemCode.Width = 90;
			// 
			// InventoryEditor
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(675, 1024);
			Controls.Add(panel1);
			Controls.Add(dataGridView1);
			Controls.Add(groupBox1);
			Name = "InventoryEditor";
			Text = "InventoryEditor";
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private TextBox textBox1;
		private GroupBox groupBox1;
		private DataGridView dataGridView1;
		private Panel panel1;
		private Button AddNewItemButton;
		private DataGridViewButtonColumn ItemEdit;
		private DataGridViewButtonColumn ItemDelete;
		private DataGridViewTextBoxColumn ItemID;
		private DataGridViewTextBoxColumn ItemName;
		private DataGridViewTextBoxColumn ItemCode;
	}
}