using System;
using System.Threading.Tasks;
using Activities.Models;

namespace Activities.IRepositories
{
    public interface IActivityRepository
    {
         Task<Activity> GetAsync(Guid id);
         Task AddAsync(Activity activity);
    }
}