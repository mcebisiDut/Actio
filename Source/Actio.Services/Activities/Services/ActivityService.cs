using System;
using System.Threading.Tasks;
using Actio.Common.Exceptions;
using Activities.IRepositories;
using Activities.IServices;
using Activities.Models;

namespace Activities.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ActivityService(IActivityRepository activityRepository, ICategoryRepository categoryRepository)
        {
            _activityRepository = activityRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task AddAsync(Guid id, Guid userId, string category, string name, string description, DateTime createdAt)
        {
            var activityCategory = _categoryRepository.GetAsync(name)
                                        ?? throw new ActioException("Category not found", $"Category: '{category}' was not found");
            
            var activity = new Activity(id,name,category,description,createdAt);
            await _activityRepository.AddAsync(activity);
        }
    }
}