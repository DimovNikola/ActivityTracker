using ActivityBusinessLayer.Interfaces;
using ActivityDataLayer.DbContext;
using ActivityDataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityBusinessLayer.Services
{
    public class ActivitiesService : IActivitiesService
    {
        private readonly ApplicationDbContext _dbContext;

        public ActivitiesService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> DeleteActivity(int activityId)
        {
            var exists = await _dbContext.Activities.FindAsync(activityId);
            
            if(exists == null)
            {
                return -1;
            }

            _dbContext.Activities.Remove(exists);
            await _dbContext.SaveChangesAsync();

            return exists.Id;
        }

        public async Task<int> EditActivity(int activityId, Activity activity)
        {
            var existingActivity = await _dbContext.Activities.FindAsync(activityId);

            if(existingActivity == null)
            {
                return -1;
            }

            existingActivity.ActivityImage = activity.ActivityImage;
            existingActivity.Description = activity.Description;
            existingActivity.Name = activity.Name;

            await _dbContext.SaveChangesAsync();

            return activity.Id;
        }

        public async Task<Activity> GetActivity(int activityId) => await _dbContext.Activities.FirstOrDefaultAsync(x => x.Id == activityId);

        public async Task<List<Activity>> GetAllActivities() => await _dbContext.Activities.ToListAsync();

        public async Task<int> CreateActivity(Activity activity)
        {
            await _dbContext.Activities.AddAsync(activity);

            return activity.Id;
        }
    }
}
