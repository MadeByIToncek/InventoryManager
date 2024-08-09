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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryEditor));
			textBox1 = new TextBox();
			groupBox1 = new GroupBox();
			dataGridView1 = new DataGridView();
			ItemID = new DataGridViewTextBoxColumn();
			ItemName = new DataGridViewTextBoxColumn();
			ItemCode = new DataGridViewTextBoxColumn();
			ItemEdit = new DataGridViewButtonColumn();
			ItemDelete = new DataGridViewButtonColumn();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			SuspendLayout();
			// 
			// textBox1
			// 
			textBox1.Dock = DockStyle.Fill;
			textBox1.Enabled = false;
			textBox1.Location = new Point(3, 27);
			textBox1.Multiline = true;
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(735, 54);
			textBox1.TabIndex = 0;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(textBox1);
			groupBox1.Dock = DockStyle.Bottom;
			groupBox1.Location = new Point(0, 940);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(741, 84);
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
			dataGridView1.Size = new Size(741, 940);
			dataGridView1.TabIndex = 2;
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
			// InventoryEditor
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(741, 1024);
			Controls.Add(dataGridView1);
			Controls.Add(groupBox1);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "InventoryEditor";
			Text = "InventoryEditor";
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private TextBox textBox1;
		private GroupBox groupBox1;
		private DataGridView dataGridView1;
		private DataGridViewButtonColumn ItemEdit;
		private DataGridViewButtonColumn ItemDelete;
		private DataGridViewTextBoxColumn ItemID;
		private DataGridViewTextBoxColumn ItemName;
		private DataGridViewTextBoxColumn ItemCode;
	}
}