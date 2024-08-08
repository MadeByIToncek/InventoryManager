namespace InventoryManager.Entities {
	public class Event {
		public virtual int Id { get; protected set; }
		public virtual string? Name { get; set; }
		public virtual int Date { get; set; }
		public virtual IList<UsedItem> Items { get; protected set; }

		public Event() => Items = [];
	}
}
