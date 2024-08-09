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
using System.Xml.Linq;

namespace InventoryManager.gui {
	public partial class InventoryEditor : Form {
		bool expectedExit = false;
		ScannerServer? server;
		public InventoryEditor() {
			InitializeComponent();

			dataGridView1.CellEndEdit += async (o, e) => {
				try {
					await Program.db.UpdateItemById((int)dataGridView1.Rows[e.RowIndex].Cells[0].Value, (string)dataGridView1.Rows[e.RowIndex].Cells[1].Value, Guid.Parse((string)dataGridView1.Rows[e.RowIndex].Cells[2].Value));
					await UpdateList();
				} catch (Exception) {
				}
			};

			dataGridView1.UserDeletingRow += async (o, e) => {
				try {
					await Program.db.DeleteItemById((int)dataGridView1.Rows[e.Row.Index].Cells[0].Value);
					await UpdateList();
				} catch (Exception) {
				}
			};

			dataGridView1.UserAddedRow += async (o, e) => {
				try {
					int id = await Program.db.CreateEmptyItem();
					dataGridView1.Rows[(e.Row.Index - 1)].Cells[0].Value = id;
				} catch (Exception) {
				}
			};


			Shown += async (e, a) => {
				await UpdateList();
				Enabled = false;
				server = new(async request => {
					SetLog(request.content);
					if (dataGridView1.SelectedCells.Count == 1 && dataGridView1.SelectedCells[0].ColumnIndex == 2) {
						DataGridViewCell cell = dataGridView1.SelectedCells[0];
						if (cell != null) {
							SetCell(cell.RowIndex, cell.ColumnIndex, request.content);
							await Program.db.UpdateItemById((int)dataGridView1.Rows[cell.RowIndex].Cells[0].Value, (string)dataGridView1.Rows[cell.RowIndex].Cells[1].Value, Guid.Parse((string)dataGridView1.Rows[cell.RowIndex].Cells[2].Value));
							await UpdateListSafe();
						}
					}
				});
				Enabled = true;
			};

			FormClosing += (s, e) => {
				server?.close();
				if (!expectedExit) {
					expectedExit = true;
					ManagerWindow.SwitchToWindow(new EventList(), this);
				}
			};
		}

		public async Task UpdateListSafe() {
			if (dataGridView1.InvokeRequired) {
				await dataGridView1.Invoke(UpdateList);
			} else await UpdateList();
		}

		public async Task UpdateList() {
			Enabled = false;
			dataGridView1.Rows.Clear();
			foreach (var item in await Program.db.ListItem()) {
				dataGridView1.Rows.Add(item.Id, item.Name, item.Code);
			}
			Enabled = true;
		}

		public void SetLog(string msg) {
			if (textBox1.InvokeRequired) {
				void safeWrite() { SetLog(msg); }
				textBox1.Invoke(safeWrite);
			} else textBox1.Text = msg;
		}

		public void SetCell(int row, int col, string msg) {
			if (dataGridView1.InvokeRequired) {
				void safeWrite() { SetCell(row, col, msg); }
				dataGridView1.Invoke(safeWrite);
			} else dataGridView1.Rows[row].Cells[col].Value = msg;
		}
	}
}
