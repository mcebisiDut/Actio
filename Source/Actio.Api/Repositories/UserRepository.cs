using System.Threading.Tasks;
using Actio.Api.Models;
using Actio.Api.IRepositories;
using System;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Actio.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoDatabase _database;

        public UserRepository(IMongoDatabase database)
        {
            _database = database;
        }
        public async Task AddAsync(User user)
            => await Collection.InsertOneAsync(user);

        public async Task<IEnumerable<User>> BrowseAsync(string name)
            => await Collection
                        .AsQueryable()
                        .Where(user => user.Name == name.ToLowerInvariant())
                        .ToListAsync();

        public async Task<User> GetAsync(Guid id)
            => await Collection
                        .AsQueryable()
                        .FirstOrDefaultAsync(user => user.Id == id);

        public async Task<User> GetAsync(string email)
            => await Collection
                        .AsQueryable()
                        .FirstOrDefaultAsync(user => user.Email == email);

        private IMongoCollection<User> Collection
            => _database.GetCollection<User>("Users");
    }
}