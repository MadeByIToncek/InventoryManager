namespace InventoryManager.gui {
	partial class CheckInterface {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckInterface));
			dataGridView1 = new DataGridView();
			UsedItemGUID = new DataGridViewTextBoxColumn();
			UsedItemName = new DataGridViewTextBoxColumn();
			UsedItemState = new DataGridViewTextBoxColumn();
			flowLayoutPanel1 = new FlowLayoutPanel();
			AddItems = new RadioButton();
			RemoveItems = new RadioButton();
			Commit = new Button();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			flowLayoutPanel1.SuspendLayout();
			SuspendLayout();
			// 
			// dataGridView1
			// 
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.AllowUserToDeleteRows = false;
			dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Columns.AddRange(new DataGridViewColumn[] { UsedItemGUID, UsedItemName, UsedItemState });
			dataGridView1.Dock = DockStyle.Fill;
			dataGridView1.Location = new Point(0, 0);
			dataGridView1.Margin = new Padding(20);
			dataGridView1.MultiSelect = false;
			dataGridView1.Name = "dataGridView1";
			dataGridView1.ReadOnly = true;
			dataGridView1.RowHeadersWidth = 62;
			dataGridView1.Size = new Size(914, 979);
			dataGridView1.TabIndex = 0;
			// 
			// UsedItemGUID
			// 
			UsedItemGUID.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			UsedItemGUID.HeaderText = "GUID";
			UsedItemGUID.MinimumWidth = 8;
			UsedItemGUID.Name = "UsedItemGUID";
			UsedItemGUID.ReadOnly = true;
			UsedItemGUID.Width = 90;
			// 
			// UsedItemName
			// 
			UsedItemName.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			UsedItemName.HeaderText = "Name";
			UsedItemName.MinimumWidth = 8;
			UsedItemName.Name = "UsedItemName";
			UsedItemName.ReadOnly = true;
			UsedItemName.Width = 95;
			// 
			// UsedItemState
			// 
			UsedItemState.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			UsedItemState.HeaderText = "State";
			UsedItemState.MinimumWidth = 8;
			UsedItemState.Name = "UsedItemState";
			UsedItemState.ReadOnly = true;
			UsedItemState.Width = 87;
			// 
			// flowLayoutPanel1
			// 
			flowLayoutPanel1.AutoSize = true;
			flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			flowLayoutPanel1.Controls.Add(AddItems);
			flowLayoutPanel1.Controls.Add(RemoveItems);
			flowLayoutPanel1.Controls.Add(Commit);
			flowLayoutPanel1.Dock = DockStyle.Bottom;
			flowLayoutPanel1.Location = new Point(0, 931);
			flowLayoutPanel1.Name = "flowLayoutPanel1";
			flowLayoutPanel1.Size = new Size(914, 48);
			flowLayoutPanel1.TabIndex = 1;
			// 
			// AddItems
			// 
			AddItems.AutoSize = true;
			AddItems.Checked = true;
			AddItems.Font = new Font("Segoe UI", 14F);
			AddItems.Location = new Point(3, 3);
			AddItems.Name = "AddItems";
			AddItems.Size = new Size(217, 42);
			AddItems.TabIndex = 0;
			AddItems.TabStop = true;
			AddItems.Text = "Register items";
			AddItems.UseVisualStyleBackColor = true;
			AddItems.CheckedChanged += AddItems_CheckedChanged;
			// 
			// RemoveItems
			// 
			RemoveItems.AutoSize = true;
			RemoveItems.Font = new Font("Segoe UI", 14F);
			RemoveItems.Location = new Point(226, 3);
			RemoveItems.Name = "RemoveItems";
			RemoveItems.Size = new Size(246, 42);
			RemoveItems.TabIndex = 1;
			RemoveItems.Text = "Unregister items";
			RemoveItems.UseVisualStyleBackColor = true;
			RemoveItems.CheckedChanged += RemoveItems_CheckedChanged;
			// 
			// Commit
			// 
			Commit.AutoSize = true;
			Commit.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			Commit.Font = new Font("Segoe UI", 12F);
			Commit.Location = new Point(478, 3);
			Commit.Name = "Commit";
			Commit.Size = new Size(109, 42);
			Commit.TabIndex = 2;
			Commit.Text = "Commit";
			Commit.UseVisualStyleBackColor = true;
			Commit.Click += Commit_Click;
			// 
			// CheckInterface
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(914, 979);
			Controls.Add(flowLayoutPanel1);
			Controls.Add(dataGridView1);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "CheckInterface";
			Text = "CheckInterface";
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			flowLayoutPanel1.ResumeLayout(false);
			flowLayoutPanel1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private DataGridView dataGridView1;
		private DataGridViewTextBoxColumn UsedItemGUID;
		private DataGridViewTextBoxColumn UsedItemName;
		private DataGridViewTextBoxColumn UsedItemState;
		private FlowLayoutPanel flowLayoutPanel1;
		private RadioButton AddItems;
		private RadioButton RemoveItems;
		private Button Commit;
	}
}