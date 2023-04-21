using ActivityDataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityBusinessLayer.Interfaces
{
    public interface IActivitiesService
    {
        public Task<int> CreateActivity(Activity activity);
        public Task<int> EditActivity(int id, Activity activity);
        public Task<int> DeleteActivity(int activityId);
        public Task<Activity> GetActivity(int activityId);
        public Task<List<Activity>> GetAllActivities();
        public Task<int> MarkActivityCompleted(int activityId);
        public Task<int> MarkActivityNeedHelp(int activityId);
        public Task<int> AddImageToActivity(IFormFile file, int activityId);
        public Task<ActivityImage> GetActivityImage(int id);
    }
}
