using FluentNHibernate.Mapping;
using InventoryManager.Entities;
using NHibernate.Mapping;

namespace InventoryManager.Mappings {
	public class UsedItemMapping : ClassMap<UsedItem>{
		public UsedItemMapping() {
			Id(x=>x.Id);
			References(c => c.Item).UniqueKey("UsedMappingUniqueKey");
			References(c => c.Event).UniqueKey("UsedMappingUniqueKey");
			Map(x => x.State);
		}
	}
}
