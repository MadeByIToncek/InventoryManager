using System.Windows.Forms;

namespace InventoryManager.gui
	{
	public partial class EventList : Form {
		bool expectedExit = false;
		public EventList() {
			InitializeComponent();

			Shown += async (s, e) => {
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
			Enabled = false;
			dataGridView1.Rows.Clear();
			foreach (var @event in await Program.db.ListEvents()) {
				dataGridView1.Rows.Add(@event.Id, @event.Name, DateOnly.FromDayNumber(@event.Date).ToString(), @event.Items.Where(x => x.State == Entities.State.CheckedIn).Count());
			}
			Enabled = true;
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
						CheckIn(eventID);
						break;
					case 7:
						CheckOut(eventID);
						break;
					default:
						break;
				}
			}
		}

		private void CheckOut(int eventID) {
			expectedExit = true;
			ManagerWindow.SwitchToWindow(new CheckInterface(false, eventID), this);
		}

		private void CheckIn(int eventID) {
			expectedExit = true;
			ManagerWindow.SwitchToWindow(new CheckInterface(true, eventID),this);
		}

		private async void CreateButton_Click(object sender, EventArgs e) {
			await Program.db.CreateEmptyEvent();
			await UpdateEvents();
		}

		private void ModifyInventoryButton_Click(object sender, EventArgs e) {
			expectedExit = true;
			ManagerWindow.SwitchToWindow(new InventoryEditor(), this);

		}

		private void button2_Click(object sender, EventArgs e) {
			expectedExit = true;
			ManagerWindow.SwitchToWindow(new LabelCreator(), this);
		}

		private async void ImportDatabase_Click(object sender, EventArgs e) {
			OpenFileDialog dialog = new() {
				Filter = "Database files (*.db)|*.db",
				RestoreDirectory = true,
				CheckFileExists = true,
				CheckPathExists = true,
				ReadOnlyChecked = true
			};
			if (dialog.ShowDialog().Equals(DialogResult.OK)) {
				Enabled = false;
				await Program.db.Close();
				Program.db = null;
				File.Delete(await Program.GetDatabasePath());
				File.Copy(dialog.FileName, await Program.GetDatabasePath());
				Program.db = await Program.LoadDatabaseConfig();
				await UpdateEvents();
				Enabled = true;
			}
		}

		private async void ExportDatabase_Click(object sender, EventArgs e) {
			SaveFileDialog dialog = new() {
				AddExtension = true,
				DefaultExt = ".db",
				Filter = "Database files (*.db)|*.db",
				CheckPathExists = true,
				CheckWriteAccess = true,
				RestoreDirectory = true,
				AddToRecent = true,
				OverwritePrompt = true,
			};
            if (dialog.ShowDialog().Equals(DialogResult.OK)) {
				Enabled = false;
				await Program.db.Close();
				Program.db = null;
				if(File.Exists(dialog.FileName)) File.Delete(dialog.FileName);
				File.Copy(await Program.GetDatabasePath(), dialog.FileName);
				Program.db = await Program.LoadDatabaseConfig();
				await UpdateEvents();
				Enabled = true;
			};	
		}
	}
}
