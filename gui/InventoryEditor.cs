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
				await Program.db.UpdateItemById((int)dataGridView1.Rows[e.RowIndex].Cells[0].Value, (string)dataGridView1.Rows[e.RowIndex].Cells[1].Value, (string)dataGridView1.Rows[e.RowIndex].Cells[2].Value);
				await UpdateList();
			};

			dataGridView1.UserDeletingRow += async (o, e) => {
				await Program.db.DeleteItemById((int) dataGridView1.Rows[e.Row.Index].Cells[0].Value);
				await UpdateList();
			};

			dataGridView1.UserAddedRow += async (o, e) => {
				int id = await Program.db.CreateEmptyItem();
				dataGridView1.Rows[(e.Row.Index - 1)].Cells[0].Value = id;
			};


			Load += async (e, a) => {
				DrawingControl.SuspendDrawing(this);
				server = new(async request => {
					SetLog(request.content);
					if(dataGridView1.SelectedCells.Count == 1 && dataGridView1.SelectedCells[0].ColumnIndex == 2) {
						DataGridViewCell cell = dataGridView1.SelectedCells[0];
						if (cell != null) {
							SetCell(cell.RowIndex, cell.ColumnIndex, request.content);
							await Program.db.UpdateItemById((int)dataGridView1.Rows[cell.RowIndex].Cells[0].Value, (string)dataGridView1.Rows[cell.RowIndex].Cells[1].Value, (string)dataGridView1.Rows[cell.RowIndex].Cells[2].Value);
						}
					}
				});
				DrawingControl.ResumeDrawing(this);
				await UpdateList();
			};

			FormClosing += (s, e) => {
				if (!expectedExit) {
					expectedExit = true;
					ManagerWindow.Exit();
				}
			};
		}

		public async Task UpdateList() { 
			DrawingControl.SuspendDrawing(this);
			dataGridView1.Rows.Clear();
			foreach (var item in await Program.db.ListItem()) {
				dataGridView1.Rows.Add(item.Id, item.Name, item.Code);
			}

			DrawingControl.ResumeDrawing(this);
		}

		public void SetLog(string msg) {
			if (textBox1.InvokeRequired) {
				// Call this same method but append THREAD2 to the text
				void safeWrite() { SetLog(msg); }
				textBox1.Invoke(safeWrite);
			} else textBox1.Text = msg;
		}

		public void SetCell(int row, int col, string msg) {
			if (dataGridView1.InvokeRequired) {
				// Call this same method but append THREAD2 to the text
				void safeWrite() { SetCell(row,col,msg); }
				dataGridView1.Invoke(safeWrite);
			} else dataGridView1.Rows[row].Cells[col].Value = msg;
		}

		private async void AddNewItemButton_Click(object sender, EventArgs e) {

		}
	}
}
