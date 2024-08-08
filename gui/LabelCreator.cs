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

		private Font printFont;

		public LabelCreator() {
			InitializeComponent();
		}

		private void print_Click(object sender, EventArgs e) {
			//PrintDialog pdialog = new PrintDialog();
			//pdialog.ShowDialog();
			printFont = new Font("VCR OSD Mono", 12);
			PrintDocument pd = new PrintDocument();
			//pd.PrinterSettings = pdialog.PrinterSettings;
			pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
			pd.Print();

		}

		// The PrintPage event is raised for each page to be printed.
		private void pd_PrintPage(object sender, PrintPageEventArgs ev) {
			Graphics? g = ev.Graphics;
			AztecWriter aw = new AztecWriter();
			DrawHorizontalLine(ev, 1.1 / 29.7);
			DrawHorizontalLine(ev, 1 - (1.1 / 29.7));

			for (int i = 0; i < 13; i++) {
				DrawHorizontalLine(ev, (1.1 + (2.12 * i)) / 29.7);
			}

			for (int i = 0; i < 1; i++) {
				string val = Guid.NewGuid().ToString();
				ZXing.Common.BitMatrix matrix = ZXing.Aztec.Internal.Encoder.encode(val).Matrix;
			}
        }

		private void DrawIrlRect(PrintPageEventArgs ev, double x1, double y1, double x2, double y2) {
			ev.Graphics.FillRectangle(Brushes.Black, new Rectangle((int)(x1 * ev.PageBounds.Width), (int)(y1 * ev.PageBounds.Height), (int)((x2 - x1) * ev.PageBounds.Width), (int)((y2-y1) * ev.PageBounds.Height)));
		}
		private void DrawHorizontalLine(PrintPageEventArgs ev, double height) {
			ev.Graphics.FillRectangle(Brushes.Black, new Rectangle(0, (int)(height * ev.PageBounds.Height), ev.PageBounds.Width, 1));
		}
	}
}
