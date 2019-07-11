using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Actio.Api.Models;

namespace Actio.Api.IRepositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<IEnumerable<User>> BrowseAsync(string name);
        Task<User> GetAsync(string email);
        Task<User> GetAsync(Guid id);
    }
}