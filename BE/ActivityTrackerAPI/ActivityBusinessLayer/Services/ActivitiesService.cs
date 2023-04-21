using ActivityBusinessLayer.Interfaces;
using ActivityDataLayer.DbContext;
using ActivityDataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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

            existingActivity.Description = activity.Description;
            existingActivity.Name = activity.Name;

            await _dbContext.SaveChangesAsync();

            return existingActivity.Id;
        }

        public async Task<int> MarkActivityCompleted(int activityId)
        {
            var existingActivity = await _dbContext.Activities.FindAsync(activityId);

            if (existingActivity == null)
            {
                return -1;
            }

            existingActivity.Completed = true;

            await _dbContext.SaveChangesAsync();

            return existingActivity.Id;
        }

        public async Task<int> MarkActivityNeedHelp(int activityId)
        {
            var existingActivity = await _dbContext.Activities.FindAsync(activityId);

            if (existingActivity == null)
            {
                return -1;
            }

            existingActivity.NeedHelp = true;
            await _dbContext.SaveChangesAsync();

            return existingActivity.Id;
        }

        public async Task<Activity> GetActivity(int activityId) => await _dbContext.Activities.FirstOrDefaultAsync(x => x.Id == activityId);

        public async Task<List<Activity>> GetAllActivities() => await _dbContext.Activities.ToListAsync();

        public async Task<int> CreateActivity(Activity activity)
        {
            await _dbContext.Activities.AddAsync(activity);
            await _dbContext.SaveChangesAsync();


            return activity.Id;
        }

        public async Task<int> AddImageToActivity(IFormFile file, int activityId)
        {
            if (file == null || file.Length == 0)
            {
                return -1;
            }

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                byte[] imageData = stream.ToArray();

                var image = new ActivityImage
                {
                    ImageName = file.FileName,
                    MimeType = file.ContentType,
                    Content = imageData,
                    ActivityId = activityId
                };

                _dbContext.ActivityImages.Add(image);
                await _dbContext.SaveChangesAsync();

                return image.Id;
            }
        }

        public async Task<ActivityImage> GetActivityImage(int id)
        {
            var image = await _dbContext.ActivityImages.FindAsync(id);

            return image;
        }
    }
}
