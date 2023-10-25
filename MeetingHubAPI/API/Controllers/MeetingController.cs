using Business;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingController : ControllerBase
    {
        private readonly IMeetingService meetingService;
        public MeetingController(IMeetingService meetingService)
        {
            this.meetingService = meetingService;
        }

        //public async Task<IActionResult> GetAllMeetings([FromQuery] int userID)
        //{

        //}


        //public async Task<IActionResult> DeleteMeeting([FromQuery] int userID, [FromQuery] int meetingID)
        //{

        //}
    }
}
