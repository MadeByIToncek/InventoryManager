using InventoryManager.Entities;
using Microsoft.AspNetCore.Hosting.Server;
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
	public partial class CheckInterface : Form {
		private readonly bool isCheckIn;
		private bool expectedExit;
		private readonly int eventID;
		private ScannerServer server;

		public CheckInterface(bool isCheckIn, int eventID) {
			InitializeComponent();

			Shown += async (e, a) => {
				Enabled = false;
				server = new(async request => {
					try {
						await Program.db.ChangeUsedItemStateById(eventID, Guid.Parse(request.content), DetermineStateForChanging());
					} catch (Exception) {
						return await Task.FromResult(false);
					}
					await UpdateItemListSafe();
					return await Task.FromResult(true);
				});
				await CreateMissingUsedItems();
				await UpdateItemList();
				Enabled = true;
			};

			this.isCheckIn = isCheckIn;
			this.eventID = eventID;


			FormClosing += (s, e) => {
				server?.close();
				if (!expectedExit) {
					expectedExit = true;
					ManagerWindow.SwitchToWindow(new EventList(), this);
				}
			};
		}

		private async Task CreateMissingUsedItems() {
            foreach (var item in await Program.db.ListItem())
            {
				await Program.db.GetUsedItemByItemID(item.Id, eventID);
            }
        }

		private State DetermineStateForChanging() {
			if (isCheckIn) {
				if (AddItems.Checked) {
					return State.Registered;
				} else {
					return State.Unset;
				}
			} else {
				if (AddItems.Checked) {
					return State.CheckedOut;
				} else {
					return State.CheckedIn;
				} 
			}
		}

		public async Task UpdateItemListSafe() {
			if (dataGridView1.InvokeRequired) {
				await dataGridView1.Invoke(UpdateItemList);
			} else await UpdateItemList();
		}

		private async Task UpdateItemList() {
			dataGridView1.Rows.Clear();
			foreach (var item in await Program.db.ListUsedItemsForEvent(eventID)) {
				if (item.State == State.Unset) continue;
				int id = dataGridView1.Rows.Add(item.Item.Code, item.Item.Name, item.State);
				dataGridView1.Rows[id].DefaultCellStyle.BackColor = StateHelper.Background(item.State, isCheckIn);
				dataGridView1.Rows[id].DefaultCellStyle.ForeColor = StateHelper.Foreground(item.State);
			}
		}

		private void AddItems_CheckedChanged(object sender, EventArgs e) {
			if(AddItems.Checked) RemoveItems.Checked = false;
		}

		private void RemoveItems_CheckedChanged(object sender, EventArgs e) {
			if (RemoveItems.Checked) AddItems.Checked = false;
		}

		private async void Commit_Click(object sender, EventArgs e) {
			Enabled = false;
			foreach (UsedItem item in await Program.db.ListUsedItemsForEvent(eventID)) {
				if (item.State == State.Registered) {
					await Program.db.ChangeUsedItemStateById(eventID, item.Item.Code, State.CheckedIn);
				} else if (item.State == State.CheckedOut) {
					await Program.db.ChangeUsedItemStateById(eventID, item.Item.Code, State.Freed);
				}
			}
			expectedExit = true;
			ManagerWindow.SwitchToWindow(new EventList(),this);
		}
	}
}
