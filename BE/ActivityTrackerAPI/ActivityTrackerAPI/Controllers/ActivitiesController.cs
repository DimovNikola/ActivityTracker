using ActivityBusinessLayer.Interfaces;
using ActivityDataLayer.Models;
using ActivityTrackerAPI.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ActivityTrackerAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivitiesService _activitiesService;

        public ActivitiesController(IActivitiesService activitiesService)
        {
            _activitiesService = activitiesService;
        }

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
