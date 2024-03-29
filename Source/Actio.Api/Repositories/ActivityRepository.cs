using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Actio.Api.IRepositories;
using Actio.Api.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Actio.Api.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly IMongoDatabase _database;

        public ActivityRepository(IMongoDatabase database)
        {
            _database = database;
        }
        public async Task AddAsync(Activity activity)
            => await Collection
                        .InsertOneAsync(activity);

        public async Task<IEnumerable<Activity>> BrowseAsync(Guid userId)
            => await Collection
                        .AsQueryable()
                        .Where(user => user.UserId == userId)
                        .ToListAsync();

        public async Task<Activity> GetAsync(Guid id)
            => await Collection
                        .AsQueryable()
                        .FirstOrDefaultAsync(user => user.Id == id);

        private IMongoCollection<Activity> Collection 
            => _database.GetCollection<Activity>("Activities");
    }
}