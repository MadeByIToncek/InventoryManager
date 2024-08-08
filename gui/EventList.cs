namespace InventoryManager.gui
	{
	public partial class EventList : Form {
		bool expectedExit = false;
		public EventList() {
			InitializeComponent();

			Load += async (s, e) => {
				await UpdateEvents();
			};

			FormClosing += (s, e) => {
				if (!expectedExit) {
					expectedExit = true;
					ManagerWindow.Exit();
				}
			};
		}

		private async Task UpdateEvents() {
			DrawingControl.SuspendDrawing(this);
			dataGridView1.Rows.Clear();
			foreach (var @event in await Program.db.ListEvents()) {
				dataGridView1.Rows.Add(@event.Id, @event.Name, DateOnly.FromDayNumber(@event.Date).ToString(), @event.Items.Count);
			}
			DrawingControl.ResumeDrawing(this);
		}

		private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
			if (e.RowIndex >= 0) {
				int eventID = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
				switch (e.ColumnIndex) {
					case 4:
						expectedExit = true;
						ManagerWindow.SwitchToWindow(new EventEditor(eventID), this);
						break;
					case 5:
						DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this event?", "Event deletion", MessageBoxButtons.YesNo);
						if (dialogResult == DialogResult.Yes) {
							await Program.db.DeleteEventById(eventID);
							await UpdateEvents();
						}
						break;
					case 6:
						break;
					case 7:
						break;
					default:
						break;
				}
			}
		}

		private async void CreateButton_Click(object sender, EventArgs e) {
			await Program.db.CreateEmptyEvent();
			UpdateEvents();
		}

		private void ModifyInventoryButton_Click(object sender, EventArgs e) {
			expectedExit = true;
			ManagerWindow.SwitchToWindow(new InventoryEditor(), this);

		}

		private void button2_Click(object sender, EventArgs e) {
			ManagerWindow.SwitchToWindow(new LabelCreator(), this);
		}
	}
}
