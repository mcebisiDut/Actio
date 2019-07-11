using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Actio.Api.Models;

namespace Actio.Api.IRepositories
{
    public interface IActivityRepository
    {
         Task<Activity> GetAsync(Guid id);
         Task AddAsync(Activity activity);
         Task<IEnumerable<Activity>> BrowseAsync(Guid userId);
    }
}