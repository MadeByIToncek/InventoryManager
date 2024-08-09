using InventoryManager.gui;
using Newtonsoft.Json.Linq;

namespace InventoryManager {
	internal class Program {
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		public static DatabaseController db;
		public static SplashInterface? SplashScreen;
		public static ManagerWindow MainForm;

		[STAThread]
		static void Main() {
			ApplicationConfiguration.Initialize();
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			var splashThread = new Thread(new ThreadStart(
				() => {
					SplashScreen = new SplashInterface();

					Application.Run(SplashScreen);
				}));
			splashThread.SetApartmentState(ApartmentState.STA);
			splashThread.Start();

			SplashScreen?.SetCurrentProgressMessage("SYSTEM", "DB Init");
			db = LoadDatabaseConfig().Result;
			SplashScreen?.SetCurrentProgressMessage("SYSTEM", "Main form Init");
			MainForm = new ManagerWindow();
			MainForm.Load += MainForm_LoadCompleted;
			Application.Run(MainForm);
		}

		public static async Task<DatabaseController> LoadDatabaseConfig() {
			string filecontent = await GetDatabasePath();
			return new DatabaseController(filecontent);
		}

		private static void MainForm_LoadCompleted(object? sender, EventArgs? e) {
			if (SplashScreen != null && !SplashScreen.Disposing && !SplashScreen.IsDisposed)
				SplashScreen.Invoke(new Action(() => SplashScreen.Close()));
			MainForm.TopMost = true;
			MainForm.Activate();
		}

		internal static Size ConvertToFullSize(Size clientSize) {
			return new Size(clientSize.Width + 20, clientSize.Height + 60);
		}

		internal static async Task<string> GetDatabasePath() {
			try {
				Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "InventoryManager"));

				SplashScreen?.SetCurrentProgressMessage("DB", "Reading config");
				using var sr = new StreamReader(Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "InventoryManager"), "config.txt"));
				return await sr.ReadToEndAsync();
			} catch (FileNotFoundException) {
				try {
					SplashScreen?.SetCurrentProgressMessage("DB", "Writing new config");
					await File.WriteAllTextAsync(Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "InventoryManager"), "config.txt"), Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "InventoryManager"), "database.db"));
				} catch (Exception e) {
					MessageBox.Show(e.Message);
				}
				return await GetDatabasePath();
			}
		}
	}

	public partial class ManagerWindow : Form {
		public static ManagerWindow? instance;
		public static Form? runningWindow;

		public ManagerWindow() {
			instance = this;
			WindowState = FormWindowState.Minimized;
			ShowInTaskbar = false;
			Visible = false;

			//var initWindow = new LabelCreator();
			var initWindow = new EventList();
			runningWindow = initWindow;
			initWindow.Show();
		}

		public static void SwitchToWindow(Form target, Form source) {
			source.Hide();
			target.Show();
			runningWindow = target;
			source.Close();
		}

		public static void Exit() {
			//Program.db.Shutdown();
			runningWindow.Close();
			instance.Close();
		}

	}
}