using ActivityBusinessLayer.Interfaces;
using ActivityDataLayer.Models;
using ActivityDataLayer.Roles;
using ActivityTrackerAPI.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ActivityTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivitiesService _activitiesService;

        public ActivitiesController(IActivitiesService activitiesService)
        {
            _activitiesService = activitiesService;
        }

        [Authorize]
        [HttpGet]
        [Route("completedActivity")]
        public async Task<IActionResult> MarkActivityCompleted(int activityId)
        {
            var activity = await _activitiesService.MarkActivityCompleted(activityId);

            if (activity < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Could not complete activity!");
            }

            return StatusCode(StatusCodes.Status200OK, "Activity marked as completed!");
        }

        [Authorize]
        [HttpGet]
        [Route("completedActivity")]
        public async Task<IActionResult> MarkActivityNeedHelp(int activityId)
        {
            var activity = await _activitiesService.MarkActivityNeedHelp(activityId);

            if (activity < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Could not mark need help on activity!");
            }

            return StatusCode(StatusCodes.Status200OK, "Activity marked as need help!");
        }

        [Authorize]
        [HttpGet]
        [Route("GetActivity")]
        public async Task<Response<Activity>> GetActivity(int activityId)
        {
            var activity = await _activitiesService.GetActivity(activityId);

            if (activity == null)
            {
                return new Response<Activity>() { Content = null, Message = "Activity not found" };
            }

            return new Response<Activity> { Content = activity, Message = "Activity found!" };
        }

        [Authorize]
        [HttpGet]
        [Route("GetActivityImage")]
        public async Task<Response<ActivityImage>> GetActivityImage(int activityId)
        {
            var activity = await _activitiesService.GetActivityImage(activityId);

            if (activity == null)
            {
                return new Response<ActivityImage>() { Content = null, Message = "Activity image not found" };
            }

            return new Response<ActivityImage> { Content = activity, Message = "Activity image found!" };
        }

        [Authorize]
        [HttpGet]
        [Route("GetAllActivities")]
        public async Task<Response<List<Activity>>> GetAllActivities()
        {
            var activities = await _activitiesService.GetAllActivities();

            if(activities.Count == 0)
            {
                return new Response<List<Activity>>() { Content = null, Message = "No activities found" };
            }

            return new Response<List<Activity>> { Content = activities, Message = "Activities retrieved successfully!" };
        }

        [Authorize(UserRoles.Admin)]
        [HttpPost]
        [Route("create")]
        public async Task<Response<int>> CreateActivity(Activity activity)
        {
            var createdActivity = await _activitiesService.CreateActivity(activity);

            if (createdActivity < 0)
            {
                return new Response<int>() { Content = createdActivity, Message = "Activity not created!"  };
            }

            return new Response<int>() { Content = createdActivity, Message = $"Activity Created With ID {createdActivity}"};
        }

        [Authorize(UserRoles.Admin)]
        [HttpPost]
        [Route("createActivityImage")]
        public async Task<Response<int>> CreateActivity(IFormFile file, int activityId)
        {
            var createdActivity = await _activitiesService.AddImageToActivity(file, activityId);

            if (createdActivity < 0)
            {
                return new Response<int>() { Content = createdActivity, Message = "Activity Image not created!" };
            }

            return new Response<int>() { Content = createdActivity, Message = $"Activity Image Created With ID {createdActivity}" };
        }

        [Authorize(UserRoles.Admin)]
        [HttpPut]
        [Route("edit/{id:int}")]
        public async Task<Response<int>> EditActivity(int id, Activity activity)
        {
            var editedActivity = await _activitiesService.EditActivity(id, activity);

            if (editedActivity < 0)
            {
                return new Response<int>() { Content = editedActivity, Message = "Activity not edited!" };
            }

            return new Response<int>() { Content = editedActivity, Message = $"Activity Edited With ID {editedActivity}" };
        }

        [Authorize(UserRoles.Admin)]
        [HttpDelete]
        [Route("delete/{id:int}")] 
        public async Task<Response<int>> DeleteActivity(int id)
        {
            var deletedActivity = await _activitiesService.DeleteActivity(id);

            if (deletedActivity < 0)
            {
                return new Response<int>() { Content = deletedActivity, Message = "Activity not edited!" };
            }

            return new Response<int>() { Content = deletedActivity, Message = $"Activity Edited With ID {deletedActivity}" };
        }
    }
}
