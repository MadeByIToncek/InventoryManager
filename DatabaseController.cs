﻿using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using InventoryManager.Entities;
using Microsoft.Extensions.Logging;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Transform;

namespace InventoryManager {
	public class DatabaseController {
		private readonly ISessionFactory sf;

		public DatabaseController(string path) {
			Program.SplashScreen?.SetCurrentProgressMessage("DB", "Connecting");

			sf = Fluently.Configure()
				.Database(SQLiteConfiguration.Standard.UsingFile(path))
				.Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>())
				.ExposeConfiguration(TreatConfiguration)
				.BuildSessionFactory();

			Program.SplashScreen?.SetCurrentProgressMessage("DB", "Connected");

		}

		private static async void TreatConfiguration(Configuration configuration) {
			Program.SplashScreen?.SetCurrentProgressMessage("DB Migrations", "Migrating table layout");
			var update = new SchemaUpdate(configuration);
			await update.ExecuteAsync(false, true);
			Program.SplashScreen?.SetCurrentProgressMessage("DB Migrations", "Table migration finished");
		}

		internal async Task ChangeUsedItemStateById(int eventID, Guid itemCode, State state) {
			using var s = sf.OpenSession();
			ITransaction trans = s.BeginTransaction();
			Item item = await s.QueryOver<Item>()
				.Where(i => (i.Code == itemCode))
				.TransformUsing(new DistinctRootEntityResultTransformer()).SingleOrDefaultAsync<Item>();
			UsedItem query = await s.QueryOver<UsedItem>()
				.Where(i => (i.Item.Id == item.Id) && (i.Event.Id == eventID))
				.TransformUsing(new DistinctRootEntityResultTransformer()).SingleOrDefaultAsync<UsedItem>();
			query.State = state;
			await s.SaveOrUpdateAsync(query);
			await trans.CommitAsync();
		}

		internal async Task Close() {
			await sf.EvictQueriesAsync();
			await sf.CloseAsync();
			sf.Dispose();
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
				Code = Guid.Empty,
			});
		}

		internal async Task CreateNewUsedItem(int itemId, int eventId) {
			using ISession s = sf.OpenSession();
			ITransaction trans = s.BeginTransaction();
			Item item = await s.QueryOver<Item>()
				.Where(i => i.Id == itemId)
				.TransformUsing(new DistinctRootEntityResultTransformer()).SingleOrDefaultAsync<Item>();
			Event @event = await s.QueryOver<Event>()
				.Where(i => i.Id == eventId)
				.TransformUsing(new DistinctRootEntityResultTransformer()).SingleOrDefaultAsync<Event>();

			UsedItem ui = new() {
				Item = item,
				Event = @event,
				State = State.Unset
			};

			await s.SaveOrUpdateAsync(ui);
			await trans.CommitAsync();
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

		internal async Task<UsedItem> GetUsedItemByItemID(int itemId, int eventId) {
			using var session = sf.OpenSession();
			UsedItem query = await session.QueryOver<UsedItem>()
				.Where(i => (i.Item.Id == itemId) && (i.Event.Id == eventId))
				.TransformUsing(new DistinctRootEntityResultTransformer()).SingleOrDefaultAsync<UsedItem>();
			if(query != null) return query;
			else {
				await CreateNewUsedItem(itemId, eventId);
				return await GetUsedItemByItemID(itemId,eventId);
			}
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

		internal async Task<IList<UsedItem>> ListUsedItemsForEvent(int eventId) {
			using var session = sf.OpenSession();
			return await session.QueryOver<UsedItem>()
				.Where(i => i.Event.Id == eventId)
				.TransformUsing(new DistinctRootEntityResultTransformer()).ListAsync<UsedItem>();
		}

		internal async Task SaveOrUpdateEvent(Event @event) {
			using ISession s = sf.OpenSession();
			ITransaction trans = s.BeginTransaction();
			await s.SaveOrUpdateAsync(@event);
			await trans.CommitAsync();
		}

		internal async Task UpdateItemById(int id, string name, Guid uuid) {
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
