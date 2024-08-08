using InventoryManager.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManager.gui {
	public partial class EventEditor : Form {
		Event @event;
		bool expectedExit = false;
		public EventEditor(int eventID) {
			InitializeComponent();
			Load += async (e, a) => {
				DrawingControl.SuspendDrawing(this);
				@event = await Program.db.GetEventById(eventID);
				name.Text = @event.Name;
				dateTimePicker1.Value = (@event.Date == 0 ? DateOnly.FromDateTime(DateTime.Now) : DateOnly.FromDayNumber(@event.Date)).ToDateTime(TimeOnly.MinValue);
				DrawingControl.ResumeDrawing(this);
			};

			FormClosing += (s, e) => {
				if (!expectedExit) {
					expectedExit = true;
					ManagerWindow.Exit();
				}
			};
		}

		private async void ModifyButton_Click(object sender, EventArgs e) {
			@event.Name = name.Text;
			@event.Date = DateOnly.FromDateTime(dateTimePicker1.Value).DayNumber;
			await Program.db.SaveOrUpdateEvent(@event);

			expectedExit = true;
			ManagerWindow.SwitchToWindow(new EventList(), this);
		}
	}
}
