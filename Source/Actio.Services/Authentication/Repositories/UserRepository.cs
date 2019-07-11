using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Authentication.IRepositories;
using Authentication.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Authentication.Repositories
{
    public class UserRepository : IUserRepository
    {
       private readonly IMongoDatabase _database;

        public UserRepository(IMongoDatabase database)
        {
            _database = database;
        }
        public async Task<User> GetAsync(Guid id)
            => await Collection
                        .AsQueryable()
                        .FirstOrDefaultAsync(user => user.Id == id);
        public async Task<User> GetAsync(string email)
            => await Collection
                        .AsQueryable()
                        .FirstOrDefaultAsync(result => result.Email == email.ToLowerInvariant());

        public async Task AddAsync(User user)
            => await Collection
                        .InsertOneAsync(user);

        public async Task<IEnumerable<User>> BrowseAsync(string name)
            => await Collection
                        .AsQueryable()
                        .Where(user => user.Name == name.ToLowerInvariant())
                        .ToListAsync();

        private IMongoCollection<User> Collection
            => _database.GetCollection<User>("Activities");
    }
}