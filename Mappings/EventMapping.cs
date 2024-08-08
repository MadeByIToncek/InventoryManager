using FluentNHibernate.Mapping;
using InventoryManager.Entities;
using NHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Mappings {
	public class EventMapping : ClassMap<Event> {
		public EventMapping() { 
			Id(x => x.Id)
				.Column("event_id");
			Map(x => x.Name)
				.Column("event_name");
			Map(x => x.Date)
				.Column("event_date");
			HasMany(x => x.Items)
				.Not.LazyLoad()
				.Cascade.All();
		}
	}
}
