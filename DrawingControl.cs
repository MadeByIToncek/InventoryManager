using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager
{
    partial class DrawingControl
    {
        [LibraryImport("user32.dll", EntryPoint = "SendMessageA")]
        public static partial int SendMessage(IntPtr hWnd, Int32 wMsg, [MarshalAs(UnmanagedType.Bool)] bool wParam, Int32 lParam);

        private const int WM_SETREDRAW = 11;

        public static void SuspendDrawing(Control parent)
        {
            SendMessage(parent.Handle, WM_SETREDRAW, false, 0);
        }

        public static void ResumeDrawing(Control parent)
        {
            SendMessage(parent.Handle, WM_SETREDRAW, true, 0);
            parent.Refresh();
			parent.PerformLayout();
		}
    }
}
