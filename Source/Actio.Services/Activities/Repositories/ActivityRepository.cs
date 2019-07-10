using System;
using System.Threading.Tasks;
using Activities.IRepositories;
using Activities.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Activities.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly IMongoDatabase _database;

        public ActivityRepository(IMongoDatabase database)
        {
            _database = database;
        }
        public async Task<Activity> GetAsync(Guid id)
            => await Collection
                        .AsQueryable()
                        .FirstOrDefaultAsync(result => result.Id == id);
        public async Task AddAsync(Activity activity)
            => await Collection
                        .InsertOneAsync(activity);

        private IMongoCollection<Activity> Collection
            => _database.GetCollection<Activity>("Activities");

    }
}