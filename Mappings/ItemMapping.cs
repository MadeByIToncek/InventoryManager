using FluentNHibernate.Mapping;
using InventoryManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Mappings {
	public class ItemMapping : ClassMap<Item> {
		public ItemMapping() { 
			Id(x=>x.Id);
			Map(x=>x.Name);
			Map(x=>x.Code);
		}
	}
}
