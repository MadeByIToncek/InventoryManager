using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using InventoryManager.Entities;
using Microsoft.Extensions.Logging;
using MySqlX.XDevAPI;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Transform;
using NHibernate.Util;
using System.Data.Entity;

namespace InventoryManager {
	public class DatabaseController
    {
        private readonly ISessionFactory sf;

        public DatabaseController(string server, int port, string database, string user, string password)
        {
            Program.SplashScreen?.SetCurrentProgressMessage("DB", "Connecting");
            
            sf = Fluently.Configure()
                .Database(MySQLConfiguration.Standard.ConnectionString(c =>
                    c.Server(server)
                     .Port(port)
                     .Database(database)
                     .Username(user)
                     .Password(password)))
                .Mappings(m =>
                     m.FluentMappings.AddFromAssemblyOf<Program>())
                .ExposeConfiguration(TreatConfiguration)
                .BuildSessionFactory();

            Program.SplashScreen?.SetCurrentProgressMessage("DB", "Connected");

        }

        private static void TreatConfiguration(Configuration configuration)
        {
            Program.SplashScreen?.SetCurrentProgressMessage("DB Migrations", "Migrating table layout");
            var update = new SchemaUpdate(configuration);
            update.Execute(false, true);
            Program.SplashScreen?.SetCurrentProgressMessage("DB Migrations", "Table migration finished");
        }

		internal async Task CreateEmptyEvent() {
            await SaveOrUpdateEvent(new Event() {
                Name = "",
                Date = 0
            });
		}

		internal async Task<int> CreateEmptyItem() {
			return await SaveOrUpdateItem(new Item() {
				Name = "",
				Code = "",
			});
		}

		internal async Task DeleteEventById(int eventID) {
			using ISession s = sf.OpenSession();
			ITransaction trans = s.BeginTransaction();
			var query = s.QueryOver<Event>()
				.Where(i => i.Id == eventID)
				.TransformUsing(new DistinctRootEntityResultTransformer());
			await s.DeleteAsync(await query.SingleOrDefaultAsync<Event>());
			await trans.CommitAsync();
		}

		internal async Task DeleteItemById(int itemID) {
			using ISession s = sf.OpenSession();
			ITransaction trans = s.BeginTransaction();
			var query = s.QueryOver<Item>()
				.Where(i => i.Id == itemID)
				.TransformUsing(new DistinctRootEntityResultTransformer());
			await s.DeleteAsync(await query.SingleOrDefaultAsync<Item>());
			await trans.CommitAsync();
		}

		internal async Task<Event> GetEventById(int eventID) {
			using var session = sf.OpenSession();
			var query = session.QueryOver<Event>()
				.Where(i => i.Id == eventID)
				.TransformUsing(new DistinctRootEntityResultTransformer());
			return await query.SingleOrDefaultAsync<Event>();
		}

		internal async Task<IList<Event>> ListEvents() {
			using (ISession s = sf.OpenSession()) {
                return await s.QueryOver<Event>().ListAsync();
            };
		}

		internal async Task<IList<Item>> ListItem() {
			using (ISession s = sf.OpenSession()) {
				return await s.QueryOver<Item>().ListAsync();
			};
		}

		internal async Task SaveOrUpdateEvent(Event @event) {
			using ISession s = sf.OpenSession();
			ITransaction trans = s.BeginTransaction();
			await s.SaveOrUpdateAsync(@event);
			await trans.CommitAsync();
		}

		internal async Task UpdateItemById(int id, string name, string uuid) {
			using ISession s = sf.OpenSession();
			ITransaction trans = s.BeginTransaction();
			var query = await s.QueryOver<Item>()
				.Where(i => i.Id == id)
				.TransformUsing(new DistinctRootEntityResultTransformer()).SingleOrDefaultAsync<Item>();
			query.Name = name;
			query.Code = uuid;
			await s.SaveOrUpdateAsync(query);
			await trans.CommitAsync();
		}

		private async Task<int> SaveOrUpdateItem(Item item) {
			using ISession s = sf.OpenSession();
			ITransaction trans = s.BeginTransaction();
			await s.SaveOrUpdateAsync(item);
			await trans.CommitAsync();
			return item.Id;
		}
	}
}
