using System.Collections.Generic;
using System.Threading.Tasks;
using Activities.Models;

namespace Activities.IRepositories
{
    public interface ICategoryRepository
    {
         Task<Category> GetAsync(string name);
         Task<IEnumerable<Category>> BrowseAsync();
         Task AddAsync(Category category);
    }
}