namespace InventoryManager.Entities {
	public class UsedItem {
		public virtual int Id { get; protected set; }
		public virtual Event Event { get; set; }
		public virtual Item Item { get; set; }
		public virtual State State { get; set; }
	}
}
