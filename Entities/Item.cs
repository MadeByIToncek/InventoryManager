using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Entities {
	public class Item {
		public virtual int Id { get; set; }
		public virtual string Name { get; set; }
		public virtual Guid Code { get; set; }
	}
}
