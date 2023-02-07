using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Students.Queries.GetMountedCourses;
using Students.Commands.CourseRegistration;

namespace Students.Controllers
{
    [Route("api/courses")]
    [Authorize]
    public class MountedCourseController : ApiControllerBase
    {

        [HttpGet]
        public async Task<ActionResult> GetMountedCourses()
        {
            var courses = await Mediator.Send(new GetMountedQuery());
            return Ok(courses);
        }
        [HttpPost]
        public async Task<ActionResult> RegisterCourse(RegisterCourseCommandHandler command)
        {
            await Mediator.Send(command);

            return StatusCode(201);
        }

    }
}