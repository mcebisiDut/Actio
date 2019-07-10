using System;
using System.Threading.Tasks;
using Authentication.Models;

namespace Authentication.IRepositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(string email);
        Task AddAsync(User user);
    }
}