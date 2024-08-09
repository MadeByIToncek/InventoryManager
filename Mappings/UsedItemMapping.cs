using FluentNHibernate.Mapping;
using InventoryManager.Entities;
using NHibernate.Mapping;

namespace InventoryManager.Mappings {
	public class UsedItemMapping : ClassMap<UsedItem>{
		public UsedItemMapping() {
			Id(x=>x.Id);
			References(c => c.Item)
				.UniqueKey("UsedMappingUniqueKey")
				.Not.LazyLoad()
				.Cascade.None();
			References(c => c.Event)
				.UniqueKey("UsedMappingUniqueKey")
				.Not.LazyLoad()
				.Cascade.None();
			Map(x => x.State);
		}
	}
}
