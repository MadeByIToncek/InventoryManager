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
			db = LoadDatabaseConfig();
			SplashScreen?.SetCurrentProgressMessage("SYSTEM", "Main form Init");
			MainForm = new ManagerWindow();
			MainForm.Load += MainForm_LoadCompleted;
			Application.Run(MainForm);
		}

		private static DatabaseController LoadDatabaseConfig() {
			try {
				JObject filecontent;
				Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "InventoryManager"));

				SplashScreen?.SetCurrentProgressMessage("DB", "Reading config");
				using (var sr = new StreamReader(Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "InventoryManager"), "config.json"))) {
					filecontent = JObject.Parse(sr.ReadToEnd());
				}

				SplashScreen?.SetCurrentProgressMessage("DB", "Parsing config");

				string address = filecontent["address"].Value<string>();
				int port = filecontent["port"].Value<int>();
				string database = filecontent["database"].Value<string>();
				string user = filecontent["user"].Value<string>();
				string password = filecontent["password"].Value<string>();
				return new DatabaseController(address, port, database, user, password);

			} catch (FileNotFoundException) {

				SplashScreen?.SetCurrentProgressMessage("DB", "Creating config");
				JObject content = new(
						new JProperty("address", "localhost"),
						new JProperty("port", 3306),
						new JProperty("database", "inventorymanager"),
						new JProperty("user", "root"),
						new JProperty("password", "123456789")
					);
				try {
					SplashScreen?.SetCurrentProgressMessage("DB", "Writing config");
					File.WriteAllText(Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "InventoryManager"), "config.json"), content.ToString());
				} catch (Exception e) {
					MessageBox.Show(e.Message);
				}
				return LoadDatabaseConfig();
			}
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