using System.Collections.Generic;
using System.Threading.Tasks;
using Activities.IRepositories;
using Activities.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Activities.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMongoDatabase _database;

        public CategoryRepository(IMongoDatabase database)
        {
            _database = database;
        }
        public async Task<Category> GetAsync(string name)
            => await Collection
                        .AsQueryable()
                        .FirstOrDefaultAsync(result => result.Name == name.ToLowerInvariant());
        public async Task AddAsync(Category category)
            => await Collection.InsertOneAsync(category);

        public async Task<IEnumerable<Category>> BrowseAsync()
            => await Collection
                        .AsQueryable()
                        .ToListAsync();

        private IMongoCollection<Category> Collection
            => _database.GetCollection<Category>("Categories");

    }
}