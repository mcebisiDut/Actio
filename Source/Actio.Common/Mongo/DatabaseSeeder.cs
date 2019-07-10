using System;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Actio.Common.Mongo
{
    public class DatabaseSeeder : IDatabaseSeeder
    {
        protected readonly IMongoDatabase _database;

        public DatabaseSeeder(IMongoDatabase database)
        {
            _database = database;
        }
        public async Task SeedAsync()
        {
            var collectionCursor = await _database.ListCollectionsAsync();
            var collections = await collectionCursor.ToListAsync();
            if (collections.Any())
            {
                return;
            }
            await CustomSeedAsync();
        }

        protected virtual async Task CustomSeedAsync()
        {
            await Task.CompletedTask;
        }
    }
}