using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing.Aztec;

namespace InventoryManager.gui {
	public partial class LabelCreator : Form {
		bool expectedExit = false;

		public LabelCreator() {
			InitializeComponent();

			FormClosing += (s, e) => {
				if (!expectedExit) {
					expectedExit = true;
					ManagerWindow.SwitchToWindow(new EventList(), this);
				}
			};
		}

		private void print_Click(object sender, EventArgs e) {
			Hide();
			PrintDialog pdialog = new PrintDialog();
			pdialog.ShowDialog();
			PrintDocument pd = new PrintDocument();
			pd.PrinterSettings = pdialog.PrinterSettings;
			pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
			pd.Print();
			Close();
		}

		// The PrintPage event is raised for each page to be printed.
		private void pd_PrintPage(object sender, PrintPageEventArgs ev) {
			Graphics? g = ev.Graphics;
			AztecWriter aw = new AztecWriter();

			//DrawHorizontalLine(ev, 1.05f / 29.7f);
			//DrawHorizontalLine(ev, 1 - (1.05f / 29.7f));

			//for (int i = 0; i < 13; i++) {
			//	DrawHorizontalLine(ev, (1.05f + (2.12f * i)) / 29.7f);
			//}
			//for (int i = 0; i < 3; i++) {
			//	DrawVerticalLine(ev, ((21 / 4.0f) * (i + 1)) / 21);
			//}

			for (int i = ((int)offsetNO.Value); i < ((int)(labelNO.Value + offsetNO.Value)); i++) {
				string val = Guid.NewGuid().ToString();
				ZXing.Common.BitMatrix matrix = ZXing.Aztec.Internal.Encoder.encode(val).Matrix;

				int row = (int)(Math.Floor(i / 4d));
				int column = i % 4;
				float xRatioOffset = (column * 5.25f / 21f) + .25f / 21f - .25f/21f;
				float yRatioOffset = (row * 2.122f / 29.7f) + 1.2f / 29.7f;
				float xRatioSize = 70f / ev.PageBounds.Width;
				float yRatioSize = 70f / ev.PageBounds.Height;

				float xstep = xRatioSize / matrix.Width;
				float ystep = yRatioSize / matrix.Height;
				g.DrawString("IToncek", new Font("VCR OSD Mono", 16), Brushes.Black, new PointF((xRatioOffset + (2.1f / 21f)) * ev.PageBounds.Width, (yRatioOffset + (.5f / 29.7f)) * ev.PageBounds.Height));
				g.DrawString("+420773277452", new Font("VCR OSD Mono", 8), Brushes.Black, new PointF((xRatioOffset + (2.1f / 21f)) * ev.PageBounds.Width, (yRatioOffset + (1.2f / 29.7f)) * ev.PageBounds.Height));

				for (int x = 0; x < matrix.Width; x++) {
					for (int y = 0; y < matrix.Height; y++) {
						if (matrix[x, y]) DrawRect(ev, xRatioOffset + (xstep * x), yRatioOffset + (ystep * y), xstep, ystep);
					}
				}

			}
		}

		private void DrawIrlRect(PrintPageEventArgs ev, float x1, float y1, float x2, float y2) {
			ev.Graphics.FillRectangle(Brushes.Black, new RectangleF((x1 * ev.PageBounds.Width), (y1 * ev.PageBounds.Height), ((x2 - x1) * ev.PageBounds.Width), ((y2 - y1) * ev.PageBounds.Height)));
		}

		private void DrawRect(PrintPageEventArgs ev, float x, float y, float w, float h) {
			ev.Graphics.FillRectangle(Brushes.Black, new RectangleF((x * ev.PageBounds.Width), (y * ev.PageBounds.Height), w * ev.PageBounds.Width, h * ev.PageBounds.Height));
		}
		private void ClearRect(PrintPageEventArgs ev, float x, float y, float w, float h) {
			ev.Graphics.FillRectangle(Brushes.White, new RectangleF((x * ev.PageBounds.Width), (y * ev.PageBounds.Height), w * ev.PageBounds.Width, h * ev.PageBounds.Height));
		}

		private void DrawHorizontalLine(PrintPageEventArgs ev, float height) {
			ev.Graphics.FillRectangle(Brushes.Black, new RectangleF(0, (height * ev.PageBounds.Height), ev.PageBounds.Width, 1));
		}

		private void DrawVerticalLine(PrintPageEventArgs ev, float width) {
			ev.Graphics.FillRectangle(Brushes.Black, new RectangleF((width * ev.PageBounds.Width), ((1.05f / 29.7f) * ev.PageBounds.Height), 1, ev.PageBounds.Height - ((1.1f / 29.7f) * ev.PageBounds.Height)));
		}
	}
}
