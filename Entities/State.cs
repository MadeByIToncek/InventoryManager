namespace InventoryManager.Entities {
	public enum State {
		Registered = 0,
		CheckedIn = 1,
		CheckedOut = 2,
		Unset = 3,
		Freed = 4
	}

	public class StateHelper {
		public static Color Background(State state, bool checkin) {
			switch (state) {
				case State.Registered:
					return Color.FromArgb(39,89,41);
				case State.CheckedIn:
					if (!checkin) {
						return Color.FromArgb(42, 100, 158);
					} else {
						return Color.FromArgb(109, 2, 14);
					}
				case State.CheckedOut:
					return Color.FromArgb(73, 73, 73);
				case State.Unset:
					return Color.FromArgb(255, 255, 255);
				case State.Freed:
					return Color.FromArgb(0, 0, 0);
				default:
					return Color.FromArgb(0, 0, 0);
			}
		}
		public static Color Foreground(State state) {
			switch (state) {
				case State.Registered:
					return Color.FromArgb(255,255,255);
				case State.CheckedIn:
					return Color.FromArgb(255, 255, 255);
				case State.CheckedOut:
					return Color.FromArgb(255, 255, 255);
				case State.Unset:
					return Color.FromArgb(0,0,0);
				case State.Freed:
					return Color.FromArgb(255, 255, 255);
				default:
					return Color.FromArgb(255, 255, 255);
			}
		}
	}
}