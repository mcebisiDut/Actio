using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Actio.Common.Mongo;
using Activities.IRepositories;
using Activities.Models;
using MongoDB.Driver;

namespace Activities.Services
{
    public class CustomCategorySeeder : DatabaseSeeder
    {
        private readonly ICategoryRepository _categoryRepository;
        public CustomCategorySeeder(IMongoDatabase database, ICategoryRepository categoryRepository) : base(database)
        {
            _categoryRepository = categoryRepository;
        }

        protected override async Task CustomSeedAsync()
        {
            var categories = new List<string> { "Work", "Sport", "Hobby" };
            await Task.WhenAll(categories.Select(category => _categoryRepository.AddAsync(new Category(category))));
        }
    }
}