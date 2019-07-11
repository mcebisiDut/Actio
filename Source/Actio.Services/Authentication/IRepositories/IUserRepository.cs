using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Authentication.Models;

namespace Authentication.IRepositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(string email);
        Task<IEnumerable<User>> BrowseAsync(string name);
        Task AddAsync(User user);
    }
}