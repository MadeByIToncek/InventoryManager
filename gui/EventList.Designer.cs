namespace InventoryManager.gui {
	partial class EventList {
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			tableLayoutPanel1 = new TableLayoutPanel();
			dataGridView1 = new DataGridView();
			panel1 = new Panel();
			ModifyInventoryButton = new Button();
			CreateButton = new Button();
			tableLayoutPanel2 = new TableLayoutPanel();
			button1 = new Button();
			eventID = new DataGridViewTextBoxColumn();
			eventName = new DataGridViewTextBoxColumn();
			eventDate = new DataGridViewTextBoxColumn();
			itemNo = new DataGridViewTextBoxColumn();
			edit = new DataGridViewButtonColumn();
			delete = new DataGridViewButtonColumn();
			checkin = new DataGridViewButtonColumn();
			checkout = new DataGridViewButtonColumn();
			tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			panel1.SuspendLayout();
			tableLayoutPanel2.SuspendLayout();
			SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
			tableLayoutPanel1.Controls.Add(dataGridView1, 0, 0);
			tableLayoutPanel1.Controls.Add(panel1, 0, 1);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 2;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
			tableLayoutPanel1.Size = new Size(825, 459);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// dataGridView1
			// 
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.AllowUserToDeleteRows = false;
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Columns.AddRange(new DataGridViewColumn[] { eventID, eventName, eventDate, itemNo, edit, delete, checkin, checkout });
			dataGridView1.Dock = DockStyle.Fill;
			dataGridView1.Location = new Point(3, 3);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.ReadOnly = true;
			dataGridView1.RowHeadersWidth = 62;
			dataGridView1.Size = new Size(819, 393);
			dataGridView1.TabIndex = 0;
			dataGridView1.CellContentClick += dataGridView1_CellContentClick;
			// 
			// panel1
			// 
			panel1.AutoSize = true;
			panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			panel1.Controls.Add(ModifyInventoryButton);
			panel1.Controls.Add(CreateButton);
			panel1.Dock = DockStyle.Right;
			panel1.Location = new Point(450, 402);
			panel1.Name = "panel1";
			panel1.Size = new Size(372, 54);
			panel1.TabIndex = 1;
			// 
			// ModifyInventoryButton
			// 
			ModifyInventoryButton.AutoSize = true;
			ModifyInventoryButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			ModifyInventoryButton.Dock = DockStyle.Right;
			ModifyInventoryButton.Location = new Point(0, 0);
			ModifyInventoryButton.Name = "ModifyInventoryButton";
			ModifyInventoryButton.Size = new Size(231, 54);
			ModifyInventoryButton.TabIndex = 1;
			ModifyInventoryButton.Text = "Modify avaliable inventory";
			ModifyInventoryButton.UseVisualStyleBackColor = true;
			ModifyInventoryButton.Click += ModifyInventoryButton_Click;
			// 
			// CreateButton
			// 
			CreateButton.AutoSize = true;
			CreateButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			CreateButton.Dock = DockStyle.Right;
			CreateButton.Location = new Point(231, 0);
			CreateButton.Name = "CreateButton";
			CreateButton.Size = new Size(141, 54);
			CreateButton.TabIndex = 0;
			CreateButton.Text = "Add new event";
			CreateButton.UseVisualStyleBackColor = true;
			CreateButton.Click += CreateButton_Click;
			// 
			// tableLayoutPanel2
			// 
			tableLayoutPanel2.ColumnCount = 1;
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tableLayoutPanel2.Controls.Add(button1, 0, 1);
			tableLayoutPanel2.Dock = DockStyle.Fill;
			tableLayoutPanel2.Location = new Point(0, 0);
			tableLayoutPanel2.Name = "tableLayoutPanel2";
			tableLayoutPanel2.RowCount = 2;
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
			tableLayoutPanel2.Size = new Size(1025, 450);
			tableLayoutPanel2.TabIndex = 2;
			// 
			// button1
			// 
			button1.AutoSize = true;
			button1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			button1.Dock = DockStyle.Right;
			button1.Location = new Point(881, 393);
			button1.Name = "button1";
			button1.Size = new Size(141, 54);
			button1.TabIndex = 1;
			button1.Text = "Add new event";
			button1.UseVisualStyleBackColor = true;
			// 
			// eventID
			// 
			eventID.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			eventID.HeaderText = "ID";
			eventID.MinimumWidth = 8;
			eventID.Name = "eventID";
			eventID.ReadOnly = true;
			eventID.Width = 66;
			// 
			// eventName
			// 
			eventName.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			eventName.HeaderText = "Event Name";
			eventName.MinimumWidth = 8;
			eventName.Name = "eventName";
			eventName.ReadOnly = true;
			eventName.Width = 143;
			// 
			// eventDate
			// 
			eventDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			eventDate.HeaderText = "Date";
			eventDate.MinimumWidth = 8;
			eventDate.Name = "eventDate";
			eventDate.ReadOnly = true;
			eventDate.Width = 85;
			// 
			// itemNo
			// 
			itemNo.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			itemNo.HeaderText = "# of items";
			itemNo.MinimumWidth = 8;
			itemNo.Name = "itemNo";
			itemNo.ReadOnly = true;
			itemNo.Width = 129;
			// 
			// edit
			// 
			edit.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
			edit.HeaderText = "Edit";
			edit.MinimumWidth = 8;
			edit.Name = "edit";
			edit.ReadOnly = true;
			edit.Text = "📝";
			edit.UseColumnTextForButtonValue = true;
			edit.Width = 48;
			// 
			// delete
			// 
			delete.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
			delete.HeaderText = "Delete";
			delete.MinimumWidth = 8;
			delete.Name = "delete";
			delete.ReadOnly = true;
			delete.Text = "❌";
			delete.UseColumnTextForButtonValue = true;
			delete.Width = 68;
			// 
			// checkin
			// 
			checkin.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
			checkin.HeaderText = "Check-in";
			checkin.MinimumWidth = 8;
			checkin.Name = "checkin";
			checkin.ReadOnly = true;
			checkin.Text = "⏩✔";
			checkin.UseColumnTextForButtonValue = true;
			checkin.Width = 86;
			// 
			// checkout
			// 
			checkout.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
			checkout.HeaderText = "Check-out";
			checkout.MinimumWidth = 8;
			checkout.Name = "checkout";
			checkout.ReadOnly = true;
			checkout.Text = "⏪\U0001f6d1";
			checkout.UseColumnTextForButtonValue = true;
			checkout.Width = 99;
			// 
			// EventList
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(825, 459);
			Controls.Add(tableLayoutPanel1);
			Name = "EventList";
			StartPosition = FormStartPosition.CenterParent;
			Text = "InventoryManager";
			TopMost = true;
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			tableLayoutPanel2.ResumeLayout(false);
			tableLayoutPanel2.PerformLayout();
			ResumeLayout(false);
		}

		#endregion
		private TableLayoutPanel tableLayoutPanel1;
		private TableLayoutPanel tableLayoutPanel2;
		private Button button1;
		private DataGridView dataGridView1;
		private Panel panel1;
		private Button ModifyInventoryButton;
		private Button CreateButton;
		private DataGridViewTextBoxColumn eventID;
		private DataGridViewTextBoxColumn eventName;
		private DataGridViewTextBoxColumn eventDate;
		private DataGridViewTextBoxColumn itemNo;
		private DataGridViewButtonColumn edit;
		private DataGridViewButtonColumn delete;
		private DataGridViewButtonColumn checkin;
		private DataGridViewButtonColumn checkout;
	}
}
