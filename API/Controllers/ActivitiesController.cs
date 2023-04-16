using Application.Activities;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        [HttpGet]   // api/activities
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]   // api/activities/Guid
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await Mediator.Send(new Details.Query { Id = id});
        }

        [HttpPost]  // api/activities
        public async Task<IActionResult> CreateActivity(Activity activity)
        {
            return Ok(await Mediator.Send(new Create.Command { Activity = activity}));
        }

        //q: with who does this activity communicate
        //a: with the mediator
        //q: what does the mediator do next    
        //a: it sends the command to the handler
        //q: what does the handler do next 
        //a: it saves the activity to the database
        //q: why do I need the mediator and the handler
        //a: because we want to keep our controllers clean and we want to keep our controllers thin

        [HttpPut("{id}")]   // api/activities/Guid
        public async Task<IActionResult> EditActivity(Guid id, Activity activity)
        {
            activity.Id = id;
            return Ok(await Mediator.Send(new Edit.Command { Activity = activity}));
        }

        [HttpDelete("{id}")]    // api/activities/Guid
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            return Ok(await Mediator.Send(new Delete.Command { Id = id}));
        }
    }
}